using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour {

    private static FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("DamageCanvas");
        popupText = Resources.Load<FloatingText>("Prefabs/TextParent");
    }

    public static void CreateFloatingText(string _text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f, .5f), location.position.y + Random.Range(-.5f, .5f)));

        instance.transform.SetParent(canvas.transform);
        instance.transform.position = screenPosition;
        instance.SetText(_text);
    }
}
