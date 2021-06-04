using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionMove : MonoBehaviour
{
    private enum Hand { Left, Right};


    [SerializeField]
    private Hand hand;

    private string horizontalAxisName;
    private string verticalAxisName;

    [SerializeField]
    private Transform playerHead;
    [SerializeField]
    private Transform XRRig;


    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float moveSpeed;


    private void Awake()
    {
        horizontalAxisName = "XRI_" + hand + "_Primary2DAxis_Horizontal";
        verticalAxisName = "XRI_" + hand + "_Primary2DAxis_Vertical";
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis(horizontalAxisName);

        XRRig.RotateAround(playerHead.position, Vector3.up, turnSpeed * Time.deltaTime * x);

        float y = Input.GetAxis(verticalAxisName);
        Vector3 direction = playerHead.forward;
        direction.y = 0;
        direction.Normalize();

        XRRig.position += direction * Time.deltaTime * moveSpeed * y;

    }
}
