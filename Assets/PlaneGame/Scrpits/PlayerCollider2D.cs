using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame {
    public class PlayerCollider2D : MonoBehaviour
    {
        GameManager gameManager;

        private void Awake()
        {
            gameManager = GameManager.Instance;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstacle"))
            {
                gameManager.GameOver();
            }
        }
    }
}