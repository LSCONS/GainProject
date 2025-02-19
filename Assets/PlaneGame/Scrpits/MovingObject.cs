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

                transform.position = Vector3.Lerp(
                    transform.position, 
                    transform.position + (Vector3.left),
                    movingSpeed * Time.deltaTime);
            }
        }
    }
}