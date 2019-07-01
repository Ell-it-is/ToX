using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

    //Instance
    public static GameObject basicFishPrefab;
    public static GameObject smallFishPrefab;
    public static GameObject bloatFishPrefab;

    public static GameObject devilFishPrefabRight;
    public static GameObject devilFishPrefabLeft;

    private void Awake ()
    {
        bloatFishPrefab = (GameObject)Resources.Load("prefabs/bloatFishPrefab", typeof(GameObject));
        basicFishPrefab = (GameObject)Resources.Load("prefabs/basicFishPrefab", typeof(GameObject));
        smallFishPrefab = (GameObject)Resources.Load("prefabs/smallFish", typeof(GameObject));
        devilFishPrefabLeft = (GameObject)Resources.Load("prefabs/devilFishPrefabLeft", typeof(GameObject));
        devilFishPrefabRight = (GameObject)Resources.Load("prefabs/devilFishPrefabRight", typeof(GameObject));
    }
}
