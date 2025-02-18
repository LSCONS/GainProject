using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene
{
    public class MainCameraControl : MonoBehaviour
    {
        public GameObject player;

        private void Update()
        {
            if (transform.position.y >= 22f)
            {
                Debug.Log(transform.position.y);
                transform.position = new Vector3(0, 22f, -10);
            }
        }
    }
}

