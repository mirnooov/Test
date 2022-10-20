using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TriggerCubesHolder _triggerCubesHolder;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _backDirection;
    [SerializeField] private SwipeDetector _swipeDetector;
    
    private Vector3 _direction;
    private bool _isStop;


    private void OnEnable()
    {
        _triggerCubesHolder.DetectEvent += Stop;
    }

    private void FixedUpdate()
    {
        SetDirection(_isStop ? _backDirection : new Vector3(0,0,1));

        Move(_direction);
        Rotate(_swipeDetector.GetSwipe());
    }

    private void Rotate(SwipeType swipe)
    {
        if (swipe == SwipeType.None)
            return;
        if(swipe == SwipeType.Left)
            transform.Rotate(new Vector3(0, -90, 0));
        if(swipe == SwipeType.Right)
            transform.Rotate(new Vector3(0, 90, 0));
    }

    private void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Move(Vector3 direction)
    {
        transform.position = 
            Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
    }

    private void Stop()
    {
        StartCoroutine(StopCoroutine(1f));
    }

    private IEnumerator StopCoroutine(float delay)
    {
        _isStop = true;
        yield return new WaitForSeconds(delay);
        _isStop = false;
    }
}
