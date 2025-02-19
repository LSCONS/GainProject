using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 100f;

    Rigidbody2D _rigidbody2D;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(gameManager.IsGameOver == false)
        {
            _rigidbody2D.velocity = new Vector2(-movingSpeed * Time.deltaTime, 0);
        }
    }
}
