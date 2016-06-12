using UnityEngine;
using System.Collections;

public class InventoryGUIManager : MonoBehaviour
{

    public Animator InventoryAnimator;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnClickRight()
    {
        InventoryAnimator.SetBool("GoRight", true);
    }
    public void OnClickLeft()
    {
        InventoryAnimator.SetBool("GoLeft", true);
    }
}
