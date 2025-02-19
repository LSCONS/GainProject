using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : MonoBehaviour
{
    private static DataInfo dataInfo;

    public static DataInfo Instance { get => dataInfo; }

    public readonly string planeGameBestScoreKey = "playerBestScore";
    public readonly string mainPlayerPositionXKey = "mainPlayerPositionX";
    public readonly string mainPlayerPositionYKey = "mainPlayerPositionY";

    private int planeGameCurrentScore = 0;
    public int PlaneGameCurrentScore { get => planeGameCurrentScore; }
    private Vector2 mainPlayerPosition;
    public Vector2 MainPlayerPosition {  get => mainPlayerPosition; }

    public int PlaneGameBestScore { get => PlayerPrefs.GetInt(planeGameBestScoreKey, 0); }


    private void Awake()
    {
        if(dataInfo == null)
        {
            dataInfo = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    //현재 스코어를 최고 스코어와 비교하여 저장함
    public void SavePlaneGameData(int currentScore)
    {
        if (PlaneGameBestScore < currentScore)
        {
            PlayerPrefs.SetInt(planeGameBestScoreKey, currentScore);
        }

        planeGameCurrentScore = currentScore;
    }


    //메인 씬의 플레이어 위치를 저장함.
    public void SaveMainPlayerPosition(Vector2 vector2)
    {
        float x = vector2.x;
        float y = vector2.y - 1;
        PlayerPrefs.SetFloat(mainPlayerPositionXKey, x);
        PlayerPrefs.SetFloat(mainPlayerPositionYKey, y);
        mainPlayerPosition = new Vector2(x, y);
    }
}
