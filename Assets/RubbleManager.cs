using UnityEngine;
using System.Collections;
using AC;
using System.Linq;

public class RubbleManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Hotspot hs = GameObject.FindGameObjectsWithTag("RubbleHotspot").ToList().First().GetComponent<Hotspot>();
        if(hs != null)
        {
            hs.highlight = this.GetComponent<Highlight>();
        }
        else
        {
            throw new UnityException("give to Rubble GO an hotspot!");
        }
    }
}
