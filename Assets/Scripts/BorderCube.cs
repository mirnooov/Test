using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCube : MonoBehaviour
{
   [SerializeField] private ParticleSystem _particleSystem;

   public void PlayParticles()
   {
      _particleSystem?.Play();
   }
}
