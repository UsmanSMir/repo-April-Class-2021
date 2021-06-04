using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Watch : MonoBehaviour
{
    public TextMeshProUGUI m_textWatch;

    // Update is called once per frame
    void Update()
    {
        m_textWatch.text = System.DateTime.Now.ToShortTimeString();


        //string watchTime = System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" +
        //    System.DateTime.Now.Second.ToString();
        //m_textWatch.text = watchTime;
    }
}
