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
            float cameraY = Mathf.Clamp(player.transform.position.y, cameraMinY, cameraMaxY);
            Vector3 targetPosition = new Vector3(0, cameraY, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
    }
}

