using System.Collections;
using UnityEngine;

public class TwoHandedItem : MonoBehaviour
{
    public Transform RightHand;
    public Transform LeftHand;
    public GameObject Item;
    public Light MuzzleFlashlight;
    public AudioSource ShootSFX;
    public bool SoundEnable;
    public bool Randomize;

    [HideInInspector]
    public bool IsTwoHanded;

    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponentInParent<Animator>();
        IsTwoHanded = true;
    }

    private void Update()
    {
        if (animator != null)
        {
            if (IsTwoHanded)
            {
                Item.transform.position = RightHand.transform.position;
                Vector3 vDirection = LeftHand.position - RightHand.position;
                Item.transform.rotation = Quaternion.LookRotation(vDirection);
            }
            else
            {
                Item.transform.position = RightHand.transform.position;
            }
        }
    }

    //called by animation event for fire animamations
    private void OnShoot()
    {
        MuzzleFlashlight.enabled = true;
        if (ShootSFX != null && SoundEnable)
        {
            if (Randomize)
                StartCoroutine(WaitForPlay(UnityEngine.Random.Range(0f, 0.5f)));
            else
                ShootSFX.Play();
        }
    }

    private IEnumerator WaitForPlay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ShootSFX.Play();
    }

    public void OnShootEnable()
    {
        SoundEnable = true;
    }

    private void OnShootEnd()
    {
        MuzzleFlashlight.enabled = false;
    }
}