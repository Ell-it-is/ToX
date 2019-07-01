using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeCrossBow : MonoBehaviour {

    public GameObject crossbow2;
    private bool active = false;    

    private void Start()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        if (WayLength.length >= 1500)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        if (WayLength.length > 1500 && active)
        {
            crossbow2.SetActive(true);
        }
    }

    public void ActiveCrossbow()
    {
        active = true;
    }
}
