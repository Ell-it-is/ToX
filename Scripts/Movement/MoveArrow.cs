using UnityEngine;
using System.Collections;

public class MoveArrow : MonoBehaviour
{
    public float throwSpeed = 7;
    private Vector3 normalizeDirection;


    private void Start()
    {
        normalizeDirection = new Vector3(1, 0);
    }

    private void Update()
    {
        MoveMe();

        if (!transform.GetComponent<Renderer>().isVisible)
        {
            DestroyMe();
        }
    }

    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    private void MoveMe()
    {
        transform.Translate(normalizeDirection * throwSpeed * Time.deltaTime);        
    }
}