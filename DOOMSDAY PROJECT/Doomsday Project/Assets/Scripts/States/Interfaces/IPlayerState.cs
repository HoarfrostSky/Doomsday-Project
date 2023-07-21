using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States.Interfaces
{
    public interface IPlayerState
    {
        public GameObject GetGameObject();
        public Rigidbody2D GetRigidbody();

        //State Management
        public void SetState(IState state);
        public IState GetState();
        public IState GetPreviousState();
        public IState GetNextState();
    }
}
