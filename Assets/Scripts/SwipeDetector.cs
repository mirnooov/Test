using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private float _swipeDistance;

    private Vector2 _currentMousePosition => Input.mousePosition;
    private Vector2 _startMousePosition;
    private SwipeType _swipeType;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startMousePosition == Vector2.zero)
                _startMousePosition = Input.mousePosition;
        }

        if (_startMousePosition != Vector2.zero)
        {
            var distance = _startMousePosition.x - _currentMousePosition.x;
            if (Mathf.Abs(distance) >= _swipeDistance)
            {
                _swipeType = Mathf.Sign(distance) > 0 ? SwipeType.Left : SwipeType.Right;
                _startMousePosition = Vector2.zero;
            }
        }
    }

    public SwipeType GetSwipe()
    {
        var swipeType = _swipeType;
        _swipeType = SwipeType.None;
        return swipeType;
    }
}

public enum SwipeType
{
    None,
    Left,
    Right
}