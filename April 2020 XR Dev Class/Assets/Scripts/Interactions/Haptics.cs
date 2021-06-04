using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Haptics : MonoBehaviour
{
    private InputDevice m_VRController;
    public XRNode m_node;
    private bool m_canVibrate;

    void Awake()
    {
        m_VRController = InputDevices.GetDeviceAtXRNode(m_node);
        if (m_VRController.isValid)
        {
            HapticCapabilities hapcap = new HapticCapabilities();
            m_VRController.TryGetHapticCapabilities(out hapcap);

            if (hapcap.supportsImpulse)
            {
                m_canVibrate = true;
            }
        }
    }

    public void Vibrate(float strength, float duration)
    {
        strength = Mathf.Clamp(strength, 0, 0.95f);
        m_VRController.SendHapticImpulse(0, strength, duration);
    }

}
