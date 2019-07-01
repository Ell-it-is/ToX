using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveBackground : MonoBehaviour {

    private float speed = 0.08f;
    private float moveLength;

    private void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;        
    }   
}
