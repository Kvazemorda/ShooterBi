using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_script : MonoBehaviour
{
    public int speed = 50;
    private Rigidbody body;
    private float moveX, moveY, moveZ;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.acceleration.x * speed;
        moveY = Input.acceleration.y * speed;
        moveZ = Input.acceleration.z * speed;

        body.velocity = new Vector3(moveX, moveY, moveZ);
    }
}
