using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class JoystickShoot : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static bool isMoving = false;

    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();  //Získání komponentu obrázku z podřazeného objektu 
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        //Pokud jsme se dotkly touchpadu...
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,
                                                                    ped.position,
                                                                    ped.pressEventCamera,
                                                                    out pos))
        {
            //Najdi pozici myši
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 1f + 1, 0, pos.y * 1f - 1);
            inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

            //Posuň obrázek joysticku               
            joystickImg.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 8f),
                            inputVector.z * (bgImg.rectTransform.sizeDelta.y / 8f));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        isMoving = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        isMoving = false;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }

}