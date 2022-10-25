using System.Collections;
using UnityEngine;

public class PointTextSpawner : MonoBehaviour
{
   [SerializeField] private PointText _scoreText;
   [SerializeField] private Player _player;
   [SerializeField] private Vector3 _offset;

   private void OnEnable()
   {
      _player.NeedPointUpdate += Spawn;
   }
   private void OnDisable()
   {
      _player.NeedPointUpdate -= Spawn;
   }

   private void Spawn(ScoreType scoreType)
   {
      var scoreText = Instantiate(_scoreText, _player.transform.position + _offset, Quaternion.identity);
      scoreText.SetPoint((int)scoreType);
      scoreText.SetSpeed(_player.CurrentSpeed);
   }
}
