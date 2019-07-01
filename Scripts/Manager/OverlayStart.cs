using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverlayStart : MonoBehaviour {

    public Renderer Stats;            //Staty
    public Renderer[] Lives;
    public Text MoveLengthText;

    public Button Anchor;           //Pauza
    public Button UpgradeAmmo;

    public Image[] ActiveSkills;    //Skilly
    public Image[] OnLoadSkills;

    private bool startGame = false;
    private bool loadMore = false;
    private bool stopUpdating = false;


    private void Start ()
    {
        StartCoroutine(WakeUp(2));
    }

    private void Update ()
    {
        if (!stopUpdating && startGame)
        {
            LoadStats();

            if (!loadMore)
            {
                StartCoroutine(Wait(3));
            }

            if (loadMore)
            {
                LoadAnchorAndAmmo();
                LoadSkills();
            }
            
            if (GameTimer.timeCount > 7)
            {
                stopUpdating = true;
            }
        }
    }

    private IEnumerator WakeUp (float time)
    {
        yield return new WaitForSeconds(time);     
        startGame = true;
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        loadMore = true;
    }

    private void LoadStats ()
    {
        //Stats
        Color color = Stats.GetComponent<SpriteRenderer>().color;
        color.a += 0.01f;
        Stats.GetComponent<SpriteRenderer>().color = color;

        //Životy
        foreach (Renderer live in Lives)
        {
            Color color1 = live.GetComponent<SpriteRenderer>().color;
            color1.a += 0.01f;
            live.GetComponent<SpriteRenderer>().color = color1;
        }

        //Move Length Text
        color.a += 0.01f;
        MoveLengthText.GetComponent<Text>().color = color;

        if (MoveLengthText.GetComponent<Text>().color.a > 254)
        {
            loadMore = true;
        }
    }

    private void LoadAnchorAndAmmo ()
    {
        if (Anchor.GetComponent<Image>().color.a < 256)
        {
            Color color = Anchor.GetComponent<Image>().color;
            color.a += 0.01f;
            Anchor.GetComponent<Image>().color = color;
        }

        if (UpgradeAmmo.GetComponent<Image>().color.a < 256)
        {
            Color color = UpgradeAmmo.GetComponent<Image>().color;
            color.a += 0.01f;
            UpgradeAmmo.GetComponent<Image>().color = color;
        }
    }

    private void LoadSkills ()
    {
        foreach (Image skill in ActiveSkills)
        {
            Color color = skill.GetComponent<Image>().color;
            color.a += 0.01f;
            skill.GetComponent<Image>().color = color;
        }

        foreach (Image skill in OnLoadSkills)
        {
            Color color = skill.GetComponent<Image>().color;
            color.a += 0.01f;
            skill.GetComponent<Image>().color = color;
        }
    }
}
