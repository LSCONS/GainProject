using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class DataManager : MonoBehaviour
    {

        private int currentScore = 0;
        public int CurrentScore { get => currentScore; }

        private static DataManager dataManager;

        public static DataManager Instance { get => dataManager; }

        private void Awake()
        {
            dataManager = this;
        }

        private void Start()
        {
            GameManager.Instance.OnGameStart += ResetScore;
            GameManager.Instance.OnGameOver += SaveData;
        }

        //현재 스코어를 매개변수 값 만큼 증가시킴
        public void AddScore(int score)
        {
            currentScore += score;
        }


        //현재 스코어를 0으로 되돌림.
        public void ResetScore()
        {
            currentScore = 0;
        }


        //현재 스코어를 데이터베이스에 저장.
        public void SaveData()
        {
            DataInfo.Instance.SavePlaneGameData(currentScore);
        }
    }

}