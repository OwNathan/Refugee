using UnityEngine;
using AC;
using System.Collections;
/// <summary>
/// This script handles animator changes to fit situational cutscene/gameplay needs, like Heydar in checkpoint charlie
/// usually mounted on root character gameobject and called by actions from AC (Object->callEvent)
/// </summary>
public class CharacterAnimatorSwitch : MonoBehaviour
{

    public Animator DefaultAnimator;
    public RuntimeAnimatorController DisabledAC;
    public RuntimeAnimatorController WomanAC;
    public RuntimeAnimatorController CrippledAC;
    public RuntimeAnimatorController NormalAC;

    public void SetDisabledAnimator()
    {
        DefaultAnimator.runtimeAnimatorController = DisabledAC;
    }
    public void DisableHeydarCharacter()
    {
        this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        //this.gameObject.SetActive(false);
    }

    public void EnableHeydarWomanCharacter()
    {
        this.gameObject.SetActive(true);
    }

    public void SetCrippledAnimator()
    {
        DefaultAnimator.runtimeAnimatorController = CrippledAC;
    }
    public void SetNormamlAnimator()
    {
        DefaultAnimator.runtimeAnimatorController = NormalAC;
    }
}
