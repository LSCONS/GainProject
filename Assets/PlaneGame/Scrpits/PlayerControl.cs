using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float playerJumpForce = 7f;


        PlayerInputHandler inputHandler;
        Rigidbody2D playerRigidbody;


        private void Awake()
        {
            inputHandler = GetComponent<PlayerInputHandler>();
            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.IsGameOver) return;

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