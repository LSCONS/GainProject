using MainScene;
using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame 
{
    public class PlayerCollider2D : MonoBehaviour
    {
        AnimationHandler animationHandler;

        private void Start()
        {
            animationHandler = GetComponent<AnimationHandler>();
        }


        //플레이어가 부딪힌 collision이 Obstacle일 경우 게임 오버 처리
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstacle") && GameManager.Instance.IsGameOver == false)
            {
                animationHandler.GameOver();
                GameManager.Instance.GameOver();
            }
        }


        //플레이어가 부딪힌 collision이 ScoreLayer일 경우 점수 + 처리
        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("ScoreLayer"))
            {
                DataManager.Instance.AddScore(1);
                UIManager.Instance.TextUpdate();
            }
        }
    }
}