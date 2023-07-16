using System.Collections;
using System.Collections.Generic;
using System;
using Controls;
using UnityEngine;

namespace CameraNamespace
{
    public class DramaManager : MonoBehaviour
    {
        public String[] directionsList;
        private float speed;
        private Vector3 direction;
        private float finalZoom;

        private void Awake()
        {
            //Se suscribe a los sujetos que sean necesarios
            GameObject.FindGameObjectWithTag("Player").GetComponent<ControlManager>().CameraHandler += ExecuteCameraMovement;
        }

        private void ProcessDirections(int i)
        {
            String[] processedDirections = directionsList[i].Split("_");
            if(processedDirections.Length == 4)
            {
                String[] processedVector = processedDirections[0].Split(",");
                this.direction = new Vector3(float.Parse(processedVector[0]), float.Parse(processedVector[1]), float.Parse(processedVector[2]));

                this.speed = float.Parse(processedDirections[1]);
                this.finalZoom = float.Parse(processedDirections[2]);
            }
            else
            {
                Debug.LogError("ERROR AL PROCESAR DIRECCIONES DRAMATICAS. MENSAJE " + i + " NO DIVIDIDO EN 4 SECCIONES.");
            }
        }

        public void ExecuteCameraMovement(object sender, int i)
        {
            Debug.Log("Se recibe la orden");

            ProcessDirections(i);
            StartCoroutine(MoveLerp(this.transform.localPosition, direction, speed, finalZoom));
        }

        IEnumerator MoveLerp(Vector3 startingPoint, Vector3 destination, float moveSpeed, float zoom)
        {
            float elapsed = 0;
            float initialZoom = GetComponent<Camera>().orthographicSize;
            while (this.transform.localPosition != destination)
            {
                GetComponent<Camera>().orthographicSize = Mathf.Lerp(initialZoom, zoom, elapsed);

                this.transform.localPosition = Vector3.Lerp(startingPoint, destination, elapsed);
                elapsed += (0.01f * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
