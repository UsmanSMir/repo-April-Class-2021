using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private Material material;
    private Color originalColor;

    private bool isGrabbed;
    private List<Vector3> positions = new List<Vector3>();
    private float throwForce = 10;

    public Color hoveredColor;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;

        originalColor = material.color;
    }

    private void FixedUpdate()
    {
        if(isGrabbed == true)
        {
            if(positions.Count > 20)
            {
                positions.RemoveAt(0);
                positions.Add(transform.position);
            }
            else
            {
                positions.Add(transform.position);
            }
        }
    }

    public void OnHoverStart()
    {
        material.color = hoveredColor;
    }

    public void OnHoverEnd()
    {
        material.color = originalColor;
    }

    public void OnGrabStart(Grabber hand)
    {
        isGrabbed = true;

        #region Kinematic Grab
        //transform.SetParent(hand.transform);
        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().isKinematic = true;
        #endregion

        #region Fixed Joint Grab
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = hand.GetComponent<Rigidbody>();
        fx.breakForce = 5000;
        fx.breakTorque = 5000;
        #endregion
    }

    public void OnGrabEnd()
    {
        isGrabbed = false;

        #region Kinematic Release
        //transform.SetParent(null);
        //GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<Rigidbody>().isKinematic = false;
        #endregion

        #region Fixed Joint Release
        FixedJoint fx = GetComponent<FixedJoint>();
        if(fx != null)
        {
            Destroy(fx);
        }
        #endregion

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = (positions[positions.Count - 1] - positions[0]) * throwForce;
    }
}
