using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Controls;

namespace States.Interfaces
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void Update();
        public String GetName();
    }
}
