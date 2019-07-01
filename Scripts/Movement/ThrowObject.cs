using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThrowObject : MonoBehaviour
{
    //Instance
    public GameObject harpoonPrefab;
    public Transform harpoonFirePoint1;
    public JoystickShoot joystick;

    //Pozice
    public Transform playerPos;

    private bool canShootNew = true;
    private bool canCallFnc = true;

    private void Update()
    {
        Shoot();

        if (canCallFnc && !canShootNew)
        {
            StartCoroutine(WaitForNewShoot(0.15f));
        }
    }

    private IEnumerator WaitForNewShoot (float waitTime)
    {

        canCallFnc = false;
        yield return new WaitForSeconds(waitTime);
        canCallFnc = true;
        canShootNew = true;
    }

    private void Shoot()
    {
        //if (!EventSystem.current.IsPointerOverGameO   bject()) //Zamezuje UI aktivovat zároveň s vystřelením
        //Pokud je hnuto s joystickem, je mozno vystřelit další a hra není pozastavena
        if (JoystickShoot.isMoving && canShootNew && !PauseGame.gamePaused)
        {
            //Do proměnné t se uloží info o elementu Transform, objektu harpuny
            Transform t = harpoonPrefab.GetComponent<Transform>();
            //Přidělena rotace v závislosti na směru joysticku
            t.rotation = Quaternion.FromToRotation(Vector3.right, new Vector3(joystick.Horizontal(), joystick.Vertical(), 0));

            //Vytvoření nového objektu harpuny a zamezení okamžitému vystřelení další harpuny
            Instantiate(harpoonPrefab, harpoonFirePoint1.position, t.rotation);
            canShootNew = false;
        }
    }
} 
    