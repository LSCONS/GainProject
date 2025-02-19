using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlaneGame
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private float movingSpeed = 100f;

        Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {

            if (GameManager.Instance.IsGameOver == true)
            {
                _rigidbody2D.velocity = Vector2.zero;
                return;
            }
            

            _rigidbody2D.velocity = new Vector2(-movingSpeed * Time.deltaTime, 0);


        }
    }
}