using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnter;
    [SerializeField] private UnityEvent _onExit;
    [SerializeField] private int _membersSortingOrder;

    public int MembersSortingOrder => _membersSortingOrder;

    public void Enter()
    {
        _onEnter?.Invoke();
    }

    public void Exit()
    {
        _onExit?.Invoke();
    }
}
