using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreFinishText;

    private int _points;

    private void OnEnable()
    {
        _player.NeedPointUpdate += OnUpdatePoint;
    }

    private void OnUpdatePoint(ScoreType scoreType)
    {
        _points += (int)scoreType;
        if (_points < 0)
            _points = 0;
        _scoreText.text = "Score: " + _points;
        _scoreFinishText.text = "+ " + _points;
    }
}
public enum ScoreType 
{
    Acceleration = 10,
    CompletedObstacles = 100,
    PerfectCompleted = 200,
    Mistake = -100
}