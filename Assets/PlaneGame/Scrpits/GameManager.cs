using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        public static GameManager Instance { get => gameManager; }

        private bool isGameOver = false;
        public bool IsGameOver { get { return isGameOver; } }

        ObstacleLooper obstacleLooper;

        private void Awake()
        {
            gameManager = this;
        }

        private void Update()
        {
            
        }
    }
}

