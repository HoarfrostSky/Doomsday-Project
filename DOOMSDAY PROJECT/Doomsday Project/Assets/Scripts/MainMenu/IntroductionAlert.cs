using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class IntroductionAlert : MonoBehaviour
    {

        private bool finished = false;

        public void ChangeFinished()
        {
            this.finished = !finished;
        }

        public bool GetFinished()
        {
            return this.finished;
        }
    }
}
