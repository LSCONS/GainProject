using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MainScene
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private Vector2 playerMoveValue;
        public Vector2 PlayerMoveValue { get { return playerMoveValue; } }
        private bool isSelect;
        public bool IsSelect { get { return isSelect; } }
        private bool isCancle;
        public bool IsCancle { get { return isCancle; } }
        private bool isInteraction;
        public bool IsInteraction { get { return isInteraction; } }
        private bool isJump;
        public bool IsJump { get { return isJump; } }






        public void OnMove(InputValue inputValue)
        {
            playerMoveValue = inputValue.Get<Vector2>();
            playerMoveValue = playerMoveValue.normalized;
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                isSelect = true;
            }
            else
            {
                isSelect = false;
            }
        }

        public void OnCancle(InputValue inputValue)
        {

        }

        public void OnJump(InputValue inputValue)
        {

        }

        public void OnInteraction(InputValue inputValue)
        {

        }
    }

}
