using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public Vector2 playerInteractLocation;
    [SerializeField] private string interactionText;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.onLocationSelected.Invoke((Vector2)transform.position + playerInteractLocation, this);
    }

    public virtual void Interact()
    {
        print(interactionText);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.darkGreen;
        Gizmos.DrawSphere((Vector2)transform.position + playerInteractLocation, 0.5f);
    }
}
