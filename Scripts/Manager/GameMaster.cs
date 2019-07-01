using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static bool Play = true;
    public static bool canShowLoseText = false;

    public Button startGame;
    public Text loseText;

    private void Update()
    {
        if (!Play)
        {
            startGame.interactable = false;
            if (canShowLoseText)
            {
                loseText.GetComponent<Text>().text = "You have lost.";
            }
        }
    }
}
