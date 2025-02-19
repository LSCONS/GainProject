using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : MonoBehaviour
{
    private static DataInfo dataInfo;

    public static DataInfo Instance { get => dataInfo; }

    public readonly string planeGameBestScoreKey = "playerBestScore";

    private int planeGameCurrentScore = 0;
    public int PlaneGameCurrentScore { get => planeGameCurrentScore; }

    public int PlaneGameBestScore { get => PlayerPrefs.GetInt(planeGameBestScoreKey, 0); }


    //현재 스코어를 최고 스코어와 비교하여 저장함
    public void SavePlaneGameData(int currentScore)
    {
        if (PlaneGameBestScore < currentScore)
        {
            PlayerPrefs.SetInt(planeGameBestScoreKey, currentScore);
        }

        planeGameCurrentScore = currentScore;
    }
}
