using System;
using UnityEngine;

public class TriggerCubesHolder : MonoBehaviour
{
   [SerializeField] private DetectCubeOnPlayer[] _detectCubeOnPlayers;

   public Action DetectEvent;

   public void Start() => Init();

   private void OnDetect()
   {
      DetectEvent?.Invoke();
   } 
   private void Init()
   {
      foreach (var detectCubeOnPlayer in _detectCubeOnPlayers)
      {
         detectCubeOnPlayer.DetectEvent += OnDetect;
      }
   }
   
}
