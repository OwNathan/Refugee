using UnityEngine;
using System.Collections;

public class TwoHandedItem : MonoBehaviour
{
    public Transform RightHand;
    public Transform LeftHand;
    public GameObject Item;
    public Light MuzzleFlashlight;

    [HideInInspector]
    public bool IsTwoHanded;

    private Animator animator;

    void Awake()
    {
        animator = this.GetComponentInParent<Animator>();
        IsTwoHanded = true;
    }

    void Update()
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
    void OnShoot()
    {
        MuzzleFlashlight.enabled = true;
    }

    void OnShootEnd()
    {
        MuzzleFlashlight.enabled = false;
    }
}
