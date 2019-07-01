using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour {

    public bool endGame;
    private bool fadeAble = true;
    private bool waiting = false;

    private void Update () {

        //Počkej
        if (waiting == false)
        {
            StartCoroutine(WaitFor(1.2f));
        }

        //Vybledni
        if (waiting && fadeAble)
        {
            FadeThis();
        }
	}

    private void FadeThis()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a -= 0.01f;
        GetComponent<SpriteRenderer>().color = color;

        if (GetComponent<SpriteRenderer>().color.a == 0)
        {
            fadeAble = false;
        }
    }

    private IEnumerator WaitFor (float time)
    {
        yield return new WaitForSeconds(time);
        waiting = true;
    }
}
