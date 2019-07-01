using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossMovement : MonoBehaviour {
     //Rychlost
     public float moveSpeed = 2f;

     //Rozhodování
     private int targetNumber = 0;
     public string LeftRight = "";

     //Pozice
     private Vector3 playerPos;
     private Vector3 moveDirection;
     private List<Vector2> positions = new List<Vector2>();
     private void Start ()
     {
         playerPos = Player.player.GetComponent<Transform>().position;

         positions.Add(new Vector2(4.42f, 0.59f));
         positions.Add(new Vector2(4.42f, -1.62f));
         positions.Add(new Vector2(2.24f, -2.94f));
         positions.Add(new Vector2(-9.96f, -1.93f));
         positions.Add(new Vector2(6.54f, -0.73f));
         positions.Add(new Vector2(2.93f, 1.12f));
         positions.Add(new Vector2(-3.74f, -4.53f));
        positions.Add(new Vector2(4.42f, 0.59f));
        positions.Add(new Vector2(4.42f, -1.62f));
        positions.Add(new Vector2(2.24f, -2.94f));
        positions.Add(new Vector2(-9.96f, -1.93f));
        positions.Add(new Vector2(6.54f, -0.73f));
        positions.Add(new Vector2(2.93f, 1.12f));
        positions.Add(new Vector2(-3.74f, -4.53f));
        positions.Add(new Vector2(4.42f, 0.59f));
        positions.Add(new Vector2(4.42f, -1.62f));
        positions.Add(new Vector2(2.24f, -2.94f));
        positions.Add(new Vector2(-9.96f, -1.93f));
        positions.Add(new Vector2(6.54f, -0.73f));
        positions.Add(new Vector2(2.93f, 1.12f));
        positions.Add(new Vector2(-3.74f, -4.53f));
    }

     private void Update()
     {
         switch (targetNumber)
         {
             case 0:
                 MoveBoss(positions[0]);
                 CheckPosition(positions[0]);
                 break;
             case 1:
                 MoveBoss(positions[1]);
                 CheckPosition(positions[1]);
             break;
            case 2:
                MoveBoss(positions[2]);
                CheckPosition(positions[2]);
                break;
            case 3:
                MoveBoss(positions[3]);
                CheckPosition(positions[3]);
                break;
            case 4:
                MoveBoss(positions[4]);
                CheckPosition(positions[4]);
                break;
            case 5:
                MoveBoss(positions[5]);
                CheckPosition(positions[5]);
                break;
            case 6:
                MoveBoss(positions[6]);
                CheckPosition(positions[6]);
                break;
        } 
     }

     private void MoveBoss(Vector2 newTarget)
     {
         transform.position = Vector2.MoveTowards(transform.position, newTarget, moveSpeed * Time.deltaTime);

         if ((Vector2)transform.position == newTarget)
         {
             targetNumber = targetNumber + 1;
         }
     }

     private void CheckPosition (Vector3 targetPosition)
     {
         if (transform.position.x < targetPosition.x)
         {
             LeftRight = "Right";
         }
         else if (transform.position.x > targetPosition.x)
         {
             LeftRight = "Left";
         }
     }
}