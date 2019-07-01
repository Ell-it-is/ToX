using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //Instance
    public Transform boatPos;

    //Rychlost
    float moveSpeed = 0.5f;

    //Pozice
    float lockPos = 0;

    //Target Pozice
    Vector2 baseTarget;      
    Vector2 newTarget;

    //Rozhodování    
    bool isTargetSet = false;
    bool moveF = true;
    bool moveB = true;

    void Start ()
    {
        baseTarget = new Vector2(boatPos.position.x, boatPos.position.y);
    }

    void Update ()
    {
        if (!isTargetSet)
        {
            //Rychlost
            moveSpeed = (Random.Range(0.35f, 0.65f));

            //Target
            newTarget = new Vector2(Random.Range(-3.5f, -1f), Random.Range(0f, -1.4f));
            baseTarget = new Vector2(-4.5f, newTarget.y);

            isTargetSet = true;
        }

        if (isTargetSet && moveF)
        {
            MoveForward(newTarget);
            WayLength.newLength = 0.2f;
        }

        if (moveB && !moveF)
        {
            MoveBackward(baseTarget);
            WayLength.newLength = 0;
        }
    }

    void MoveForward(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, moveSpeed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            moveF = false;
        }
    }

    void MoveBackward(Vector2 startPoint)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), startPoint, moveSpeed * Time.deltaTime);

        if (transform.position.x == startPoint.x && transform.position.y == startPoint.y)
        {
            isTargetSet = false;
            moveF = true;
        }
    }
}

