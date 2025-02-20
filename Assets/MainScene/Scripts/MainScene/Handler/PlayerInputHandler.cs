using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 playerMoveValue;
    public Vector2 PlayerMoveValue { get => playerMoveValue; }
    private bool isSelect;
    public bool IsSelect { get => isSelect; }
    private bool isCancle;
    public bool IsCancle { get => isCancle; }
    private bool isInteraction;
    public bool IsInteraction { get => isInteraction; }
    private bool isJump;
    public bool IsJump { get => isJump; }
    private bool isClick;
    public bool IsClick { get => isClick; }

    private float moveX;
    public float MoveX { get => moveX;  }
    private float moveY;
    public float MoveY { get => moveY; } 
    private readonly static string HorizontalKey = "Horizontal";
    private readonly static string VerticalKey = "Vertical";
    private readonly static string JumpKey = "Jump";
    private readonly static string MouseClick0Key = "Fire1";
    private readonly static string SelectKey = "Select";
    private readonly static string CancelKey = "Cancel";
    private readonly static string InteractionKey = "Interaction";

    public Vector2 MoveVector { get => new Vector2(MoveX, MoveY).normalized; }


    private void Update()
    {
        
        moveX = Input.GetAxisRaw(HorizontalKey);
        moveY = Input.GetAxisRaw(VerticalKey);
        isJump = Input.GetButtonDown(JumpKey);
        isClick = Input.GetButtonDown(MouseClick0Key);
        isCancle = Input.GetButtonDown(CancelKey);
        isSelect = Input.GetButtonDown(SelectKey);
        isInteraction = Input.GetButtonDown(InteractionKey);
    }
}
