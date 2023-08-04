using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.CharacterEnemy
{
    public class Skeleton:Enemy
    {
        private const string Speed = "Speed";
        private const float MovingAnimationValue = 1f;

        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.SetFloat(Speed,MovingAnimationValue);
        }
        
    }
}