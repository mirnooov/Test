using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishDetect : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private StartPoint _startPoint;
   
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>(); 
        if (player)
        {
           _winPanel.gameObject.SetActive(true);
           _levelText.gameObject.SetActive(false);
           _scoreText.gameObject.SetActive(false);
           _startPoint.EnableFinishCamera();
           _player.StopGame();
        }
    }
}
