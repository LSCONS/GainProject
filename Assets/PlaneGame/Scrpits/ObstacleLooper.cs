using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlaneGame
{
    public class ObstacleLooper : MonoBehaviour
    {
        private float holeSizeMin = 4f;
        private float holeSizeMax = 6f;

        private float obstacleHeightMargin = 4f;
        private int allIndex = 0;
        
        Obstacle[] obstacles;

        private float obstacleResetX = 30f;

        private float moveObstacleTime = 5f;

        private float delayTime = 0f;
        private int nowObstacleNum = 0;

        public GameObject movingObject;
        public GameObject obstaclesObject;

        private void Awake()
        {
            Setup();//시작 하기 전 필요한 값을 대입해두거나 초기화하는 메서드
        }


        private void Start()
        {
            MoveObstacle();//게임이 시작했을때 가시 1개를 움직이는 오브젝트에 연결해서 시작함.
        }


        private void Update()
        {
            if (allIndex >= GameManager.Instance.GameClearScoreMax) return;//가시를 클리어 기준까지 던짐.
            SettingObstacle();
        }


        //게임이 시작됐고 게임오버 상태가 아닐 때, 일정 주기마다 가시를 플레이어에게 보냄.
        private void SettingObstacle()
        {
            if (GameManager.Instance.IsGameStart && GameManager.Instance.IsGameOver == false)
            {
                GetGameLevelUpdate();
                delayTime += Time.deltaTime;

                if (delayTime > moveObstacleTime)
                {
                    MoveObstacle();
                    delayTime = 0f;
                }
            }
        }


        //해당 장애물의 다음 번호를 반환
        private Obstacle CheckObstacle()
        {
            Obstacle obstacle = null;
            allIndex++;
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


        //obstacle의 holesize를 random으로 정하고 배치함.
        private void MoveObstacle()
        {
            Obstacle obstacle = CheckObstacle();
            float randHoleSize = Random.Range(holeSizeMin, holeSizeMax);
            float randHeight = Random.Range(-obstacleHeightMargin / 2, obstacleHeightMargin / 2);
            obstacle.transform.parent = movingObject.transform;
            obstacle.SettingObstacle(randHoleSize, randHeight);
        }


        //현재의 난이도에 따라 가시 생성의 주기, 높이, 너비 등을 조절하는 메서드
        private void GetGameLevelUpdate()
        {
            GameLevel gameLevel = GameManager.Instance.GetCurrentLevel();

            switch(gameLevel)
            {
                case GameLevel.Easy:
                    holeSizeMin = 4f;
                    holeSizeMax = 6f;
                    obstacleHeightMargin = 2f;
                    moveObstacleTime = 5f;
                    break;
                case GameLevel.Noaml:
                    holeSizeMin = 4f;
                    holeSizeMax = 6f;
                    obstacleHeightMargin = 3f;
                    moveObstacleTime = 4f;
                    break;
                case GameLevel.Hard:
                    holeSizeMin = 3f;
                    holeSizeMax = 5f;
                    obstacleHeightMargin = 4f;
                    moveObstacleTime = 3f;
                    break;
                case GameLevel.Extreme:
                    holeSizeMin = 3f;
                    holeSizeMax = 5f;
                    obstacleHeightMargin = 4f;
                    moveObstacleTime = 2.5f;
                    break;
                case GameLevel.Hell:
                    holeSizeMin = 2.5f;
                    holeSizeMax = 4f;
                    obstacleHeightMargin = 4f;
                    moveObstacleTime = 2f;
                    break;
            }
        }


        //해당 장애물의 위치를 초기화하는 메서드
        public void ResetObstaclePosition(Obstacle obstacle)
        {
            obstacle.transform.position = new Vector3(obstacleResetX, 0, 0);
            obstacle.transform.parent = obstaclesObject.transform;
        }
    }
}
