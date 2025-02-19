using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlaneGame
{
    public class MovingObject : MonoBehaviour
    {
        private float movingSpeed = 5f;

        private void Update()
        {
            if (GameManager.Instance.IsGameOver == true)
            {
                return;
            }

            if (GameManager.Instance.IsGameStart)
            {
                GetMovingSpeed();
                transform.position = Vector3.Lerp(
                    transform.position,
                    transform.position + (Vector3.left),
                    movingSpeed * Time.deltaTime);
            }
        }

        private void GetMovingSpeed()
        {
            GameLevel gameLevel = GameManager.Instance.GetCurrentLevel();
            switch(gameLevel)
            {
                case GameLevel.Easy:
                    movingSpeed = 5f;
                    break;
                case GameLevel.Noaml:
                    movingSpeed = 8f;
                    break;
                case GameLevel.Hard:
                    movingSpeed = 11f;
                    break;
                case GameLevel.Extreme:
                    movingSpeed = 13f;
                    break;
                case GameLevel.Hell:
                    movingSpeed = 15f;
                    break;
            }
        }
    }
}