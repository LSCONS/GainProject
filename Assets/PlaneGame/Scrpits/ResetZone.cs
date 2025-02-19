using PlaneGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class ResetZone : MonoBehaviour
    {
        private float backgroundWidth = 15.9f;
        private float resetZoneMargin = 16f;

        private ObstacleLooper obstacleLooper;
        private void Awake()
        {
            obstacleLooper = FindObjectOfType<ObstacleLooper>();
            if (obstacleLooper == null) Debug.Log("obstacle is null");
        }


        //특정 오브젝트가 배열의 이전 오브젝트로 이동하는 메서드
        private void ResetPosition(Transform collidertransform)
        {
            collidertransform.position = new Vector3(backgroundWidth * 3 - resetZoneMargin, collidertransform.position.y, 0);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Background"))
            {
                ResetPosition(collision.transform);
            }
            else
            {
                Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
                if (obstacle != null) obstacleLooper.ResetObstaclePosition(obstacle);
            }
        }
    }
}