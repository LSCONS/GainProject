using PlaneGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlaneGame
{
    public enum GameLevel
    {
        Easy,
        Noaml,
        Hard,
        Extreme,
        Hell
    }
    public class GameManager : MonoBehaviour
    {
        private static GameManager gameManager;
        public static GameManager Instance { get => gameManager; }

        private bool isGameOver = false;
        public bool IsGameOver { get => isGameOver;}

        private bool isGameStart = false;
        public bool IsGameStart { get => isGameStart; }
        private bool isClickStart = false;
        public bool IsClickStart { get => isClickStart; }
        private bool isGameClear = false;
        public bool IsGameClear { get => isGameClear;}

        public Action OnGameStart;
        public Action OnGameOver;
        public Action OnGameClear;
        
        private float currentDelayTime = 0;
        private float maxDelayTime = 1f;

        private void Awake()
        {
            if (gameManager == null)
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
            if (DataManager.Instance.CurrentScore == 100)
            {
                isGameClear = true;
                isGameOver = true;
            }


            if (IsGameOver)
            {
                UIManager.Instance.GameClearPanel(IsGameClear);
                currentDelayTime += Time.deltaTime;
                if (currentDelayTime > maxDelayTime)
                {
                    //게임이 오버된 후 MaxDelayTime이 흐른 후 씬 재시작***
                    OnGameOver?.Invoke();
                    SceneManager.LoadScene("PlaneGameScene");
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


        //게임을 클리어 했을 때 실행할 메서드
        public void GameClear()
        {
            OnGameClear?.Invoke();
        }


        //현재 게임 난이도를 반환하는 메서드
        public GameLevel GetCurrentLevel()
        {
            GameLevel gameLevel = GameLevel.Easy;

            int currentScore = DataManager.Instance.CurrentScore;

            if(currentScore < 5)       gameLevel = GameLevel.Easy;
            else if(currentScore < 10) gameLevel = GameLevel.Noaml;
            else if(currentScore < 20) gameLevel = GameLevel.Hard;
            else if(currentScore < 50) gameLevel = GameLevel.Extreme;
            else                       gameLevel = GameLevel.Hell;

            return gameLevel;
        }
    }
}

