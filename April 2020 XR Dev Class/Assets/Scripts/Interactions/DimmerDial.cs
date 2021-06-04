using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerDial : MonoBehaviour
{
    [SerializeField]
    private Light light;
    public void AdjustLight()
    {
        light.intensity = transform.eulerAngles.y / 360;
        Debug.Log(transform.eulerAngles.y);
    }
}
