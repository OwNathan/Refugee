using UnityEngine;
using System.Collections;

public class ExplosionPlayback : MonoBehaviour
{
    private AudioSource SFX;
    private float counter = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
    }

    void OnParticleCollision(GameObject other)
    {
        if (SFX == null)
            SFX = other.GetComponent<AudioSource>();
        float randomTime = Random.Range(0.1f, 0.2f);

        if (counter < 0.0f)
        {
            float randomPitch = Random.Range(-0.2f, 0.2f);
            SFX.pitch = 1.0f - randomPitch;
            SFX.Play();
            counter = randomTime;
        }
    }
}
