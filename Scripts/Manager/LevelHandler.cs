using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

    private static LevelHandler instance;

    public GUITexture overlay;
    public float fadeTime;
    public Canvas canvas;

    public static LevelHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<LevelHandler>();
            }
            return instance;
        }
    }

    private void Awake ()
    {
        //Cover the whole screen in any situation
        overlay.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        StartCoroutine(FadeToClear()); 
    }

    private IEnumerator FadeToClear()
    {
        overlay.gameObject.SetActive(true);
        CanvasForMenu(false);
        overlay.color = Color.black;

        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.black, Color.clear, progress);

            progress += rate * Time.deltaTime;

            yield return null;
        }

        overlay.color = Color.clear;
        CanvasForMenu(true);
        overlay.gameObject.SetActive(false);
    }

    private IEnumerator FadeToBlack(Action levelMethod)
    {
        overlay.gameObject.SetActive(true);
        CanvasForMenu(false);
        overlay.color = Color.clear;

        float rate = 1.0f / fadeTime;
        float progress = 0.0f;

        while(progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.clear, Color.black, progress);

            progress += rate * Time.deltaTime;

            yield return null;
        }

        overlay.color = Color.black;

        levelMethod();
    }

    private void CanvasForMenu(bool decision)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            canvas.enabled = decision;
        }
    }

    public void NextLevel()
    {
        StartCoroutine(FadeToBlack(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)));
        GameMaster.Play = false;
    }
}
