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
        rigidbody.isKinematic = true;
    }
    public void OnBoolIsKinematicOff()
    {
        rigidbody.isKinematic = false;
    }
}
