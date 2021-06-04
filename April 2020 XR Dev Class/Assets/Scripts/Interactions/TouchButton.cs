using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchButton : MonoBehaviour
{
    public Transform m_buttonMesh;
    public Transform m_downTransform;
    public UnityEvent m_buttonPressed;
    public UnityEvent m_buttonReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_buttonMesh.position = m_downTransform.position;
            m_buttonPressed.Invoke();
            other.GetComponent<Haptics>().Vibrate(0.5f, 0.35f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_buttonMesh.localPosition = Vector3.zero;
            m_buttonReleased.Invoke();
        }
    }
}