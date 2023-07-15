using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraNamespace
{
    public class CameraZoomManager : MonoBehaviour
    {
        public GameObject player;
        public float zoomSpeed;
        public float zoomLevel;
        private Vector3 initialPosition;
        private Vector3 endPosition;
        private float initialZoom;
        private float endZoom;
        private float n = 0;
        private Camera cameraComponent;

        private Vector3 preInitialPosition;
        private Vector3 preEndPosition;
        private float preInitialZoom;
        private float preEndZoom;

        private void Awake()
        {
            cameraComponent = GetComponent<Camera>();
        }

        public void StartZoom()
        {
            initialPosition = this.transform.localPosition;
            endPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y / (zoomLevel * 1.5f), this.transform.localPosition.z);
            initialZoom = cameraComponent.orthographicSize;
            endZoom = cameraComponent.orthographicSize / zoomLevel;

            SavePreviousZoom();

            StartCoroutine(ManageZoom(initialPosition, endPosition, initialZoom, endZoom, zoomSpeed));
        }

        public void StartZoom(float zSpeed, float zLevel)
        {
            initialPosition = this.transform.localPosition;
            endPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y / (zLevel * 1.5f), this.transform.localPosition.z);
            initialZoom = cameraComponent.orthographicSize;
            endZoom = cameraComponent.orthographicSize / zLevel;

            SavePreviousZoom();

            StartCoroutine(ManageZoom(initialPosition, endPosition, initialZoom, endZoom, zSpeed));
        }

        public void RevertZoom(float zSpeed)
        {
            StartCoroutine(ManageZoom(preEndPosition, preInitialPosition, preEndZoom, preInitialZoom, zSpeed));
        }

        IEnumerator ManageZoom(Vector3 fPos, Vector3 lPos, float iZoom, float eZoom, float speed)
        {
            while(n < 1f)
            {
                transform.localPosition = Vector3.Lerp(fPos, lPos, n);
                cameraComponent.orthographicSize = Mathf.Lerp(iZoom, eZoom, n);

                n += 0.01f * speed * Time.deltaTime;
                n = Mathf.Clamp(n, 0, 1);

                yield return null;
            }

            n = 0;
            yield return null;
        }

        private void SavePreviousZoom()
        {
            preInitialPosition = initialPosition;
            preEndPosition = endPosition;
            preInitialZoom = initialZoom;
            preEndZoom = endZoom;
        }
    }
}
