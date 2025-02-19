using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerJumpForce = 5f;


    PlayerInputHandler inputHandler;
    Rigidbody2D playerRigidbody;
    GameManager gameManager;


    private void Awake()
    {
        gameManager = GameManager.Instance;
        inputHandler = GetComponent<PlayerInputHandler>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (gameManager.IsGameOver) return;

        if (inputHandler.isClick)
        {
            Debug.Log("점프");
            playerRigidbody.velocity = new Vector2(0, playerJumpForce);
            inputHandler.isClick = false;
        }

        float angle = Mathf.Clamp(playerRigidbody.velocity.y * 10, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
