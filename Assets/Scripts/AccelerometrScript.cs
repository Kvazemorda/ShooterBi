using System.Collections.Generic;
using UnityEngine;

public class AccelerometrScript : MonoBehaviour
{
    private float defRotX;

    private void Start()
    {
        defRotX = transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        float a = 0f;
        float angle = Input.acceleration.x;// * 15f;    
        a = (0.3f * angle) + (0.9f * a);
        //a = angle;
        Debug.Log(defRotX + " " + a);
        //Quaternion quaternion = Quaternion.Euler(new Vector3(0f, -angle * 10f, -angle * 10));
        //Debug.Log(quaternion);
        //transform.localRotation = quaternion;
        transform.RotateAroundLocal(new Vector3(0, 0, (defRotX - a)), 0.01f);
       
        // transform.Rotate(0, 0, -(defRotX - a));
        defRotX = a;
    }
}
