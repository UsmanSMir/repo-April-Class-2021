using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodFight : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;

    [SerializeField]
    private GameObject prefabTarget;
    [SerializeField]
    private Vector3 minimumSpawnArea;
    [SerializeField]
    private Vector3 maximumSpawnArea;

    private int score = 0;

    public static FoodFight instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        SpawnTarget();
    }

    public void UpdateScore()
    {
        score++;

        scoreDisplay.text = "score: " + score;
    }

    public void SpawnTarget()
    {
        Instantiate(prefabTarget, GetRandomTargetPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomTargetPosition()
    {
        float x = Random.Range(minimumSpawnArea.x, maximumSpawnArea.x);
        float y = Random.Range(minimumSpawnArea.y, maximumSpawnArea.y);
        float z = Random.Range(minimumSpawnArea.z, maximumSpawnArea.z);

        return new Vector3(x,y,z);
    }
}
