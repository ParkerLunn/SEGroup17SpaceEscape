using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

    public static GameObject FindComponentInChildWithTag(GameObject parent, string tag)
    {
        Transform transform = parent.transform;
        foreach(Transform t in transform)
        {
            if(t.tag == tag)
            {
                return t.GetComponent<GameObject>();
            }
        }
        return null;
    }
}
