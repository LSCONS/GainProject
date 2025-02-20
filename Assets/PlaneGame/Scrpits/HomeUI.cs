using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneGame
{
    public class HomeUI : MonoBehaviour
    {
        private TextMeshProUGUI currentScoreGUI;
        private TextMeshProUGUI bestScoreGUI;

        private void Awake()
        {
            currentScoreGUI = transform.Find("NowScore").GetComponent<TextMeshProUGUI>();
            bestScoreGUI = transform.Find("BestScore").GetComponent <TextMeshProUGUI>();
            if (currentScoreGUI == null) Debug.Log("currentScore is null");
            if (bestScoreGUI == null) Debug.Log("bestScore is null");
        }

        private void Start()
        {
            UpdateText();
        }


        //텍스트를 업데이트해서 출력하는 메서드
        public void UpdateText()
        {
            int currentScore = DataInfo.Instance.PlaneGameCurrentScore;
            int bestScore = DataInfo.Instance.PlaneGameBestScore;
            int clearScore = GameManager.Instance.GameClearScoreMax;

            string currentScoreText =
                (currentScore == clearScore) ? "Clear!!" : currentScore.ToString();

            string bestScoreText =
                (bestScore == clearScore) ? "Clear!!" : bestScore.ToString();

            currentScoreGUI.text = currentScoreText;
            bestScoreGUI.text = bestScoreText;
        }
    }
}
