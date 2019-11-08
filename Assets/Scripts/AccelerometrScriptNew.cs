using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometrScriptNew : MonoBehaviour
{
    public GameObject target;
    public Vector3 centerOffset;
    public float sensitivity = 1000;
    public float horizontalRange = 60;
    public float verticalRange = 30;
    public int filterWindowSize = 5;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Queue<Vector3> filter;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        filter = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        filter.Enqueue(Input.acceleration);
        if (filter.Count > filterWindowSize)
            filter.Dequeue();

        float totalX = 0, totalY = 0;
        foreach (Vector3 acc in filter)
        {
            totalX += acc.x;
            totalY += acc.y;
        }
        float filteredX = totalX / filter.Count;
        float filteredY = totalY / filter.Count;

        float xc = -filteredX * horizontalRange;
        float yc = (0.5f + filteredY) * 2 * verticalRange;

        xc = Clamp(xc, -horizontalRange, horizontalRange);
        yc = Clamp(yc, -verticalRange, verticalRange);

        transform.RotateAround(target.transform.localPosition + centerOffset, Vector3.up, xc);
        transform.RotateAround(target.transform.localPosition + centerOffset, Vector3.right, yc);

    }

    public T Clamp<T>(T val, T min, T max) where T : IComparable<T>
    {
        if (val.CompareTo(min) < 0) return min;
        else if (val.CompareTo(max) > 0) return max;
        else return val;
    }

    public void OnDisable()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
