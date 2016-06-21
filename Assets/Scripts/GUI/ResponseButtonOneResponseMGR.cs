using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResponseButtonOneResponseMGR : MonoBehaviour
{

    public Button SecondResponseButton;




    // Update is called once per frame
    void Update()
    {
        if (!SecondResponseButton.gameObject.activeSelf)
            SecondResponseButton.gameObject.SetActive(true);
    }
}
