using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCockingScript : MonoBehaviour
{
    public AudioSource audioCocking;
    public AudioClip cockingClip;
    // Start is called before the first frame update
    void Start()
    {
        audioCocking.clip = cockingClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
