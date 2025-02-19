using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class Obstacle : MonoBehaviour
    {
        public GameObject topObstacle;
        public GameObject bottomObstacle;


        public void SettingObstacle(float holeSize, float obstacleHeight)
        {
            float halfHoleSize = holeSize / 2;
            transform.position = new Vector3(transform.position.x, obstacleHeight, 0);
            topObstacle.transform.localPosition = new Vector3(0, halfHoleSize, 0);
            bottomObstacle.transform.localPosition = new Vector3(0, -halfHoleSize, 0);
        }
    }
}