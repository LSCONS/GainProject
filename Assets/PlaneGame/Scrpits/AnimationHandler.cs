using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class AnimationHandler : MonoBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        //게임이 끝날 경우 처리 할 애니메이션 메서드
        public void GameOver()
        {
            animator.SetBool(IsDead, true);
        }
    }
}