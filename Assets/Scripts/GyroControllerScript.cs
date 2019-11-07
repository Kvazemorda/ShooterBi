using UnityEngine;
using System;

public class GyroControllerScript : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;
    private float xEuler, yEuler, zEuler;


    // Start is called before the first frame update
    private void Start()
    {
        xEuler = 90f;
        yEuler = 90f;
        zEuler = 0f;
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnabelGyro();
    }

    private bool EnabelGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(xEuler, yEuler, zEuler);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        } 
    }
}
