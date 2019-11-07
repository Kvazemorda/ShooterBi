﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRifle : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(-target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
