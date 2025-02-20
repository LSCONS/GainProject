using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameClearUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = transform.Find("ClearText").GetComponent<TextMeshProUGUI>();
    }


    //플레이어가 게임을 성공 혹은 실패했는지 확인하고 텍스트에 출력함.
    public void TextUpdate(bool isClear)
    {
        if (isClear)
        {
            textMeshPro.text = "Clear!!";
        }
        else
        {
            textMeshPro.text = "Failed..";
        }
    }
}
