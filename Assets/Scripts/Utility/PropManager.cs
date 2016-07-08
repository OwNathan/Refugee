using UnityEngine;
using System.Collections;

public class PropManager : MonoBehaviour
{
    new Rigidbody rigidbody;
    new Collider collider;
    new Renderer renderer;

    public void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        collider = this.GetComponent<Collider>();
        renderer = this.GetComponent<Renderer>();
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

    public void OnColliderOn()
    {
        collider.enabled = true;
    }
    public void OnColliderOff()
    {
        collider.enabled = false;
    }

    public void OnRendererOn()
    {
        renderer.enabled = true;
    }
    public void OnRendererOff()
    {
        renderer.enabled = false;
    }

    public void OnActivateObject()
    {
        this.gameObject.SetActive(true);
    }

    public void OnDeactivateObject()
    {
        this.gameObject.SetActive(false);
    }

    public void OnRigidbodyCollapse()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
    }
}
