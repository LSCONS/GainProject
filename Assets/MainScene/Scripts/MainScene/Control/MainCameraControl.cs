using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class MainCameraControl : MonoBehaviour
    {
        public GameObject player;
        private float cameraMinY = 0f;
        private float cameraMaxY = 34f;
        private float cameraSpeed = 3f;

        private void Update()
        {
            CameraMovement();
        }

        
        //카메라의 위치를 조정하는 메서드
        private void CameraMovement()
        {
            float cameraY = Mathf.Clamp(player.transform.position.y, cameraMinY, cameraMaxY);
            Vector3 targetPosition = new Vector3(0, cameraY, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
    }
}

