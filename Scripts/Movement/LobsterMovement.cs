using UnityEngine;
using System.Collections;

public class LobsterMovement : MonoBehaviour {

    //Rychlost
    public float moveSpeed = 0.2f;

    //Rozhodování
    private int targetNumber = 0;

    //Pozice
    private Vector2 firstPosition = new Vector2(-2.34f, 1.9f);
    private Vector2 secondPosition = new Vector2(-2.14f, 1.2f);

    private void Update () {
        
        if (WayLength.startBoss)
        {
            transform.position = transform.position;
        }
        else
        {
            switch (targetNumber)
            {
                case 0:
                    MoveLobster(firstPosition);
                    break;
                case 1:
                    MoveLobster(secondPosition);
                    break;
                default:
                    break;
            }
        }
    }

    private void MoveLobster (Vector2 newTarget)
    {
        transform.position = Vector2.MoveTowards(transform.position, newTarget, moveSpeed * Time.deltaTime);

        if ((Vector2)transform.position == newTarget)
        {
            targetNumber = targetNumber + 1;
        }
    }
}
