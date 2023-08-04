using System;
using UnityEngine;

namespace CodeBase.CharacterEnemy
{
    public class Movement:MonoBehaviour
    {
        private const int IndexFirstPositionPoint = 1;
        private const float MinimumDistance = 0.1f;
        
        [SerializeField] private float _speed;

        private Transform[] _points;
        private Transform _nextPosition;
        private int _targetLenght = IndexFirstPositionPoint;

        private void Update()
        {
            Move(_speed);
        }

        public void SetArrayOfPoints(Transform[] points)
        {
            _points = points;
            _nextPosition = _points[_targetLenght];
        }

        private void Move(float speed)
        {
            if (Vector2.Distance(_nextPosition.position, transform.position) > MinimumDistance)
            {
                transform.transform.position = Vector2.MoveTowards(
                    transform.transform.position,
                    _nextPosition.position,
                    speed * Time.deltaTime);
            }
            else
            {
                if (TryGetEndPosition())
                    Destroy(gameObject);
            }
        }

        private bool TryGetEndPosition()
        {
            if (_targetLenght < _points.Length && CheckPointTargetLength())
            {
                _targetLenght++;
                _nextPosition = _points[_targetLenght];
                return false;
            }

            return true;
        }

        private bool CheckPointTargetLength()
        {
            int lenghtValue = 1;
            return _targetLenght + lenghtValue != _points.Length;
        }
    }
}