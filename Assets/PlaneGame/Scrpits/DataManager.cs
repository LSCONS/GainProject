using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class DataManager : MonoBehaviour
    {
        private static DataManager dataManager;

        public static DataManager Instance { get => dataManager; }

        private readonly string bestScoreKey = "playerBestScore";

        private int currentScore = 0;
        public int CurrentScore { get => currentScore; }

        public int BestScore { get => PlayerPrefs.GetInt(bestScoreKey, 0); }

        private void Awake()
        {
            dataManager = this;
        }


        //현재 스코어를 최고 스코어와 비교하여 저장함
        public void SaveScore()
        {
            if (BestScore < CurrentScore)
            {
                PlayerPrefs.SetInt(bestScoreKey, CurrentScore);
            }
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
    }

}