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
            transform.position = new Vector3(0, player.transform.position.y, -10);
        }
    }
}

