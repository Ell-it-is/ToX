using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public Transform anchor;
    public static bool gamePaused = false;

    //Pause Screen
    public GameObject pauseScreen;
    public GameObject[] pauseBtns;
    public GameObject shadowBox;

    private void Start ()
    {
        PreClickChanges();
    }

    private void Update ()
    {
        if (gamePaused)
        {
            Time.timeScale = 0;
            //Pozastavení posuvného pozadí
            BcManager.moveSpeed = 0;

            //Změny jako velikost kotvy a další...
            AfterClickChanges();
        }
        else if (!gamePaused)
        {
            Time.timeScale = 1;
            BcManager.moveSpeed = 0.02f;

            PreClickChanges();
        }
    }

    public void BtnPause ()
    {   
        gamePaused = !gamePaused;
    }

    private void AfterClickChanges ()
    {
        //Pozice
        Vector2 newPos = anchor.transform.position;
        newPos.x = Screen.width / 0.96f;
        newPos.y = Screen.height / 1.2f;
        anchor.transform.position = newPos;

        //Velikost
        Vector2 newScale = anchor.transform.localScale;
        newScale.x = 2;
        newScale.y = 2;
        anchor.transform.localScale = newScale;

        //Pause Screen
        //pauseScreen.SetActive(true);
        //shadowBox.SetActive(true);

        /*Buttons
        foreach (GameObject btn in pauseBtns)
        {
            btn.SetActive(true);
        }*/
    }

    private void PreClickChanges()
    {
        //Pozice
        Vector2 newPos = anchor.transform.position;
        newPos.x = Screen.width / 0.96f;
        newPos.y = Screen.height / 1.2f;
        anchor.transform.position = newPos;

        //Velikost
        Vector2 newScale = anchor.transform.localScale;
        newScale.x = 1.6f;
        newScale.y = 1.6f;
        anchor.transform.localScale = newScale;

        //Pause Screen
        //pauseScreen.SetActive(false);
        //shadowBox.SetActive(false);

        /*Buttons
        foreach (GameObject btn in pauseBtns)
        {
            btn.SetActive(false);
        }*/
    }
}
