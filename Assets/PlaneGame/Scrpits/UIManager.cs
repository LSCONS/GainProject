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


        public void TextUpdate()
        {
            currentScore.text = DataManager.Instance.CurrentScore.ToString();
        }
    }

}