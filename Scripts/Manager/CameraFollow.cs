using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject follower;
    private float distanceToPlayer;

    private void Start ()
    {
        distanceToPlayer = transform.position.x - follower.transform.position.x;
    }

    private void Update () {

        float followerX = follower.transform.position.x;

        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = followerX + distanceToPlayer;
        transform.position = newCameraPosition;
    }
}
