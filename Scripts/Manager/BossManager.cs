using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {

    //Objects
    public GameObject battleStartImage;
    public GameObject anchor;
    public GameObject pipes;

    //Scripts
    public BossMovement bossMovement;                   //Object used to set path for snake

    //Map
    public SpriteRenderer bossBC;
    public SpriteRenderer moon;

    //Rozhodování
    private bool bossFightPrepared = false;
    private bool waitInUpdate = false;

    private void Update () {

        if (WayLength.startBoss && bossFightPrepared == false)
        {
            DestroyAllNoNeedEnemies();
            PrepareStuffs();

            if (waitInUpdate == false)
            {   
                StartCoroutine(ShowBossStartImage());
            }
        }
        
        if (bossFightPrepared)
        {
            bossMovement.enabled = true;
        }
    }

    private bool ShowBossBackground ()
    {

        //Pokud není bc plně zviditelněný
        if (bossBC.color.a != 255)
        {
            Color newColor = bossBC.color;
            newColor.a += 0.02f;
            bossBC.color = newColor;

            Color newColor1 = moon.color;
            newColor1.a += 0.02f;
            moon.color = newColor1;
            return false;
        }
        else
        {
            return true;
        }
    }

    private IEnumerator ShowBossStartImage ()
    {
        battleStartImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        waitInUpdate = true;

        bossFightPrepared = true;
    }

    private void PrepareStuffs ()
    {
        ShowBossBackground();
        anchor.SetActive(false);
        pipes.SetActive(false);

    }

    private void DestroyAllNoNeedEnemies ()
    {
        GameObject[] fishes = GameObject.FindGameObjectsWithTag("fish");

        for (int i = 0; i < fishes.Length; i++)
        {
            Destroy(fishes[i]);
        }

        GameObject[] sleepImages = GameObject.FindGameObjectsWithTag("zzz");

        for (int i = 0; i < sleepImages.Length; i++)
        {
            Destroy(sleepImages[i]);
        }

        GameObject[] jellyFish = GameObject.FindGameObjectsWithTag("jellyFish");

        for (int i = 0; i < jellyFish.Length; i++)
        {
            Destroy(jellyFish[i]);
        }

        GameObject[] toxFishes = GameObject.FindGameObjectsWithTag("toxFish");

        for (int i = 0; i < toxFishes.Length; i++)
        {
            Destroy(toxFishes[i]);
        }
    }
}
