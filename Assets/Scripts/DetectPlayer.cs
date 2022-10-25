using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private BorderCube[] _borderCubes;
    [SerializeField] private Image _imageX2;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>(); 
        
        if (player)
        {
            if (player.Mistake)
            {
                player.NeedPointUpdate?.Invoke(ScoreType.CompletedObstacles);
            }
            else
            {
                player.NeedPointUpdate?.Invoke(ScoreType.PerfectCompleted);
                StartCoroutine(StartX2());
            }
            
            player.Mistake = false;
            
            foreach (var borderCube in _borderCubes)
                borderCube.PlayParticles();
        }
    }

    private IEnumerator StartX2()
    {
        _imageX2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _imageX2.gameObject.SetActive(false);
    }
}
