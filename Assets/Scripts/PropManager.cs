using UnityEngine;
using System.Collections;

public class PropManager : MonoBehaviour
{
    new Rigidbody rigidbody;

    public void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    public void OnBoolIsKinematicOn()
    {
        if(rigidbody != null)
            rigidbody.isKinematic = true;
    }
    public void OnBoolIsKinematicOff()
    {
        if (rigidbody != null)
            rigidbody.isKinematic = false;
    }
}
