using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsDie = Animator.StringToHash("IsDie");
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    //게임이 끝날 경우 처리 할 애니메이션 메서드
    public void GameOver()
    {
        animator.SetBool(IsDie, true);
    }


    //게임이 재시작 될 경우 처리할 애니메이션 메서드
    public void GameRestart()
    {
        animator.SetBool(IsDie, false);
    }
}
