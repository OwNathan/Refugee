using UnityEngine;
using System.Collections;

public class Shovel : MonoBehaviour
{
    public Transform RightHand;
    public Transform LeftHand;
    public GameObject Item;

	void Update ()
    {
        Item.transform.position = RightHand.transform.position;
        Vector3 vDirection = LeftHand.position - RightHand.position;
        Item.transform.rotation = Quaternion.LookRotation(vDirection);
    }
}
