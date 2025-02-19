using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlaneGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public bool isClick = false;
        public bool isSelect = false;
        public bool isCancel = false;


        private void Update()
        {
            InputPlayerGameStart();
            InputPlayerPlayGame();
        }


        //게임이 시작하기 전 플레이어의 입력을 받는 메서드
        private void InputPlayerGameStart()
        {
            if (GameManager.Instance.IsGameStart == false)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    isSelect = true;
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    isCancel = true;
                }
            }
        }


        //게임을 시작한 후 플레이어의 입력을 받는 메서드
        private void InputPlayerPlayGame()
        {
            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.F) ||
                Input.GetMouseButtonDown(0))
            {
                isClick = true;
            }
        }
    }
}

