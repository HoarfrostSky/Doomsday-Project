using System.Collections;
using System.Collections.Generic;
using States.Controllers;
using States.ConcreteStates;
using UnityEngine;

namespace CameraNamespace
{
    public class CameraMovementManager : MonoBehaviour
    {
        public GameObject player;
        public float offset;
        public float movementRange;
        public float movementSpeed;
        public float recoverySpeed;

        private Rigidbody2D rb;
        private int direction = 0;
        private int auxDirection = 0;
        private float n = 0;

        private bool enabledMovement = true;

        private void Awake()
        {
            rb = player.GetComponent<Rigidbody2D>();
        }

        public void RegisterPlayerMovement()
        {
            if(enabledMovement)
            {
                switch (rb.velocity.x)
                {
                    case var _ when rb.velocity.x < -movementRange:
                        direction = -1;
                        break;

                    case var _ when rb.velocity.x > movementRange:
                        direction = 1;
                        break;
                    default:
                        direction = 0;
                        n *= recoverySpeed;
                        break;
                }

                if (auxDirection != direction) n = 0;

                MoveCamera(transform.localPosition, new Vector3((offset * direction), this.transform.localPosition.y, this.transform.localPosition.z));

                auxDirection = direction;
            }
        }

        private void MoveCamera(Vector3 fPos, Vector3 lPos)
        {
            transform.localPosition = Vector3.Lerp(fPos, lPos, n);

            n += 0.001f * movementSpeed * Time.deltaTime;
            n = Mathf.Clamp(n, 0, 1);
        }

        public void SetEnableMovement(bool b)
        {
            this.enabledMovement = b;
        }
    }
}
