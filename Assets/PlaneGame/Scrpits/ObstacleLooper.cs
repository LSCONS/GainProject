using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleLooper : MonoBehaviour
{
    [SerializeField]private float holeSizeMin = 30f;
    [SerializeField]private float holeSizeMax = 50f;

    Obstacle[] obstacles;

    [SerializeField] private float obstacleResetX = 200f;

    [SerializeField] private float moveObstacleTime = 5f;

    private void Awake()
    {
        Setup();
    }


    //시작 하기 전 값을 대입해두거나 초기화하는 메서드
    private void Setup()
    {
        obstacles = FindObjectsOfType<Obstacle>();

        foreach(Obstacle obstacle in obstacles)
        {
            obstacle.transform.position = new Vector3(obstacleResetX, 0, 0);
        }
    }

}
