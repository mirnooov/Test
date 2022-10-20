using UnityEngine;
using Random = UnityEngine.Random;

public class DetectCubeOnObstacles : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DetectCubeOnPlayer>(out var detectCubeOnPlayer))
        {
            EnableRigidbody();
            detectCubeOnPlayer.InvokeDetectEvent();
        }
        
    }

    private void EnableRigidbody()
    {
        _boxCollider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        Vector3 force = new Vector3(0, 0, Random.Range(-1, 2));
        force.z = force == Vector3.zero ? force.z = -1 : force.z;
        _rigidbody.AddForce(force * 150);
    }
}
