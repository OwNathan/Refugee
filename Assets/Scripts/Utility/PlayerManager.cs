using UnityEngine;
using System.Collections;
using AC;

public class PlayerManager : MonoBehaviour
{
    public bool GiveLabelToRashid;
    private GameObject Target;
    private BoxCollider handsCollider;

    public void Start()
    {
        Target = GameObject.FindObjectOfType<Player>().gameObject;
        if (Target != null)
        {
            handsCollider = Target.GetComponentInChildren<BoxCollider>();

            if (GiveLabelToRashid)
            {
                Hotspot hs = Target.AddComponent<Hotspot>();
                hs.hotspotName = "Rashid";
            }
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
    public void OnDisable()
    {
        if (Target != null)
            Target.gameObject.SetActive(false);
    }
    public void DestroyPlayer()
    {
        if (Target != null)
            GameObject.Destroy(Target);
    }
}
