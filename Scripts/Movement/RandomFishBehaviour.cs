using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomFishBehaviour : MonoBehaviour {

    //Instance
    private Transform Zzz;

    //Rychlost            
    private float moveSpeed = 1.5f;
    private float waitTime = 2f;

    //rozhodování
    private bool isMoving = false;
    private bool runOnce = false;

    private const float MOVE_PROBABILITY = 0.9f;
    private const float STAY_PROBABILITY = 1f;

    //Pozice
    private Vector3 targetPosition;
    private float lockZ = -1;

    private Decision decision;

    private interface Decision {
        void Update(RandomFishBehaviour b);
    };

    private class MoveDecision : Decision
    {
        public void Update(RandomFishBehaviour b)
        {
            if (!b.isMoving)
            {
                b.targetPosition = b.GetTargetPosition();
            }
            if (b.targetPosition != null)
            {
                b.isMoving = true;
                b.MoveFish(b.targetPosition);
            }
        }
    }

    private class StayDecision : Decision
    {
        public void Update(RandomFishBehaviour b)
        {
            if (!b.runOnce)
            {
                b.runOnce = true;
                b.StartCoroutine(b.Stay(b.waitTime));
            }
        }
    }

    private void Awake ()
    {
        Zzz = (Transform)Resources.Load("prefabs/Zzz", typeof(Transform));
    }

    private bool randomBool(float probability)
    {
        return UnityEngine.Random.value < probability;
    }

    private void setDecision()
    {
        if (randomBool(MOVE_PROBABILITY))
        {
            NewMoveSpeed();
            decision = new MoveDecision();
        }
        else if (randomBool(STAY_PROBABILITY))
        {
            decision = new StayDecision();
        }

        //} else (randomBool(OTHER_PROBABILITY)) { 
        //decistion = 3;
        //}
    }

    private void Update()
    {
        if (decision == null)
        {
            setDecision();
        }

        decision.Update(this);
    }

    public Vector3 GetTargetPosition()
    {
        Vector3[] rmp = new Vector3[2];

        float fishX = transform.position.x;
        float fishY = transform.position.y;

        Vector3 longWalk = new Vector3(Random.Range(-5.22f, 5.22f),
                                       Random.Range(-2.9f, 0f));
        Vector3 shortWalk = new Vector3(Random.Range(fishX - 0.8f, fishX + 0.8f),
                                        Random.Range(fishY - 0.8f, fishY + 0.8f));

        rmp[0] = longWalk;
        rmp[1] = shortWalk;

        return rmp[Random.Range(0, rmp.Length)];
    }

    public void MoveFish (Vector2 tarPos)
    {
        //Pokud se target pozice nachází dále napravo než ryba, otoč o 180 stupňů
        if (tarPos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0,180,0); 
        }        
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Posunuj rybu dokud nedosáhne pozice targetu
        transform.position = Vector2.MoveTowards(transform.position, tarPos, moveSpeed * Time.deltaTime);

        Vector3 newPos = transform.position;
        newPos.z = lockZ;
        transform.position = newPos;

        //pokud ryba stojí na místě kam se měla dostat, přestane se hýbat
        if (transform.position.x == tarPos.x && transform.position.y == tarPos.y)
        {
            decision = null;
            isMoving = false;
        }
    }

    private IEnumerator Stay(float wait)
    {
        GameObject z = (GameObject)Instantiate
            (Zzz.gameObject, 
            new Vector3(transform.position.x + 0.07f,transform.position.y + 0.07f, Zzz.position.z),
            Zzz.rotation);

        GetComponent<Rigidbody>().velocity = Vector2.zero;
        yield return new WaitForSeconds(wait);
        Destroy(z);
        decision = null;
        runOnce = false;
    }

    private void NewMoveSpeed()
    {
        moveSpeed = Random.Range(0.8f, 1.25f);
    }
}
