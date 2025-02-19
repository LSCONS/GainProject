using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneGame
{
    public class HomeUI : MonoBehaviour
    {
        private TextMeshProUGUI currentScore;
        private TextMeshProUGUI bestScore;

        private void Awake()
        {
            currentScore = transform.Find("NowScore").GetComponent<TextMeshProUGUI>();
            bestScore = transform.Find("BestScore").GetComponent <TextMeshProUGUI>();
            if (currentScore == null) Debug.Log("currentScore is null");
            if (bestScore == null) Debug.Log("bestScore is null");
        }

        private void Start()
        {
            UpdateText();
        }


        //텍스트를 업데이트해서 출력하는 메서드
        public void UpdateText()
        {
            currentScore.text = DataInfo.Instance.PlaneGameCurrentScore.ToString();
            bestScore.text = DataInfo.Instance.PlaneGameBestScore.ToString();
        }
    }
}
