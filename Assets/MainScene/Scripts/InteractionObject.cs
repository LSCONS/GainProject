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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasObject.SetActive(false);
        }
    }
}
