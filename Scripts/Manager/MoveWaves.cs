using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveWaves : MonoBehaviour {

    public GameObject[] wavesTop;
    public GameObject[] wavesBottom;

    private float moveSpeed = 0.2f;
    private bool status = true;

    private void Start ()
    {
        wavesTop = GameObject.FindGameObjectsWithTag("waveTop");
        wavesBottom = GameObject.FindGameObjectsWithTag("waveBottom");
    }

    private void Update()
    {
        if (status)
        {
            StartCoroutine(MoveWithSeeRight());
        }
        else if (!status)
        {
            StartCoroutine(MoveWithSeeLeft());
        }
    }

    private IEnumerator MoveWithSeeRight()
    {
        foreach(GameObject waveT in wavesTop)
        {
            Transform waveTPos = waveT.transform;
            waveTPos.Translate(new Vector2(1, 0) * Time.deltaTime * moveSpeed);
        }

        foreach (GameObject waveT in wavesBottom)
        {
            Transform waveTPos = waveT.transform;
            waveTPos.Translate(new Vector2(-1, 0) * Time.deltaTime * moveSpeed);
        }

        status = true;

        yield return new WaitForSeconds(8.0f);

        status = false;
    }

    private IEnumerator MoveWithSeeLeft()
    {
        foreach (GameObject waveT in wavesTop)
        {
            Transform waveTPos = waveT.transform;

            waveTPos.Translate(new Vector2(-1, 0) * Time.deltaTime * moveSpeed);
        }

        foreach (GameObject waveT in wavesBottom)
        {
            Transform waveTPos = waveT.transform;

            waveTPos.Translate(new Vector2(1, 0) * Time.deltaTime * moveSpeed);
        }

        status = false;

        yield return new WaitForSeconds(8.0f);

        status = true;
    }
}
