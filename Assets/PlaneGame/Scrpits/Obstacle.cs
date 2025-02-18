using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneGame
{
    public class Obstacle : MonoBehaviour
    {
        public GameObject topObstacle;
        public GameObject bottomObstacle;


        public void SettingObstacle(float holeSize)
        {
            float halfHoleSize = holeSize / 2;

            topObstacle.transform.localPosition = new Vector3(0, halfHoleSize, 0);
            bottomObstacle.transform.localPosition = new Vector3(0, -halfHoleSize, 0);
        }
    }
}