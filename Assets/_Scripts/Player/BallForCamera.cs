using Root.Assets._Scripts.Game;
using UnityEngine;

namespace Root.Assets._Scripts.Player
{
    public class BallForCamera : MonoBehaviour
    {
        [SerializeField] private GameLevelBuilder _generator;
        [SerializeField] private Ball _ball;
        private float[] _coordinatePoint;
        private int _currentPoint;
        private Vector3 _currentPosition;

        private void Start()
        {
            _currentPoint = _generator.CountContainers + 1;
            _coordinatePoint = new float[_currentPoint];
            for (int i = 0; i < _currentPoint; i++)
            {
                _coordinatePoint[i] = (i + 1) * _generator.OffsetBetweenContainers;
            }
            _currentPosition = new Vector3(0, _coordinatePoint[_currentPoint - 1], 0);
            transform.position = _currentPosition;
        }

        private void OnEnable()
        {
            _ball.OnPassing += ChangePositon;
        }

        private void OnDisable()
        {
            _ball.OnPassing -= ChangePositon;
        }

        private void ChangePositon()
        {
            if (_currentPoint > 0)
            {
                _currentPosition.y = _coordinatePoint[_currentPoint - 1];
                transform.position = _currentPosition;
                _currentPoint--;
            }
        }
    }
}