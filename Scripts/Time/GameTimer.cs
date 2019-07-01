using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;   

public class GameTimer : MonoBehaviour {
     
    public static float timeCount;
    private float seconds = 0;
    private float minutues = 0;
    public Text gameTime;

    private void Update()
    {
        seconds += Time.deltaTime;
        timeCount += Time.deltaTime;

        if (seconds > 0)
        {
            if (seconds > 0 && seconds < 10)
            {
                //gameTime.text = minutues.ToString("F0") + ":0" + seconds.ToString("F0");
            }

            if (seconds > 9)
            {
                //gameTime.text = minutues.ToString("F0") + ":" + seconds.ToString("F0");
            }
            

            if (seconds > 59)
            {
                minutues++;
                seconds = 0;
            }
        }
    }
}
