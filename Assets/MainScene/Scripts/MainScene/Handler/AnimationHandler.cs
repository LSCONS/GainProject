using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class AnimationHandler : MonoBehaviour
    {
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static int MoveX = Animator.StringToHash("MoveX");
        private static int MoveY = Animator.StringToHash("MoveY");

        private Animator animator; 

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }


        //매개변수의 값이 0.5 이상인지 확인하고 IsMove의 상태값을 바꾸고, 바라보는 방향을 유지하는 메서드
        public void AnimatorMove(Vector2 value)
        {
            bool isMoving = value.magnitude > 0.5f;

            animator.SetBool(IsMove, isMoving);

            if (isMoving)
            {
                animator.SetFloat(MoveX, value.x); 
                animator.SetFloat(MoveY, value.y);
            }
        }
    }

}
