using UnityEngine;
using System.Collections;

public class PoisonCol : MonoBehaviour
{
    private Vector3 normalFishPos;
    private Vector2 setScale;

    private void OnTriggerEnter(Collider poison)
    {
        normalFishPos = this.gameObject.GetComponent<Transform>().position;

        if (poison.gameObject.tag == "poison")  
        {
            //Nová velikost
            setScale = this.gameObject.GetComponent<Transform>().localScale;
            
            //Zničení této ryby
            Destroy(this.gameObject);


            if (transform.position.x >= Player.player.GetComponent<Transform>().position.x)
            {
                ChoosePrefab(Fish.devilFishPrefabRight);
            }
            if (transform.position.x < Player.player.GetComponent<Transform>().position.x)
            {
                ChoosePrefab(Fish.devilFishPrefabLeft);
            }
        }
    }

    private void ChoosePrefab (GameObject prefab)
    {
        GameObject devilFish = Instantiate(prefab, normalFishPos, prefab.GetComponent<Transform>().rotation) as GameObject;
        devilFish.GetComponent<Transform>().localScale = setScale;
        devilFish.AddComponent<FollowBoat>();
    }
}
