using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WayLength : MonoBehaviour {

    public Text moveLength;
    public FishSpawn fishSpawn;

    public static float length = 1200;
    public static float newLength = 0.2f;

    private float changedLength = 1200;

    public static bool startBoss = false;
    private bool changeOnce = true;

    private void Update () {

        moveLength.text = length.ToString("0" + " m");

        //Check if game is not paused
        if (!PauseGame.gamePaused)
        {
            length += newLength;
        }

        StartSpawningFish();
        //Zvětši počet maximálních ryb ve hře
        ExpandMaxFishCount(250);

        //Check for boss start
        WayLengthForBossStart();

        if (startBoss)
            newLength = 0;
    }

    private void WayLengthForBossStart ()
    {
        if (length > 2000)
        {
            startBoss = true;
            Enemy.isBoss = true;
        }
    }

    private void StartSpawningFish()
    {
        if (length > 1250)
        {
            fishSpawn.enabled = true;
        }
    }

    private void ExpandMaxFishCount (float value)
    {
        if ((changedLength + value).ToString() + " m" == moveLength.text && changeOnce)
        {
            FishSpawn.maxFishCountInGame += 1;

            //add value for reuse
            changedLength = changedLength + value;
            changeOnce = false;
        }
        changeOnce = true;
    }
}
