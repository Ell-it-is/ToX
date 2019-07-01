using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour {

    //Scripts
    public Rockets rockets;

    public List<Skill> skills;

    private void Start ()
    {
        //Zamezí protočení skillu při startu hry.
        skills[0].currentCooldown = skills[0].cooldown + 0.5f;
    }

    private void Update ()
    {
        //Input.GetTouch(0).phase == TouchPhase.Stationary
        if (Input.GetKey(KeyCode.Q) && !PauseGame.gamePaused)
        {   
            //Pokud je skill k dispozici, proveď ho.
            if (skills[0].currentCooldown >= skills[0].cooldown)
            {
                rockets.SendMessageToRockets();
                skills[0].currentCooldown = 0;
            }
        }

        foreach (Skill s in skills)
        {
            //Pokud skill není k dispozici, sniž zbývající dobu (zvyš current cd)
            if (s.currentCooldown < s.cooldown)       
            {
                s.currentCooldown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCooldown / s.cooldown;
            }
        }
    }
}

[System.Serializable]
public class Skill
{ 
    public float cooldown;          //total cooldown of the skill
    public Image skillIcon;
    [HideInInspector]
    public float currentCooldown;   //time for new use
}
