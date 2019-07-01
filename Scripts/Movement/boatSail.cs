using UnityEngine;
using System.Collections;

public class boatSail : MonoBehaviour {


    private float MoveSpeed = 0.1f;

    private float frequency = 3.5f;  
    private float magnitude = 0.2f;  

    private Vector3 axis;
    private Vector3 pos;

    private bool moveRight = true;

    void Start()
    {
        pos = transform.position;
        axis = transform.up;
    }

    void Update()
    {
        ChangeShipSprite();
        pos.x = Mathf.PingPong(Time.time, 20.0f) - 10.0f;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void ChangeShipSprite()
    {
        if (pos.x < -9.8f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (pos.x > 9f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
