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
        handsCollider.enabled = true;
    }

    public void OnHandsColliderDisable()
    {
        handsCollider.enabled = false;
    }
}