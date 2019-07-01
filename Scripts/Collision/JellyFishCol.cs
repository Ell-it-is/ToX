using UnityEngine;
using System.Collections;

public class JellyFishCol : MonoBehaviour {

    private bool fadeAble = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "arrow")
        {
            //Znič šíp
            Destroy(other.gameObject);

            Destroy(GetComponent<jellyFishMove>());
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            fadeAble = true;
            Destroy(this.gameObject, 1.2f);
        }
    }

    private void Update ()
    {
        if (fadeAble == true)
        {
            FadeThis();
        }
        
        //Destroy if object is too far away of the screen
        if (transform.position.x < -8)
        {
            Destroy(this.gameObject);
        }
    }

    private void FadeThis()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a -= 0.01f;
        GetComponent<Renderer>().material.color = color;
    }
}
