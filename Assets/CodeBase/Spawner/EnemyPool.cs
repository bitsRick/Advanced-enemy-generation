using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Spawner
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capEnemy;

        private List<GameObject> _enemy = new List<GameObject>();

        protected void Initilization(GameObject template)
        {
            for (int i = 0; i < _capEnemy; i++)
            {
                GameObject enemy = Instantiate(template, _container.transform);
                enemy.SetActive(false);
                _enemy.Add(enemy);
            }
        }

        protected bool TryGetEnemy(out GameObject enemy)
        {
            enemy = _enemy.FirstOrDefault(p => p.activeSelf == false);

            return enemy != null;
        }
    }
}