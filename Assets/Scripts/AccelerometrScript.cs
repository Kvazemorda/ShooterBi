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
        float angle = Input.acceleration.x * 15f;
        
        Debug.Log(defRotX + " " + angle);
        //Quaternion quaternion = Quaternion.Euler(new Vector3(0f, -angle * 10f, -angle * 10));
        //Debug.Log(quaternion);
        //transform.localRotation = quaternion;

        transform.Rotate(0, 0, -(defRotX - angle));
        defRotX = angle;
    }
}
