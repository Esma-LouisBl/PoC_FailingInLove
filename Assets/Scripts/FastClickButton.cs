using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class FastClickButton : MonoBehaviour, IPointerDownHandler
{
    [Serializable]
    public class ButtonPressedEvent : UnityEvent {}
    [SerializeField]
    private ButtonPressedEvent m_OnPressed = new ButtonPressedEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        m_OnPressed.Invoke();
    }
}
