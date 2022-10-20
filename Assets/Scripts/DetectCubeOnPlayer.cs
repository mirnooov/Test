using System;
using UnityEngine;

public class DetectCubeOnPlayer : MonoBehaviour
{
   public Action DetectEvent;

   public void InvokeDetectEvent()
   {
       DetectEvent?.Invoke();
   }
}
