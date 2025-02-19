using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlaneGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public bool isClick;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.F) ||
                Input.GetMouseButtonDown(0))
            {
                isClick = true;
            }
        }
    }
}

