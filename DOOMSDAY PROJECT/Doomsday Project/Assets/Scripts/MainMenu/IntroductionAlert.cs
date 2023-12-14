using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class IntroductionAlert : MonoBehaviour
    {

        public GameObject loadingTextGO;

        private bool finished = false;

        public void ChangeFinished()
        {
            this.finished = !finished;
        }

        public bool GetFinished()
        {
            return this.finished;
        }

        public void ShowLoadingText()
        {
            loadingTextGO.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
