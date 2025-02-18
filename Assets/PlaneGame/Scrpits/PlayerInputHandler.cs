using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlaneGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private bool isClick;
        public bool IsClick {  get { return isClick; } }

        private void OnClick(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                isClick = true;
            }
            else
            {
                isClick = false;
            }
        }
    }
}

