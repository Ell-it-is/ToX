using UnityEngine;
using System.Collections.Generic;

public class SharkSpawn : MonoBehaviour {

    public GameObject sharkPrefab;
    private List<Vector2> spawnPlace;

    private bool isSpawned = false;   
    private float positionX = 7;
    private int[] choices = new int[2] { -7, 7 };

    private void Update()
    {
        if (WayLength.length > 1460 && !isSpawned)
        {
            Instantiate(sharkPrefab, RandomSpawnPlace(), sharkPrefab.GetComponent<Transform>().rotation);
            isSpawned = true;
        }
    }

    private Vector2 RandomSpawnPlace()
    {
        if (WayLength.length > 1500)
        {
            int randomSpawnX = Random.Range(0, choices.Length);
            positionX = choices[randomSpawnX];
        }

        spawnPlace = new List<Vector2>();
        spawnPlace.Add(new Vector2(positionX, 0));
        spawnPlace.Add(new Vector2(positionX, 0));
        spawnPlace.Add(new Vector2(positionX, 0));
        spawnPlace.Add(new Vector2(positionX, 0));

        return spawnPlace[Random.Range(0, spawnPlace.Count)];
    }
}
