using UnityEngine;
using System;

public class GyroRifleScript : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject rifleContainer;
    private Quaternion rot;

    // Start is called before the first frame update
    private void Start()
    {
        rifleContainer = new GameObject("Rifle Container");
        gyroEnabled = EnabelGyro();
        rifleContainer.transform.position = transform.position;
        transform.SetParent(rifleContainer.transform);
    }

    private bool EnabelGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            rifleContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
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
        if (gyro.enabled)
        {

            transform.localRotation = gyro.attitude * rot;
        } 
    }
}
