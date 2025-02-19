using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlaneGame
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager uiManager;
        public static UIManager Instance { get => uiManager; }


        HomeUI homeUI;

        TextMeshProUGUI currentScore;

        private void Awake()
        {
            uiManager = this;
            homeUI = transform.Find("HomeUI").GetComponent<HomeUI>();
            currentScore = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }


        //HomeUI를 비활성화하는 메서드
        public void HomeUISetFalse()
        {
            homeUI.gameObject.SetActive(false);
        }


        //게임 화면 위에 있는 점수 텍스트를 업데이트 시켜주는 메서드
        public void TextUpdate()
        {
            currentScore.text = DataManager.Instance.CurrentScore.ToString();
        }
    }

}