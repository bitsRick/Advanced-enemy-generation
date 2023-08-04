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
        
    }
}