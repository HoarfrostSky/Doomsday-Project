using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraNamespace
{
    public class ManageZoomOut : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DramaManager>().ExecuteCameraMovement(this, 8);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DramaManager>().ExecuteCameraMovement(this, 0);
        }
    }
}