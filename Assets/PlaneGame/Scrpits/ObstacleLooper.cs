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


        //오브젝트를 전체적으로 왼쪽으로 옮기는 로직에 대해 어떻게 구현할 것인지 고민해야함.
        //움직이는 배경 오브젝트들은 계속 왼쪽으로 움직이는 오브젝트인 MovingObject의 자식 오브젝트로 만든다.
        //이후 배경오브젝트들은 특정 BoxCollider에 닿을 경우 다시 오른쪽으로 이동하며 반복하게 만듦.
        //하지만 부딪힌 오브젝트가 Obstacle 오브젝트인 경우 MovingObject가 아닌 Obstacles의 자식으로 보낸다.
        //이후 딜레이 타임이 끝나 해당 스크립크에서 특정 메서드를 실행하면 다음 순서에 있는 Obstacles에 있는 Obstacle를 호출하여
        //MovingObject의 자식으로 보낸다.
        private void MoveObstacle()
        {
            Obstacle obstacle = CheckObstacle();
            float rand = Random.Range(holeSizeMin, holeSizeMax);
            obstacle.transform.parent = movingObject.transform;
            obstacle.SettingObstacle(rand);
        }
    }
}
