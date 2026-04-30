using UnityEngine;
using UnityEngine.EventSystems;

public class FastClickButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("méga prout qui pue");
    }
}
