using UnityEngine;
using System.Collections;

public class SharkMovement : MonoBehaviour {

    private int stage = 1;
    private float moveSpeed = 0.6f;
        
    private bool playerFound = false;
    private bool isReady = false;
    private bool charged = false;

    private Vector2 playerPos;
    private SpriteRenderer sharksSprite;

    private void Start()
    {
        sharksSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckDistance();
        MoveToPlayer(moveSpeed, playerPos); 
    }

    private void FindPlayer()
    {
        playerPos = Player.player.GetComponent<Transform>().position;
        playerFound = true;
    }

    private void MoveToPlayer(float _newSpeed, Vector2 _playerPos)
    {
        FindPlayer();
        transform.position = Vector2.MoveTowards(transform.position, _playerPos, moveSpeed * Time.deltaTime);
    }
        
    private void CheckDistance()
    {
        float dif = Vector2.Distance(transform.position, playerPos);
        if (dif > 5)
        {
            charged = false;
        }
        else
        {
            charged = true;
            ChargeOn(ref charged);
        }
    }

    private void ChargeOn(ref bool _charged)
    {
        if (_charged)
        {              
            moveSpeed = 2.5f;
        }
    }
}