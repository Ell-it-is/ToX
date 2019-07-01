using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class jellyFishMove : MonoBehaviour {

    public static float moveSpeed = 2;

    //Pozice
    private Vector3 playerPos;
    private Vector3 moveDirection;


    private void Start ()
    {
        FindTarget();
    }

    private void Update () {

        MoveJellyFish();
	}

    private void FindTarget ()
    {
        playerPos = Player.player.GetComponent<Transform>().position;

        if (playerPos.y > 1)
        {
            Vector2 newPos = transform.position;
            newPos.y = 1.15f;
            transform.position = newPos; 
        }
        moveDirection = (playerPos - transform.position).normalized;
    }

    private void MoveJellyFish ()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
