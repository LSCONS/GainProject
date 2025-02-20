using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionTile : MonoBehaviour
{
    //닿고 있는 collision이 플레이어라면 해당 플레이어를 다른 씬으로 이동시킴
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DataInfo.Instance.SaveMainPlayerPosition(collision.transform.position);
            SceneManager.LoadScene("PlaneGameScene");
        }
    }
}
