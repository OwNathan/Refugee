using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackGroundWarSFXManager : MonoBehaviour
{
    public List<AudioClip> WarAudioClips;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
	    if(!audioSource.isPlaying)
        {
            audioSource.clip = WarAudioClips[Random.Range(0, WarAudioClips.Count)];
            audioSource.PlayDelayed(Random.Range(0.5f, 5.0f));
        }
	}
}
