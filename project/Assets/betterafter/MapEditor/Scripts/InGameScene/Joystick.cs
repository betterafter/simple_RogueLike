using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Canvas canvas;
    public Image handle;
    public Image outLine;

    private Vector3 input = Vector3.zero;
    

    public float Horizontal { get { return input.x; } }
    public float Vertical { get { return input.y; } }

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = GetComponent<Image>();
        handle = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    private Vector3 inputVector;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(outLine.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / outLine.rectTransform.sizeDelta.x);
            pos.y = (pos.y / outLine.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            handle.rectTransform.anchoredPosition
                = new Vector3(inputVector.x * (outLine.rectTransform.sizeDelta.x / 3), inputVector.y * (outLine.rectTransform.sizeDelta.y) / 3);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.rectTransform.anchoredPosition = Vector2.zero;

    }
}