using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float playerColliderSize = 0.4f;
        [SerializeField] private float playerJumpForce = 7f;
        [SerializeField] private float playerStartDelay = 0.5f; //게임 시작후 해당 시간동안 콜라이더 영향 없음.
        private float delayTime = 0f;

        PlanePlayerInputHandler inputHandler;
        Rigidbody2D playerRigidbody;
        CircleCollider2D playerCircleCollider = null;


        private void Awake()
        {
            inputHandler = GetComponent<PlanePlayerInputHandler>();
            playerRigidbody = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            if (GameManager.Instance.IsGameOver || GameManager.Instance.IsGameStart == false) return;
            PlayerStartGameSetting();
            PlayerMovement();
        }


        //일정 시간이 지난 후 플레이어에게 CircleCollider2D컴포넌트를 추가하는 메서드
        private void PlayerStartGameSetting()
        {
            if (GameManager.Instance.IsGameStart && playerCircleCollider == null)
            {
                delayTime += Time.fixedDeltaTime;
                if (delayTime > playerStartDelay)
                {
                    playerCircleCollider = gameObject.AddComponent<CircleCollider2D>();
                    playerCircleCollider.radius = playerColliderSize;
                    playerRigidbody.gravityScale = 1f;
                }
            }
        }


        //클릭을 했는지 확인하고 플레이어를 이동시키며 angle값을 조정하는 메서드
        private void PlayerMovement()
        {
            if (inputHandler.isClick)
            {
                Vector3 velocity = playerRigidbody.velocity;
                velocity.y += playerJumpForce;
                playerRigidbody.velocity = velocity;
                inputHandler.isClick = false;
            }

            float angle = Mathf.Clamp((playerRigidbody.velocity.y * 10), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}