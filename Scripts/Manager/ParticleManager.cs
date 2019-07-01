using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

    //Objekty
    public GameObject[] pipes;
    private GameObject currentPipe;

    public GameObject[] poisons;
    private GameObject currentPoison;

    //Rozhodování
    private bool isTimeSet = false;

    //Ostatní
    private float timeForNew;
    private int pipeIndex;

    private void Start ()
    {
        pipeIndex = Random.Range(0, pipes.Length);
    }

    private void Update ()
    {
        if (isTimeSet == false)
        {
            isTimeSet = true;
            timeForNew = Random.Range(5, 8);
            StartCoroutine(ChangeToxin(timeForNew));
        }
    }

    private IEnumerator ChangeToxin (float time)
    {
        int newIndex;

        do
        {
            newIndex = Random.Range(0, pipes.Length);

        } while (pipeIndex == newIndex);

        if (pipeIndex != newIndex)
        {
            currentPipe = pipes[newIndex];
            currentPipe.GetComponentInChildren<ParticleSystem>().Play();

            //Move Collider
            currentPoison = poisons[newIndex];
            do
            {
                Vector3 boxCol = currentPoison.GetComponent<CapsuleCollider>().center;
                boxCol.y += 0.14f;
                currentPoison.GetComponent<CapsuleCollider>().center = boxCol;      
                yield return new WaitForSeconds(0.18f);
            } while (currentPoison.GetComponent<CapsuleCollider>().center.y < 1.3f);

            yield return new WaitForSeconds(time);
            currentPipe.GetComponentInChildren<ParticleSystem>().Stop();

            if (currentPoison.GetComponent<CapsuleCollider>().center.y > 1.25)
            {
                Vector3 boxCol = currentPoison.GetComponent<CapsuleCollider>().center;
                boxCol.y = -1f;
                currentPoison.GetComponent<CapsuleCollider>().center = boxCol;
            }
            pipeIndex = newIndex;
            isTimeSet = false;
        }
    }
}
