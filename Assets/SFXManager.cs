using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour
{
    public AudioSource FootstepSFX;
    public float PitchVariation;
    public bool DontPlay;
    private float originalPitch;

    
    void Awake()
    {
        if (FootstepSFX != null)
            originalPitch = FootstepSFX.pitch;
    }
	void PlayFootstepSFX()
    {
        if (FootstepSFX != null)
        {
            if (!DontPlay)
            {
                FootstepSFX.pitch = originalPitch + Random.Range(-PitchVariation, PitchVariation);
                FootstepSFX.Play();
            }
            
        }
    }
}
