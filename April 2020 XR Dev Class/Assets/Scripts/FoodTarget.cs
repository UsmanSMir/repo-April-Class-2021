using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Food")
        {
            FoodFight.instance.UpdateScore();
            FoodFight.instance.SpawnTarget();
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }
}
