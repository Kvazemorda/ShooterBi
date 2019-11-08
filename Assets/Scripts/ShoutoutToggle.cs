using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutoutToggle : MonoBehaviour
{
    private Vector3 oldVector3;
    public bool toggle;
    private void Start()
    {
        oldVector3 = transform.position;
    }
    public void MoveRifle()
    {
        if (toggle)
        {
            transform.position = new Vector3(544f, 0f, oldVector3.z);
            toggle = false;
        }
        else
        {
            transform.position = oldVector3;
            toggle = true;
        }
    }

    //перемещение ружья с камерой после перезарядки
    public void MoveRifleAfterReload(int bulletLeft)
    {
        float newPostionX = (bulletLeft - 1) * 136;
        if(bulletLeft == 0)
        {
            newPostionX = 544f;
        }
        transform.position = new Vector3(newPostionX, 0f, oldVector3.z);
    }
}
