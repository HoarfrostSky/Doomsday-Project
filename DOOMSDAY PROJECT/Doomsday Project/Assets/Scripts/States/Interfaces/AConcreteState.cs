using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Controls;
using States.Interfaces;
using Game;
using ControlManager = Controls.ControlManager;

namespace States.Interfaces
{
    public abstract class AConcreteState : IState
    {
        protected IPlayerState playerState;

        protected String name;

        protected GameObject playerGO;
        protected Rigidbody2D rb;
        protected ControlManager controlManager;

        protected GameManager gameManager;

        public AConcreteState(IPlayerState playerState)
        {
            this.playerState = playerState;
            this.playerGO = playerState.GetGameObject();
            this.rb = playerState.GetRigidbody();
            this.controlManager = playerGO.GetComponent<ControlManager>();
            this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public String GetName()
        {
            return name;
        }
    }
}
