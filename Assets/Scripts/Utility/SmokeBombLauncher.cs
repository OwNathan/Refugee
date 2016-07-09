using UnityEngine;
using System.Collections;

public class SmokeBombLauncher : MonoBehaviour
{
    public Transform LaunchTarget;
    public float LaunchForce;
    private Rigidbody smokeBombRigidbody;

    void Awake()
    {
        smokeBombRigidbody = this.GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start ()
    {
        Vector3 Trajectory = LaunchTarget.position - this.transform.position;
        if (smokeBombRigidbody != null)
        {
            smokeBombRigidbody.AddForce(Trajectory * LaunchForce, ForceMode.Impulse);
        }
    }
	
    void FixedUpdate()
    {

    }
	// Update is called once per frame
	void Update () {
	
	}
}
