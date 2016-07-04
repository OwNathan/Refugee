using UnityEngine;
using System.Collections;

public class GameObjectDisabler : MonoBehaviour
{
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
    }

}
