using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressDownReloadScript : MonoBehaviour
{
    public Gun gun;
    private void OnMouseDown()
    {
        gun.Reload();
    }
}
