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
            Movement(playerInputHandler.PlayerMoveValue);
        }

        private void Movement(Vector2 direction)
        {
            direction = direction * Speed;
            playerRigidbody2D.velocity = direction;
            animationHandler.AnimatorMove(direction);
        }
    }

}
