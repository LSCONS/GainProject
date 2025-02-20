using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTextControl : MonoBehaviour
{
    private Vector2 targetVector;
    private Vector2 offset = new Vector2(0, 1);

    private void Awake()
    {
        CircleCollider2D circleCollider = GetComponentInParent<CircleCollider2D>(); 
        targetVector = circleCollider.offset;
    }
    private void Update()
    {
        transform.position = targetVector + offset;
    }
}
