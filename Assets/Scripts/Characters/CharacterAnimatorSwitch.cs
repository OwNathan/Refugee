using UnityEngine;
using AC;
using System.Collections;

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
