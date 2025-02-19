using PlaneGame;
using System;
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

        private bool isGameStart = false;
        public bool IsGameStart { get => isGameStart; }
        private bool isClickStart = false;
        public bool IsClickStart { get => isClickStart; }

        public Action OnGameStart;
        public Action OnGameOver;
        private float currentDelayTime = 0;
        private float maxDelayTime = 1f;

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

        private void Update()
        {
            if (IsGameOver)
            {
                currentDelayTime += Time.deltaTime;
                if (currentDelayTime > maxDelayTime)
                {
                    //게임이 오버된 후 MaxDelayTime이 흐른 후 씬 재시작***
                }
            }
        }


        //게임이 종료 된 경우 실행할 메서드
        public void GameOver()
        {
            isGameOver = true;
            OnGameOver?.Invoke();
        }


        //게임을 시작할 경우 실행할 메서드
        public void GameStart()
        {
            isGameStart = true;
            OnGameStart.Invoke();
        }


        //게임의 비행기를 조작 가능하게 만드는 메서드
        public void ClickStart()
        {
            isClickStart = true;
        }
    }
}

