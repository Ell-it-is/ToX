using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NahodnyPohybRyby : MonoBehaviour {

    //Instance
    Transform Zzz;

    //Rychlost            
    float moveSpeed = 1.5f;
    float waitTime = 2f;

    //rozhodování
    bool isMoving = false;
    bool setDecision = false;
    bool runOnce = false;

    int decision;
    float probabilityMove;
    float probabilityStay;

    //Pozice
    Vector3 targetPosition;
    float lockZ = -1;    

    void Awake ()
    {
        Zzz = (Transform)Resources.Load("prefabs/Zzz", typeof(Transform));
    }

    void Update()
    {
        if (!setDecision)
        {
            probabilityMove = 0.1f;
            probabilityStay = 0.9f;
            float randomDec = Random.value; 

            if (randomDec > probabilityMove && randomDec < probabilityStay) //80%
            {
                MoveFaster();
                decision = 1;
            }
            else if (randomDec > probabilityStay) //10%
            {
                decision = 2;
            }
            else
            {
                decision = 1;                     //10%
            }
            setDecision = true;
        }

        switch (decision)
        {
            case 1:
                if (setDecision == true)
                {
                    if (!isMoving)
                    {
                        targetPosition = GetTargetPosition();
                    }
                    if (targetPosition != null)
                    {
                        isMoving = true;
                        MoveFish(targetPosition);
                    }
                }
                break;
            case 2:
                if (setDecision == true && !runOnce)
                {
                    runOnce = true;
                    StartCoroutine(Stay(waitTime));
                }
                break;
            default:
                Debug.Log("Špatná metoda");
                break;        
        }
    }

    Vector3 GetTargetPosition()
    {
        Vector3[] rmp = new Vector3[2];

        //Long walk
        float minX = -5.22f;
        float maxX = 5.22f;

        float minY = -2.9f;
        float maxY = 0f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 randomMovePoint1 = new Vector3(randomX, randomY);

        //Short walk
        float closeMinX = transform.position.x - 0.8f;
        float closeMaxX = transform.position.x + 0.8f;

        float closeMinY = transform.position.y - 0.8f;  
        float closeMaxY = transform.position.y + 0.8f;

        float randomCloseX = Random.Range(closeMinX, closeMaxX);
        float randomCloseY = Random.Range(closeMinY, closeMaxY);

        if (randomCloseX < minX || randomCloseX > maxX)
        {
            return randomMovePoint1;
        }
        else if(randomCloseY < minY | randomCloseY > maxY)
        {
            return randomMovePoint1;
        }
        else
        {
            Vector3 randomMovePoint2 = new Vector3(randomCloseX, randomCloseY);
            rmp[0] = randomMovePoint1;
            rmp[1] = randomMovePoint2;

            return rmp[Random.Range(0, rmp.Length)];
        }
    }

    void MoveFish (Vector2 tarPos)
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

        //pokud ryba stojí na místě kam se má pohnout, přestane se hýbat
        if (transform.position.x == tarPos.x && transform.position.y == tarPos.y)
        {
            setDecision = false;
            isMoving = false;
        }
    }

    IEnumerator Stay(float wait)
    {
        GameObject z = (GameObject)Instantiate(Zzz.gameObject, new Vector3(transform.position.x + 0.07f, transform.position.y + 0.07f, Zzz.position.z), Zzz.rotation);
        GetComponent<Rigidbody>().velocity = Vector2.zero;
        yield return new WaitForSeconds(wait);
        Destroy(z);
        setDecision = false;
        runOnce = false;
    }

    void MoveFaster()
    {
        moveSpeed = Random.Range(0.8f, 1.5f);
    }
}
