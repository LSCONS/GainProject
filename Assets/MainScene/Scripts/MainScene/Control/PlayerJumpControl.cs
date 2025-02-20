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
        CheckPlayerIsJump();
        PlayerJump();
    }



    //플레이어가 점프키를 눌렀는지 확인하는 메서드
    private void CheckPlayerIsJump()
    {
        if (PlayerInputHandler.IsJump)
        {
            isJump = true;
        }
    }


    //플레이어가 점프 중이라면 sprite의 localPosition을 바꿔서 점프 처리를 해주는 메서드
    private void PlayerJump()
    {
        if (isJump)
        {
            timeX += jumpForce * Time.deltaTime;
            float spriteY = Mathf.PingPong(timeX, jumpMaxY);
            transform.localPosition = new Vector3(0f, spriteY, 0);

            if (timeX >= 2 * jumpMaxY)
            {
                transform.localPosition = Vector3.zero;
                isJump = false;
                timeX = 0f;
            }
        }
    }
}
