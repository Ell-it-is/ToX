using UnityEngine;
using System.Collections;

public class PlayerTouchMovement : MonoBehaviour {

    public float moveSpeed = 1.5f;

    //Reference na script joystick
    public JoystickMove joystick;
        
    private float xValue;

    private void Update () {
        //Pohyb ve směru, který získáme ze souřadnic joysticku
        Vector3 move = new Vector3(joystick.Horizontal(), joystick.Vertical(), 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        //Spawn at same position if player goes away of screen
        //x
        if (transform.position.x < -5.3f)
        {
            SetNewPos(-5.3f, "x");
        }
        if (transform.position.x > 5.3f)
        {
            SetNewPos(5.3f, "x");
        }

        //y
        if (transform.position.y > 1.5f)
        {
            SetNewPos(1.5f, "y");
        }
        if (transform.position.y < -2.8f)
        {
            SetNewPos(-2.8f, "y");
        } 
    }

    private void SetNewPos (float value, string xORy)
    {
        Vector2 newPos = transform.position;
        if (xORy == "x")
            newPos.x = value;
        if (xORy == "y")
            newPos.y = value;
        transform.position = newPos;
    }
}
