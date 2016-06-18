using UnityEngine;
using System.Collections;

public class CharacterAnimatorSwitch : MonoBehaviour
{

    public Animator DefaultAnimator;
    public RuntimeAnimatorController DisabledHeydarAC;
    public RuntimeAnimatorController WomanHeydarAC;
    public RuntimeAnimatorController CrippledHeydarAC;

    public void SetDisabledAnimator()
    {
        DefaultAnimator.runtimeAnimatorController = DisabledHeydarAC;
    }
    public void DisableHeydarCharacter()
    {
        this.gameObject.SetActive(false);
    }

    public void EnableHeydarWomanCharacter()
    {
        this.gameObject.SetActive(true);
    }

    public void SetCrippledAnimator()
    {
        DefaultAnimator.runtimeAnimatorController = CrippledHeydarAC;
    }
}
