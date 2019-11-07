using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShootingScript : MonoBehaviour    
{
    public AudioSource audioShoot;
    public AudioClip shootingClip;
    // Start is called before the first frame update

    private void Start()
    {
        audioShoot.clip = shootingClip;
       
    }

}
