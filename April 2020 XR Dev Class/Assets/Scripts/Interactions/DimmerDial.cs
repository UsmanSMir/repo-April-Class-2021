using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerDial : MonoBehaviour
{
    [SerializeField]
    private Light light;
    public void AdjustLight(float y)
    {
        light.intensity = y / 360;

        Debug.Log(transform.eulerAngles.y);
    }
}
