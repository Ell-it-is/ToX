using UnityEngine;
using System.Collections;

public class ToxicFishCol : MonoBehaviour {

    private bool fadeAble = false;

    private void OnTriggerEnter (Collider other) 
    {
        if (other.GetComponent<Collider>().tag == "arrow")
        {
            //Znič šíp
            Destroy(other.gameObject);

            //zastav movement a fade out object
            FishSpawn.fishCountInGame -= 1;
            Destroy(GetComponent<FollowBoat>());
            transform.position = new Vector3(transform.position.x,transform.position.y,-5);
            fadeAble = true;
            Destroy(this.gameObject, 1.2f);
        }

        else if (other.GetComponent<Collider>().tag == "Player")
        {
            Destroy(this.gameObject);
            FishSpawn.fishCountInGame -= 1;      
            Player.playerHealth -= 1;
        }
    }

    private void Update ()
    { 
        if (fadeAble == true)
        {
            FadeThis();
        }
    }

    private void FadeThis ()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a -= 0.01f;
        GetComponent<Renderer>().material.color = color;
    }
}
