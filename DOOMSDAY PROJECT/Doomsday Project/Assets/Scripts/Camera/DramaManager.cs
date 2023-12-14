using System.Collections;
using System.Collections.Generic;
using System;
using Controls;
using UnityEngine;
using States.Interfaces;
using States.ConcreteStates;
using States.Controllers;
using Interactuables.ConcreteInteractuables;
using DramaticScreen;

namespace CameraNamespace
{
    public class DramaManager : MonoBehaviour
    {
        public String[] directionsList;

        public GameObject playerGO;
        public GameObject throneGO;
        public GameObject dramaticScreenGO;

        //GUIA ORDENES:
        // 0: vuelve a personaje
        // 1 y 2: inicio diálogo alma
        // 3: zoom al entrar el judge
        // 4: recolocación cámara para condenar o salvar
        // 5: movimiento dramático al cargar el ataque
        // 6: movimiento dramático cuando el alma recibe el ataque
        // 7: camara se recupera despues del golpe
        // 8: zoom abierto cuando el personaje se aleja del trono
        // 9: colocar cámara en titulo
        // 11: habitación lore

        private float speed;
        private Vector3 direction;
        private float finalZoom;

        private int currentDirection = 999;

        private void Awake()
        {
            //Se suscribe a los sujetos que sean necesarios
            playerGO.GetComponent<ControlManager>().CameraHandler += ExecuteCameraMovement;
            throneGO.GetComponent<Interactuable_Throne>().CameraHandler += ExecuteCameraMovement;
            dramaticScreenGO.GetComponent<ManageDramaticScreen>().CameraHandler += ExecuteCameraMovement;
        }

        public void ConnectJudgeStateHandler(State_Judge state)
        {
            state.CameraHandler += ExecuteCameraMovement;
        }

        private void ProcessDirections(int i)
        {
            if(currentDirection != i)
            {
                String[] processedDirections = directionsList[i].Split("_");
                if (processedDirections.Length == 3)
                {
                    String[] processedVector = processedDirections[0].Split(",");
                    this.direction = new Vector3(float.Parse(processedVector[0]) / 100, float.Parse(processedVector[1]) / 100, float.Parse(processedVector[2]));

                    this.speed = float.Parse(processedDirections[1]);
                    this.finalZoom = float.Parse(processedDirections[2]) / 100;
                }
                else
                {
                    Debug.LogError("ERROR AL PROCESAR DIRECCIONES DRAMATICAS. MENSAJE " + i + " NO DIVIDIDO EN 4 SECCIONES.");
                }

                currentDirection = i;
            }
        }

        public void ExecuteCameraMovement(object sender, int i)
        {
            GetComponent<CameraMovementManager>().SetEnableMovement(false);

            ProcessDirections(i);
            StartCoroutine(MoveLerp(this.transform.localPosition, direction, speed, finalZoom));
        }

        IEnumerator MoveLerp(Vector3 startingPoint, Vector3 destination, float moveSpeed, float zoom)
        {
            float elapsed = 0;
            float initialZoom = GetComponent<Camera>().orthographicSize;
            while (elapsed <= 1)
            {
                GetComponent<Camera>().orthographicSize = Mathf.Lerp(initialZoom, zoom, elapsed);

                this.transform.localPosition = Vector3.Lerp(startingPoint, destination, elapsed);
                elapsed += (0.01f * moveSpeed * Time.deltaTime);

                //Debug.Log("Camara moviendose");

                yield return null;
            }

            yield return null;
        }

        public void CallFadeIn()
        {
            GetComponentInChildren<ManageFade>().FadeIn();
        }

        public void CallFadeOut()
        {
            GetComponentInChildren<ManageFade>().FadeOut();
        }
    }
}
