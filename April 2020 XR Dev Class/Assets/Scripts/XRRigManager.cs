using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRigManager : MonoBehaviour
{
    public Transform playerHead;
    public Transform shadowPlane;
    // Update is called once per frame
    void Update()
    {
        Vector3 feetPosition = playerHead.localPosition;
        feetPosition.y = 0.0001f;
        shadowPlane.localPosition = feetPosition;
    }
}
