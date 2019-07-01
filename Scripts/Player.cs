using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static GameObject player;
    public GameObject wonGameImage;

    //Staty
    public static int playerHealth = 3;

    //Rozhodování
    public static bool isGameOver = false;
    public static bool isGameWon = false;
    private bool gameEnd = true;
    private bool resetAll = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            GameOver();
        }

        if (isGameWon == true)
        {
            GameWon();
        }
    }

    private void GameOver()
    {
        GameMaster.canShowLoseText = true;
        SceneManager.LoadScene(0);
    }

    private void GameWon()
    {
        wonGameImage.SetActive(true);
        if (gameEnd)
        {
            StartCoroutine(WaitForEnd(4));
        }
        
        if (resetAll)
        {
            ResetAllStaticVars();
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator WaitForEnd(float waitTime)
    {
        gameEnd = false;
        yield return new WaitForSeconds(waitTime);
        resetAll = true;
    }

    private void ResetAllStaticVars()
    {
        JoystickMove.isMoving = false;
        JoystickShoot.isMoving = false;
        Joystick.isMoving = false;
        BcManager.moveSpeed = 0.02f;
        jellyFishMove.moveSpeed = 2;
        Enemy.isBoss = false;
        GameTimer.timeCount = 0;
        WayLength.length = 1200;
        WayLength.newLength = 0.2f;
        WayLength.startBoss = false;
        FishSpawn.fishCountInGame = 0;
        FishSpawn.maxFishCountInGame = 5;
        FishSpawn.repeatSpawn = 1f;
        PauseGame.gamePaused = false;
        Player.playerHealth = 3;
        Player.isGameOver = false;
        Player.isGameWon = false;
    }
}
