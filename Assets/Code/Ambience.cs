using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public AudioSource audiotrack;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="MainGuyRig" && !audiotrack.isPlaying)
        {
            audiotrack.Play();
        }
    }
}
