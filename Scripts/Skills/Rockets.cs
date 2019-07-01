using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rockets : MonoBehaviour {

    public GameObject rocketPrefab;
    public Transform harpoonPos;

    public List<GameObject> targets;
    public List<GameObject> rockets;

    public float moveSpeed = 2f;

    private bool canBeFired = false;
    private bool rocketsCreated = false;

    private void Update()
    {
        if (canBeFired)
        {
            if (!rocketsCreated)
            {
                CreateRockets(FindClosestEnemies());

                rocketsCreated = true;
            }

            if (rocketsCreated)
            {
                FireRockets(FindClosestEnemies(), rockets);
            }
        }
    }

    public List<GameObject> FindClosestEnemies ()
    {
        //Get list of potential enemies
        GameObject[] toxFishes = GameObject.FindGameObjectsWithTag("toxFish");
        GameObject[] jellyFishes = GameObject.FindGameObjectsWithTag("jellyFish");

        List<Transform> enemies = new List<Transform>();
        
        for (int i = 0; i < toxFishes.Length; i++)
        {
            enemies.Add(toxFishes[i].GetComponent<Transform>());
        }
        for (int i = 0; i < jellyFishes.Length; i++)
        {
            enemies.Add(jellyFishes[i].GetComponent<Transform>());
        }

        //Finding enemies
        targets = new List<GameObject>();
        Vector2 playerPos = Player.player.GetComponent<Transform>().position;

        float[] distances = new float[enemies.Count];

        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = Vector2.Distance(playerPos, enemies[i].position);
        }

        //Adding Targets
        Array.Sort(distances);
        for (int i = 0; i < distances.Length; i++ )
        {
            if (Vector2.Distance(playerPos, enemies[i].position) == distances[0])
            {
                targets.Add(enemies[i].gameObject);
            }
            else if (Vector2.Distance(playerPos, enemies[i].position) == distances[1])
            {
                targets.Add(enemies[i].gameObject);
            }
            else if (Vector2.Distance(playerPos, enemies[i].position) == distances[2])
            {
                targets.Add(enemies[i].gameObject);
            }
        }

        return targets;
    }

    public void SendMessageToRockets ()
    {        
        canBeFired = true;
        rocketsCreated = false;
    }

    private void CreateRockets (List<GameObject> targets)
    {
        rockets = new List<GameObject>(targets.Count);

        for (int i = 0; i < targets.Count; i++)
        {
            rockets.Add((GameObject)Instantiate
                (rocketPrefab, harpoonPos.position, rocketPrefab.GetComponent<Transform>().rotation));
        }
    }

    private void FireRockets (List<GameObject> targets, List<GameObject> rockets)
    {
        switch (rockets.Count)
        {
            case 1:
                if (rockets[0] != null)
                {
                    MoveRockets(0);
                }
                break;
            case 2:
                if (rockets[0] != null)
                {
                    MoveRockets(0);
                }

                if (rockets[1] != null)
                {
                    MoveRockets(1);
                }
                break;
            case 3:
                if (rockets[0] != null)
                {
                    MoveRockets(0);
                }

                if (rockets[1] != null)
                {
                    MoveRockets(1);
                }

                if (rockets[2] != null)
                {
                    MoveRockets(2);
                }
                break;
        }
    }

    void MoveRockets (int index)
    {
        rockets[index].GetComponent<Transform>().position = Vector2.MoveTowards
            (rockets[index].GetComponent<Transform>().position,     //Aktivní pozice
            targets[index].GetComponent<Transform>().position,      //Konečná pozice
            moveSpeed * Time.deltaTime);                            //Rychlost
    }
}
