using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private GameObject canvasObject;

    private void Awake()
    {
        canvasObject = transform.Find("Canvas").gameObject;
    }


    //플레이어가 Trigger 중이라면 canvas를 활성화시켜서 화면에 띄움.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasObject.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                collision.transform.position = Vector3.zero;
            }
        }
    }


    //플레이어가 Trigger에서 벗어났다면 canvas를 비활성화시켜서 화면에 지움.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasObject.SetActive(false);
        }
    }
}
