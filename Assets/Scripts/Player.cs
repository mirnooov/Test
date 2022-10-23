using System;
using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TriggerCubesHolder _triggerCubesHolder;
    [SerializeField] private float _speed;
    [SerializeField] private int _sensevity = 100;

    private bool _isStop;

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
        if (Input.GetMouseButton(0))
            transform.Rotate(0,-(Input.GetAxis("Mouse X") * _sensevity), 0);

        if (Input.GetMouseButtonUp(0))
            CheckAngles();
        
        Move(_isStop ? Vector3.back : Vector3.forward);
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


