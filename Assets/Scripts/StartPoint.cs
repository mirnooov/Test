using System;
using Cinemachine;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _previewCamera;
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;
    [SerializeField] private Player _player;

    public void StartGame()
    {
        _player.StartGame();
        _followCamera.gameObject.SetActive(true);
        _previewCamera.gameObject.SetActive(false);
    }

    public void EnableFinishCamera()
    {
        _followCamera.gameObject.SetActive(false);
        _previewCamera.gameObject.SetActive(false);
        _finishCamera.gameObject.SetActive(true);
    }
}
