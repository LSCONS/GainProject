using PlaneGame;
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
        public bool IsGameOver { get => isGameOver;}

        ObstacleLooper obstacleLooper;

        private void Awake()
        {
            if(gameManager == null)
            {
                gameManager = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (Instance == null) Debug.Log("gameManger Instance null");
        }


        //게임이 종료 된 경우 실행할 메서드
        public void GameOver()
        {
            isGameOver = true;
            Debug.Log("게임 오버");
        }


        //게임을 재시작할 경우 실행할 메서드
        public void GameRestart()
        {

        }
    }
}

