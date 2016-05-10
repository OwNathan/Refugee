using UnityEngine;
using System.Collections;
using AC;

public class PlayerManager : MonoBehaviour
{
    private GameObject Target;
    private BoxCollider handsCollider;

    public void Start()
    {
        Target = GameObject.FindObjectOfType<Player>().gameObject;
        if(Target != null)
        {
            handsCollider = Target.GetComponentInChildren<BoxCollider>();
        }
    }

    public void OnHandsColliderEnable()
    {
        if (handsCollider != null)
            handsCollider.enabled = true;
    }
    public void OnHandsColliderDisable()
    {
        if (handsCollider != null)
            handsCollider.enabled = false;
    }
}
