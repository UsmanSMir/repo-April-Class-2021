using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Dial : MonoBehaviour
{
    [SerializeField]
    private Transform origin;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform mesh;

    public UnityEvent<float> DialValueChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.parent = other.transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 dir = target.position - transform.position;
            dir = Vector3.ProjectOnPlane(dir, transform.up);
            Quaternion rot = Quaternion.LookRotation(dir, transform.up);
            transform.rotation = rot;

            DialValueChanged.Invoke(transform.eulerAngles.y);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target.parent = transform;
            target.position = origin.position;
        }
    }
}
