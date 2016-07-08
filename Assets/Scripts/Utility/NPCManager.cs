using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private BoxCollider handsCollider;

    public void Start()
    {
        handsCollider = this.GetComponentInChildren<BoxCollider>();
    }

    public void OnHandsColliderEnable()
    {
        if(handsCollider != null)
            handsCollider.enabled = true;
    }

    public void OnHandsColliderDisable()
    {
        if (handsCollider != null)
            handsCollider.enabled = false;
    }
}