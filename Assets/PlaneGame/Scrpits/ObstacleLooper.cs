using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlaneGame
{
    public class ObstacleLooper : MonoBehaviour
    {
        [SerializeField] private float holeSizeMin = 30f;
        [SerializeField] private float holeSizeMax = 50f;

        [SerializeField] private float obstacleHeightMargin = 3f;
        
        Obstacle[] obstacles;

        [SerializeField] private float obstacleResetX = 200f;

        [SerializeField] private float moveObstacleTime = 5f;

        private float delayTime = 0f;
        private int nowObstacleNum = 0;

        public GameObject movingObject;
        public GameObject obstaclesObject;

        private void Awake()
        {
            Setup();
        }

        private void Start()
        {
            MoveObstacle();
        }

        private void Update()
        {
            delayTime += Time.deltaTime;

            if (delayTime > moveObstacleTime)
            {
                MoveObstacle();
                delayTime = 0f;
            }
        }


        //해당 장애물의 다음 번호를 반환
        private Obstacle CheckObstacle()
        {
            Obstacle obstacle = null;
            nowObstacleNum++;
            if (obstacles.Length > nowObstacleNum)
            {
                obstacle = obstacles[nowObstacleNum];
            }
            else
            {
                nowObstacleNum = 0;
                obstacle = obstacles[nowObstacleNum];
            }

            return obstacle;
        }


        //시작 하기 전 값을 대입해두거나 초기화하는 메서드
        private void Setup()
        {
            obstacles = FindObjectsOfType<Obstacle>();

            foreach (Obstacle obstacle in obstacles)
            {
                ResetObstaclePosition(obstacle);
            }
        }


        //해당 장애물의 위치를 초기화하는 메서드
        public void ResetObstaclePosition(Obstacle obstacle)
        {
            obstacle.transform.position = new Vector3(obstacleResetX, 0, 0);
            obstacle.transform.parent = obstaclesObject.transform;
        }


        //obstacle의 holesize를 random으로 정하고 배치함.
        private void MoveObstacle()
        {
            Obstacle obstacle = CheckObstacle();
            float randHoleSize = Random.Range(holeSizeMin, holeSizeMax);
            float randHeight = Random.Range(-obstacleHeightMargin / 2, obstacleHeightMargin / 2);
            obstacle.transform.parent = movingObject.transform;
            obstacle.SettingObstacle(randHoleSize, randHeight);
        }
    }
}
