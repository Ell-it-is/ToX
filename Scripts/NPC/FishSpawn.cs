using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishSpawn: MonoBehaviour {

    //Instance
    public static GameObject clon;

    //Spawn Time
    private float firstSpawn = 2f;
    public static float repeatSpawn = 1f;        //zmenšuje se po delším čase ve hře

    //Fish count
    public static int fishCountInGame = 0;           
    public static int maxFishCountInGame = 5;    //zvětšuje se po delším čase ve hře

    //Counter
    private int nameNumber = 0;                 //určuje jména ryb ve hře

    void Start ()
    {
        //Opakuj spawnování ryb
        InvokeRepeating("Spawn", firstSpawn, repeatSpawn);
    }

    void Update()
    {
        if (fishCountInGame == maxFishCountInGame)
        {   
            CancelInvoke();
        }
        else
        {
            if (maxFishCountInGame > 5)
                Spawn();
        }
    }

    void Spawn ()
    {
        List<GameObject> fishPrefabs;
        if (Player.playerHealth <= 0)
        {
            //Přestaň spawnovat ryby a vyskoč z metody  
            CancelInvoke();
            return;
        }
        else
        {
            //Výběr náhodné ryby
            fishPrefabs = new List<GameObject>();
            fishPrefabs.Add(Fish.basicFishPrefab);
            fishPrefabs.Add(Fish.smallFishPrefab);
            fishPrefabs.Add(Fish.bloatFishPrefab);
            GameObject randomPrefab = fishPrefabs[Random.Range(0,fishPrefabs.Count)];
    
            RandomScale(randomPrefab);
            //Vyrob novou rybu a dej jí script
            clon = Instantiate(randomPrefab, RandomSpawnPoint(), randomPrefab.GetComponent<Transform>().rotation) as GameObject;
            clon.AddComponent<NahodnyPohybRyby>();
            clon.name = "ryba " + nameNumber;
            fishCountInGame += 1;
            nameNumber++;
        }
    }

    //Místa odkud se mohou spawnovat ryby
    public Vector2 RandomSpawnPoint ()
    {
        Vector2[] spawnPoints = new Vector2[4];
        spawnPoints[0] = new Vector2(3.36f, -2.76f);
        spawnPoints[1] = new Vector2(3.36f, -0.59f);
        spawnPoints[2] = new Vector2(-4.46f, 0.13f);
        spawnPoints[3] = new Vector2(-3.08f, -2.08f);

        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    void RandomScale (GameObject fp)
    {
        List<Vector2> fishScaleList = new List<Vector2>();

        fishScaleList.Add(new Vector2(0.03f,0.03f));
        fishScaleList.Add(new Vector2(0.035f, 0.035f));   

        fp.GetComponent<Transform>().localScale = fishScaleList[Random.Range(0, fishScaleList.Count)];  
    }
}





