using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BcManager : MonoBehaviour {

    public Transform[] baseBackgrounds;
    public Transform[] usableBackground;
    public Transform[] adds;
    public GameObject sun;

    private List<Transform> activeBackgrounds;
    private Transform activeBC;

    public static float moveSpeed = 0.02f;

    private bool createFirst = true;
    private bool createAnother = false;
    private bool chooseBC = true;

    private bool gameStarted = true;

    /* Použíté proměnné
    * ... 
    */

    private void Start ()
    {
        //založení instance nového listu
        activeBackgrounds = new List<Transform>();
    }

    private void Update () {

        //Pokud se hráč dostane k místě s Bossem, vypne pozadí a image sun 
        if (WayLength.startBoss)
        {
            GetComponent<BcManager>().enabled = false;
            sun.SetActive(false);
        }

        //Program čeká na provedení prvotní animace
        if (gameStarted)
        {
            StartCoroutine(WaitForStart());
        }
        //Prvotní animace dokončena
        else
        {   
            //Posunuje prvotní pozadí s pískem, dokud nedorazí na x-ovou souřadnici -30
            if (baseBackgrounds[0].position.x > -30)
            {
                MoveBaseBC();
            }

            //Vytvoří první nové pozadí a vloží ho do listu aktivních
            if (baseBackgrounds[1].position.x < 0 && createFirst)
            {
                CreateFirst();
            }

            //Pokud je aktivní pozadí prázdné a bool proměnná createAnother je možná, vytvoří nové
            if (activeBC != null)
            {
                if (activeBC.position.x < 0 && createAnother)
                {
                    CreateAnother();
                }
            }

            //Posun ostatních objektů jako slunce a krab
            MoveAdds();
            //Posun aktivních pozadí
            MoveActive();
        }
	}

    /* Použíté funkce
     * ... 
     */

    private IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(2);
        gameStarted = false;
    }

    private void MoveAdds()
    {
        foreach (Transform add in adds)
        {
            Vector3 move = add.position;
            move.x -= 0.03f;
            add.position = move;
        }
    }

    private void MoveBaseBC()
    {
        foreach (Transform b in baseBackgrounds)
        {
            Vector3 move = b.position;
            move.x -= moveSpeed;
            b.position = move;
        }
    }

    private void MoveActive()
    {
        //Posuň
        foreach (Transform b in activeBackgrounds)
        {
            Vector3 move = b.position;
            move.x -= moveSpeed;
            b.position = move;
        }

        //Zastav pokud jsou za hranicí viditelnosti
        for (int i = 0; i < activeBackgrounds.Count; i++)
        {
            if (activeBackgrounds[i].position.x < -20)
            {
                activeBackgrounds.Remove(activeBackgrounds[i]);
            }
        }

        if (activeBC != null)
        {
            if (activeBC.position.x < 0)
            {
                createAnother = true;
            }
        }
    }

    private void CreateFirst()
    {
        Transform firstBC = (Transform)Instantiate(usableBackground[1], usableBackground[1].position, usableBackground[1].rotation);
        activeBC = firstBC;
        activeBackgrounds.Add(firstBC);
        createFirst = false;
    }

    private void CreateAnother()
    {
        if (chooseBC)
        {
            Transform anotherBC = (Transform)Instantiate(usableBackground[0], usableBackground[0].position, usableBackground[0].rotation);
            activeBC = anotherBC;
            activeBackgrounds.Add(anotherBC);
            chooseBC = false;
        }
        else if (!chooseBC)
        {
            Transform anotherBC = (Transform)Instantiate(usableBackground[1], usableBackground[1].position, usableBackground[1].rotation);
            activeBC = anotherBC;
            activeBackgrounds.Add(anotherBC);
            chooseBC = true;
        }

        createAnother = false;
    }
}
