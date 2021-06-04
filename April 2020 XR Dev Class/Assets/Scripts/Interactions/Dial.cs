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

    public UnityEvent DialValueChanged;

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
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = rot;
            DialValueChanged.Invoke();
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
