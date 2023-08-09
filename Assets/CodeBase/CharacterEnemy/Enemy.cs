using System;
using UnityEngine;

namespace CodeBase.CharacterEnemy
{
    [RequireComponent(typeof(Movement))]
    public class Enemy : MonoBehaviour
    {
        private Movement _movement;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }

        public void AddArrayOfMovementPoints(Transform[] movementPoints)
        {
            _movement.SetArrayOfPoints(movementPoints);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Castle>())
            {
                gameObject.SetActive(false);
            }
        }
    }
}