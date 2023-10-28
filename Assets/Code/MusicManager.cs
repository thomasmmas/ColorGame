using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioSource> musicTracks = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var track in musicTracks)
        {
            track.Stop();
        }
        
    }

    void PlayMusic(AudioSource musicTrack)
    {
        if(!musicTrack.isPlaying)
        {
            musicTrack.Play();
        }
    }
    
    public void PlayMusicTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Count)
        {
            PlayMusic(musicTracks[trackIndex]);

            for (int i = 0; i <musicTracks.Count; i++)
            {
                if(i != trackIndex)
                {
                    musicTracks[i].Stop();
                }
            }
        }
    }
}
