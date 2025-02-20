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
