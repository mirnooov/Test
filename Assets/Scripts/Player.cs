using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TriggerCubesHolder _triggerCubesHolder;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private int _sensevity = 100;

    private bool _isStop;
    private bool _canStart;
    private bool _mistake;
    private float _currentSpeed;
    private Vector3 _startMousePosition;
    private Coroutine _coroutine; 
    private const float MINDISTANCESWIPE = 0.1f;
  
    public bool Mistake
{
    get => _mistake;
    set => _mistake = value;
}
    private bool IsStop
    {
        get => _isStop;
        set
        {
            if(value && _isStop == false)
                NeedPointUpdate?.Invoke(ScoreType.Mistake);
            _isStop = value;
        }
    }
    public Action<ScoreType> NeedPointUpdate;
    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _currentSpeed = _defaultSpeed;
    }
    private void OnEnable()
    {
        _triggerCubesHolder.DetectEvent += Stop;
    }
    private void OnDisable()
    {
        _triggerCubesHolder.DetectEvent -= Stop;
    }
    private void Update()
    {
        if (_canStart == false)
            return;
        
        if (Input.GetMouseButtonDown(0))
            _startMousePosition = Input.mousePosition;
        
        if (Input.GetMouseButton(0))
        {
            var distance = Vector3.Distance(_startMousePosition,Input.mousePosition);
            if (distance > MINDISTANCESWIPE)
            {
                transform.Rotate(0, -(Input.GetAxis("Mouse X") * (_sensevity * Time.deltaTime)), 0);
                _currentSpeed = _defaultSpeed;
            }
            else if (!IsStop)
            {
                _currentSpeed = _defaultSpeed * 5;
                _coroutine ??= StartCoroutine(NeedPointUpdateCoroutine(0.1f));
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            CheckAngles();
            _currentSpeed = _defaultSpeed;
        }
        Move(IsStop ? Vector3.back : Vector3.forward);
    }

    public void StartGame()
    {
        _canStart = true;
    }
    public void StopGame()
    {
        _canStart = false;
    }
    
    private void CheckAngles()
        {
            var rotation = transform.rotation;
            switch (rotation.eulerAngles.y)
            {
                case >= 0 and < 45:
                    rotation.eulerAngles = new Vector3(0f, 0f, 0f);
                    break;
                case >= 45 and < 90:
                case >= 90 and < 135:
                    rotation.eulerAngles = new Vector3(0f, 90f, 0f);
                    break;
                case >= 135 and < 180:
                case >= 180 and < 225:
                    rotation.eulerAngles = new Vector3(0f, 180f, 0f);
                    break;
                case >= 225 and < 270:
                case >= 270 and < 315:
                    rotation.eulerAngles = new Vector3(0f, 270f, 0f);
                    break;
                case >= 315 and < 360:
                    rotation.eulerAngles = new Vector3(0f, 360f, 0f);
                    break;
            }
    
            transform.rotation = rotation;
        }
    private void Move(Vector3 direction)
    {
        transform.position = 
            Vector3.MoveTowards(transform.position, transform.position + direction, _currentSpeed * Time.deltaTime);
    }
    private void Stop()
    { 
        _mistake = true;
        StartCoroutine(StopCoroutine(1f));
    }
    private IEnumerator StopCoroutine(float delay)
    {
        IsStop = true;
        _currentSpeed = _defaultSpeed;
        yield return new WaitForSeconds(delay);
        IsStop = false;
    } 
    private IEnumerator NeedPointUpdateCoroutine(float delay)
         {
             NeedPointUpdate?.Invoke(ScoreType.Acceleration);
             yield return new WaitForSeconds(delay);
             _coroutine = null;
         }
}