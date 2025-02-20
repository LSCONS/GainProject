using MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpControl : MonoBehaviour
{
    private PlayerInputHandler PlayerInputHandler;

    private float jumpForce = 5f;
    private float jumpMaxY = 0.8f;
    private float timeX = 0f;
    private bool isJump = false;

    private void Awake()
    {
        PlayerInputHandler = GetComponentInParent<PlayerInputHandler>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }

        if (isJump)
        {
            timeX += jumpForce * Time.deltaTime;
            float spriteY = Mathf.PingPong(timeX, jumpMaxY);
            transform.localPosition = new Vector3(0f, spriteY, 0);

            if(timeX >= 2 * jumpMaxY)
            {
                transform.localPosition = Vector3.zero;
                isJump = false;
                timeX = 0f;
            }
        }
    }
}
