using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JellyFishSpawn : MonoBehaviour {

    public GameObject jellyFishPrefab;
    private List<Vector2> spawnPlace;
    private bool isSpawned = false;

    private float whenSpawn = 10;
    private float positionX = 6;
    private int[] choices = new int[2] { -6, 6 };

    private void Update ()
    {
        if (GameTimer.timeCount > whenSpawn && isSpawned == false)
        {
            //Spawn
            Instantiate(jellyFishPrefab, RandomSpawnPlace(), jellyFishPrefab.GetComponent<Transform>().rotation);
            isSpawned = true;

            //Time to next spawn
            whenSpawn += 8f;
            isSpawned = false;
        }
    }

    private Vector2 RandomSpawnPlace ()
    {
        if (WayLength.length > 1500)
        {
            int randomSpawnX = Random.Range(0, choices.Length);
            positionX = choices[randomSpawnX];            
        }

        spawnPlace = new List<Vector2>();
        spawnPlace.Add(new Vector2(positionX, 1.08f));
        spawnPlace.Add(new Vector2(positionX, -0.4f));
        spawnPlace.Add(new Vector2(positionX, -1.6f));
        spawnPlace.Add(new Vector2(positionX, -2.5f));

        return spawnPlace[Random.Range(0,spawnPlace.Count)];
    }
}
