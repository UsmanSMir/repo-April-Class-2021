using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningHead : MonoBehaviour
{
    [SerializeField]
    private Transform spinngHead;
    [SerializeField]
    private Transform vrHead;
    [SerializeField]
    private float turnSpeed;


    [SerializeField]
    private Vector3 handStartPosition;

    [SerializeField]
    private Vector3 towardsStart;
    [SerializeField]
    private Vector3 towardsHand;
    [SerializeField]
    private Vector3 upAxis;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            handStartPosition = other.transform.position;
            towardsStart = handStartPosition - spinngHead.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            towardsHand = other.transform.position - spinngHead.position;
            upAxis = Vector3.Cross(towardsHand, towardsStart);
            upAxis.Normalize();
            spinngHead.Rotate(upAxis * Time.deltaTime * -turnSpeed, Space.World);
        }
    }
}
