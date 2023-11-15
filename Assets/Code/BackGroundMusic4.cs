using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic4 : MonoBehaviour
{
  public MusicManager musicManager;
  public int trackIndex = 0;

  void OnTriggerEnter(Collider other)
  {
		if(other.CompareTag("MainGuyRig"))
		{
			musicManager.PlayMusicTrack(trackIndex);
		}
  }
}
