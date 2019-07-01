using UnityEngine;
using System.Collections;

public class EnemyCol : MonoBehaviour {

    private void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<Collider>().tag == "jellyFish")
        {
            Destroy(other.gameObject);
            Player.playerHealth -= 1;   
        }
        else if (other.GetComponent<Collider>().tag == "bossHead")
        {
            Player.playerHealth -= 1;
        }
    }
}



