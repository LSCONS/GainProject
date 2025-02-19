using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DataInfo.Instance.SaveMainPlayerPosition(collision.transform.position);
            SceneManager.LoadScene("PlaneGameScene");
        }
    }
}
