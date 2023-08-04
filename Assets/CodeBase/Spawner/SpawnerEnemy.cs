using System;
using System.Collections;
using CodeBase.CharacterEnemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Spawner
{
    public class SpawnerEnemy:MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform _pointsMove;
        [SerializeField] private float _startTimeOfCreation;
        [SerializeField] private float _repeatingCreationTime;
        [SerializeField] private int _maxNumberOfEnemy = 1;
        
        private int _numberOfEnemy = 0;

        private void Start()
        {
            InvokeRepeating(nameof(CreateEnemies),_startTimeOfCreation,_repeatingCreationTime);
        }

        private void Update()
        {
            if (_numberOfEnemy == _maxNumberOfEnemy) 
                CancelInvoke(nameof(CreateEnemies));
        }
        
        private void CreateEnemies()
        {
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.AddArrayOfMovementPoints(_pointsMove.GetComponentsInChildren<Transform>());
            enemy.transform.parent = transform;
            _numberOfEnemy++;
        }
    }
}