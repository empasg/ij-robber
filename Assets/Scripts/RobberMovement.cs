using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RobberMovement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _sortingOrder;
    private bool _inHouse;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveInOutHouse(House house)
    {
        if (_inHouse == false)
        {
            _sortingOrder = _spriteRenderer.sortingOrder;
            _spriteRenderer.sortingOrder = house.MembersSortingOrder;

            house.Enter();
        }
        else
        {
            _spriteRenderer.sortingOrder = _sortingOrder;

            house.Exit();
        }

        _inHouse = !_inHouse;
    }
}
