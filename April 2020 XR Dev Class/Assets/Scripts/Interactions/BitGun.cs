using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : MonoBehaviour
{
    [SerializeField]
    private float shootForce;
    [SerializeField]
    private GameObject bit;
    [SerializeField]
    private Transform bitSpawn;
    void TriggerDown()
    {
        GameObject go = Instantiate(bit, bitSpawn.position, bitSpawn.rotation);
        go.GetComponent<Rigidbody>().AddForce(shootForce * bitSpawn.forward);
        Destroy(go, 5);
    }
}
