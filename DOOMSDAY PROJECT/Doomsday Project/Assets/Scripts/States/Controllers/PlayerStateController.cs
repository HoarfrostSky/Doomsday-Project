using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controls;
using UnityEngine.Assertions;
using Unity.VisualScripting;
using States.Interfaces;
using States.ConcreteStates;
using IState = States.Interfaces.IState;

namespace States.Controllers
{
    public class PlayerStateController : MonoBehaviour, IPlayerState
    {
        public GameObject GO;

        private IState currentState;
        private IState previousState;
        private IState nextState;

        private void Awake()
        {
            SetState(new State_Title(this));
        }

        public GameObject GetGameObject()
        {
            return GO;
        }
        public Rigidbody2D GetRigidbody()
        {
            return this.gameObject.GetComponent<Rigidbody2D>();
        }

        public IState GetState()
        {
            return currentState;
        }

        public IState GetPreviousState()
        {
            return previousState;
        }

        public void SetState(IState state)
        {
            nextState = state;

            if(currentState != null)
            {
                currentState.Exit();
            }

            previousState = currentState;
            currentState = state;
            state.Enter();
        }

        private void Update()
        {
            currentState.Update();
        }

        public IState GetNextState()
        {
            return nextState;
        }
    }
}