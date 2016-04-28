using UnityEngine;
using System.Collections;
using AC;
public class NPCManager : MonoBehaviour
{

    private GameObject Target;
    private BoxCollider handsCollider;

    public void Start()
    {
        Target = GameObject.FindObjectOfType<NPC>().gameObject;
        if (Target != null)
        {
            handsCollider = Target.GetComponentInChildren<BoxCollider>();
        }
    }

    public void OnHandsColliderEnable()
    {
        handsCollider.enabled = true;
    }
    public void OnHandsColliderDisable()
    {
        handsCollider.enabled = false;
    }

}
