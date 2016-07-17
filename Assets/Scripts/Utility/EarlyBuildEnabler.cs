using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// For Pre-Alpha build only enables and disable GUI Disclaimer Image
/// </summary>
public class EarlyBuildEnabler : MonoBehaviour
{
    public Image EarlyBuildImage;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F10))
            EarlyBuildImage.enabled = false;
        else if (Input.GetKeyDown(KeyCode.F11))
            EarlyBuildImage.enabled = true;
    }
}
