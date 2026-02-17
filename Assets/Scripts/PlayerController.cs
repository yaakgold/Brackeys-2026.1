using System;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("This is inverse, smaller number is faster")] private float moveSpeed;

    private void OnEnable()
    {
        GameManager.Instance.onLocationSelected.AddListener(MovePlayer);
    }

    private void OnDisable()
    {
        GameManager.Instance.onLocationSelected.RemoveListener(MovePlayer);
    }

    private void MovePlayer(Vector2 location)
    {
        transform.DOMove(location, moveSpeed).SetEase(Ease.Linear);
    }
}