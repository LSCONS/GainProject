using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class PlayerControl : MonoBehaviour
    {
        PlayerInputHandler playerInputHandler;
        [Range(1, 10)][SerializeField] private int speed = 1;
        public int Speed { get => speed; }

        Rigidbody2D playerRigidbody2D;
        AnimationHandler animationHandler;


        private void Awake()
        {
            playerInputHandler = GetComponent<PlayerInputHandler>();
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            animationHandler = GetComponent<AnimationHandler>();
        }


        private void Start()
        {
            float x = PlayerPrefs.GetFloat(DataInfo.Instance.mainPlayerPositionXKey, 0f);
            float y = PlayerPrefs.GetFloat(DataInfo.Instance.mainPlayerPositionYKey, 0f);
            transform.position = new Vector2(x, y);
        }


        private void FixedUpdate()
        {
            Movement(playerInputHandler.MoveVector);
        }


        //플레이어가 입력된 방향벡터의 방향으로 Speed의 수치만큼 이동하는 메서드
        private void Movement(Vector2 direction)
        {
            direction = direction * Speed;
            playerRigidbody2D.velocity = direction;
            animationHandler.AnimatorMove(direction);   //애니메이션에 해당 방향벡터를 보냄.
        }
    }

}
