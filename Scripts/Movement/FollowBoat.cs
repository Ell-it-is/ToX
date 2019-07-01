using UnityEngine;
using System.Collections;

public class FollowBoat : MonoBehaviour
{
    public static Transform playerTrans;
    private Vector3 playerPos;

    private float moveSpeed = 2f;

    private string LeftRight = "";

    private void Awake ()
    {   
        playerTrans = Player.player.GetComponent<Transform>();
    }

    private void Update()
    {
        if (FindPosition())
        {
            FollowTarget(moveSpeed);
            ChooseFishRotation();
            RotateFish();
        }
        Quaternion newRot = transform.localRotation;
        newRot.x = 0;
        newRot.y = 0;
        transform.localRotation = newRot;
    }

    private bool FindPosition()
    {         
        playerPos = playerTrans.position;
        return true;
    }

    private void FollowTarget(float speed)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerPos, speed * Time.deltaTime);
    }

    private void ChooseFishRotation ()
    {
        if (transform.position.x <= playerPos.x)
        {
            LeftRight = "Left";
        }
        else if (transform.position.x > playerPos.x)
        {
            LeftRight = "Right";
        }
    }

    private void RotateFish ()
    {
        Quaternion newRotation = Quaternion.LookRotation(transform.position - playerPos, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);

        if (LeftRight == "Left")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Fish.devilFishPrefabLeft.GetComponent<SpriteRenderer>().sprite;
        }
        if (LeftRight == "Right")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Fish.devilFishPrefabRight.GetComponent<SpriteRenderer>().sprite;
        }
    }
}