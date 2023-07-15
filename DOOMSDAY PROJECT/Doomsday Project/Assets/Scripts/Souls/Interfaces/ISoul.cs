using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Souls.Interfaces
{
    public interface ISoul
    {
        public int GetID();
        public bool GetInteractuable();
        public void SendDialogue();
    }
}
