using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBarRect;

    private void Start()
    {
        if (healthBarRect == null)
        {
            Debug.Log("Objekt health bar nenalezen.");
        }
    }

    public void SetHeath(int _cur, int _max)
    {
        float _value = (float)_cur / _max;  //Hodnota mezi 0 - 1

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);         
    }
}
