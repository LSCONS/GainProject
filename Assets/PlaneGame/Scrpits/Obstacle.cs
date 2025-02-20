using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class Obstacle : MonoBehaviour
    {
        public GameObject topObstacle;
        public GameObject bottomObstacle;


        //위와 아래에 있는 가시의 위치와 높이를 설정하고 배정하는 메서드
        public void SettingObstacle(float holeSize, float obstacleHeight)
        {
            float halfHoleSize = holeSize / 2;
            transform.position = new Vector3(transform.position.x, obstacleHeight, 0);
            topObstacle.transform.localPosition = new Vector3(0, halfHoleSize, 0);
            bottomObstacle.transform.localPosition = new Vector3(0, -halfHoleSize, 0);
        }
    }
}