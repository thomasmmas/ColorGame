using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic1 : MonoBehaviour
{
  public AudioSource audiotrack;

  void OnTriggerEnter(Collider other)
  {
		if(other.tag == "MainGuyRig" && !audiotrack.isPlaying)
		{
			audiotrack.Play();
		}
  }
}
