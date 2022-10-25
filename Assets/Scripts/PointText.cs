using System.Collections;
using TMPro;
using UnityEngine;

public class PointText : MonoBehaviour
{
    [SerializeField] private TextMeshPro _scoreText;
    [SerializeField] private float _speedUp;
    [SerializeField] private float _timeLife;

    private float _speedForward;
    
    private void OnEnable()
    {
       StartCoroutine(DestroyAfter(_timeLife));
    }

    public void SetSpeed(float speed)
    {
        _speedForward = speed;
    }
    
    private void Update()
    {
        var position = transform.position;
        position =
            Vector3.MoveTowards(position, position + Vector3.up, _speedUp * Time.deltaTime);
        position =
            Vector3.MoveTowards(position, position + Vector3.forward, _speedForward * Time.deltaTime);
        transform.position = position;
    }

    public void SetPoint(int point)
    {
        _scoreText.text = point.ToString();
    }

    private IEnumerator DestroyAfter(float timeLife)
    {
        yield return new WaitForSeconds(timeLife);
        Destroy(gameObject);
    }

}
