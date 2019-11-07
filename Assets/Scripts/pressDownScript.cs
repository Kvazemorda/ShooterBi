using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressDownScript : MonoBehaviour
{
    public Gun gun;
    private void OnMouseDown()
    {
        gun.Shoot();
    }
}
