using UnityEngine;
using System.Collections;

public class FollowBossParts : MonoBehaviour {

    public Transform target;
    public Sprite leftHead;
    public Sprite rightHead;

    //Scripts instance
    public BossMovement bossMovement;

    public float smoothTime = 0f;
    public static bool amIDestroyed = false;

    private void Update ()
    {
        if (gameObject.name == "Head" && bossMovement.LeftRight == "Left")
        {
            GetComponent<SpriteRenderer>().sprite = leftHead;
        }
        else if (gameObject.name == "Head" && bossMovement.LeftRight == "Right")
        {
            GetComponent<SpriteRenderer>().sprite = rightHead;
        }
        if (amIDestroyed)
        {
            DestroyThis();
        }
    }

    private void LateUpdate ()
    {
        Vector2 newPos = transform.position;
        newPos.x = Mathf.Lerp
            (transform.position.x, target.position.x, Time.deltaTime * smoothTime);

        newPos.y = Mathf.Lerp
            (transform.position.y, target.position.y, Time.deltaTime * smoothTime);

        transform.position = newPos;
        RotateMe();
    }

    private void RotateMe ()
    {
        Vector3 forward = target.position - transform.position;
        Vector3 upwards = transform.TransformDirection(Vector3.up);

        if (forward != Vector3.zero && upwards != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(forward, upwards);

            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
        Player.isGameWon = true;
    }
}


