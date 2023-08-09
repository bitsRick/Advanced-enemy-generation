using System;
using System.Collections;
using CodeBase.CharacterEnemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Spawner
{
    public class SpawnerEnemy:EnemyPool
    {
        [SerializeField] private GameObject _enemy;
        [SerializeField] private Transform _pointsMove;
        [SerializeField] private float _startTimeOfCreation;

        private float _timeCreation;

        private void Start()
        {
            Initilization(_enemy);
        }

        private void Update()
        {
            _timeCreation += Time.deltaTime;
            
            if (_timeCreation > _startTimeOfCreation)
            {
                _timeCreation = 0;

                if (TryGetEnemy(out GameObject enemy))
                {
                    SetSpawnEnemy(enemy);
                }
            }
        }
        
        private void SetSpawnEnemy(GameObject enemy)
        {
            enemy.transform.position = transform.position;
            enemy.GetComponent<Enemy>().AddArrayOfMovementPoints(_pointsMove.GetComponentsInChildren<Transform>());
            enemy.SetActive(true);
        }
    }
}