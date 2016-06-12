using UnityEngine;
using System.Collections;

public class CharacterAnimatorSwitch : MonoBehaviour
{

    public Animator DefaultAnimator;
    public RuntimeAnimatorController AlternativeAnimator;


    
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ChangeAnimator()
    {
        DefaultAnimator.runtimeAnimatorController = AlternativeAnimator;
    }
}
