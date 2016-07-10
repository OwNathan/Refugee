using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour
{
    public AudioSource FootstepSFX;
    public float PitchVariation;
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
            FootstepSFX.pitch = originalPitch + Random.Range(-PitchVariation, PitchVariation);
            FootstepSFX.Play();
        }
    }
}
