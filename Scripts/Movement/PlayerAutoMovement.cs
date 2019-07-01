using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAutoMovement : MonoBehaviour
{
    public Transform boatTransform;
    public GameObject virtualJoystickImage;
    public GameObject shootJoystickImage;

    public float moveSpeed = 0.5f;
    private bool endPointFound = false;
    
    private Vector2 endPointTarget = new Vector2(-3, 0);
       

    private void Update ()
    {
        //Zapnutí funkce která provede animaci pohybu
        StartGameMoveAnimation();

        //Konec animace
        if (endPointFound)
        {
            //Vypnutí automatického pohybu, zapnutí manuálního,
            //a pozapínání ostatních objeků
            GetComponent<PlayerAutoMovement>().enabled = false;

            virtualJoystickImage.SetActive(true);
            shootJoystickImage.SetActive(true);
            GetComponent<PlayerTouchMovement>().enabled = true;
        }
    }
    
    private void StartGameMoveAnimation ()
    {
        //Aktualizování pozice hráče
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), endPointTarget, moveSpeed * Time.deltaTime);

        //Pokud se hráč dostane na potřebné místo, přepne se proměnná na true  
        if ((Vector2)transform.position == endPointTarget)
        {
            endPointFound = true;
        }
    }
}

