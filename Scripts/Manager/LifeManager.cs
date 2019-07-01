using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

    public GameObject[] lifes;

    private Color ColorAfterDmg;

    private void Awake ()
    {
        ColorAfterDmg = new Color(1,1,1, 0.6274509803921569f);
    }

    private void Update ()
    {
        switch(Player.playerHealth)
        {
            case 3:
                break;
            case 2:
                SetLifesGrey(lifes, 2);
                break;
            case 1:
                SetLifesGrey(lifes, 1);
                break;
            case 0:
                SetLifesGrey(lifes, 0);
                break;
        }
    }

    private void SetLifesGrey (GameObject[] lifes, int lifeIndex)
    {
        for(int i = lifeIndex; i < lifes.Length; i++)
        {
            lifes[i].GetComponent<SpriteRenderer>().color = ColorAfterDmg;
        }
    }
}
