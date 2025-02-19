using MainScene;
using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame {
    public class PlayerCollider2D : MonoBehaviour
    {
        GameManager gameManager;
        AnimationHandler animationHandler;

        private void Awake()
        {
            gameManager = GameManager.Instance;
            animationHandler = GetComponent<AnimationHandler>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstacle"))
            {
                animationHandler.GameOver();
                gameManager.GameOver();
            }
        }
    }
}