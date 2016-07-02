using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Handles one response case for response UI, otherwise layout group place single response option at the center of the screen
/// usually mounted on the first response button
/// </summary>

public class ResponseButtonOneResponseMGR : MonoBehaviour
{

    public Button SecondResponseButton;

    void Update()
    {
        if (!SecondResponseButton.gameObject.activeSelf)
            SecondResponseButton.gameObject.SetActive(true);
    }
}
