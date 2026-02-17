using UnityEngine;
using UnityEngine.EventSystems;

public class RoomController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.onLocationSelected.Invoke(eventData.pointerPressRaycast.worldPosition, null);
    }
}
