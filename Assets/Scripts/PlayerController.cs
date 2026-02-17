using System;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    
    [SerializeField, Tooltip("This is inverse, smaller number is faster")] private float moveSpeed;
    [SerializeField] private Animator anim;

    private void OnEnable()
    {
        GameManager.Instance.onLocationSelected.AddListener(MovePlayer);
    }

    private void OnDisable()
    {
        GameManager.Instance.onLocationSelected.RemoveListener(MovePlayer);
    }

    private void MovePlayer(Vector2 location, Interactable interactable)
    {
        anim.SetBool(IsWalking, true);
        transform.DOMove(location, moveSpeed).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                anim.SetBool(IsWalking, false);

                if (interactable != null)
                {
                    interactable.Interact();
                }
            });
    }
}