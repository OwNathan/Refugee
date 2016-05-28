using UnityEngine;
using System.Collections;
using AC;

public class WorldUIManager : MonoBehaviour
{

    MainCamera CurrentCamera;
    // Use this for initialization
    void Start ()
    {
        CurrentCamera = KickStarter.mainCamera;
        transform.rotation = Quaternion.LookRotation(transform.position - CurrentCamera.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        CurrentCamera = KickStarter.mainCamera;
        transform.rotation = Quaternion.LookRotation(transform.position - CurrentCamera.transform.position);
    }
}
