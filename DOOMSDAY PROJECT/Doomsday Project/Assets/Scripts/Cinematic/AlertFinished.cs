using System.Collections;
using System.Collections.Generic;
using States.Controllers;
using States.ConcreteStates;
using Souls;
using Sword;
using UnityEngine;

namespace Cinematic
{
    public class AlertFinished : MonoBehaviour
    {
        private PlayerStateController playerStateController;

        private void Awake()
        {
            playerStateController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>();
        }
        public void FinishCinematicState()
        {
            playerStateController.SetState(new State_Dialogue(playerStateController));
        }

        public void AlertDarkToDestroy()
        {
            GameObject.FindGameObjectWithTag("Soul").GetComponentInChildren<SaveAnimationManager>().gameObject.GetComponent<Animator>().SetTrigger("DestroyAction");
            GameObject.Find("Dark1").GetComponent<Animator>().SetTrigger("CastSpell");
        }

        public void NextAttack()
        {
            Debug.Log("Se llama a NextAttack");
            GameObject sword = GameObject.FindGameObjectWithTag("Sword");
            sword.GetComponent<SwordScript>().SetWeight(sword.GetComponent<SwordScript>().GetWeight()*1.5f);

            StartCoroutine(ResetToCondemn());
        }

        IEnumerator ResetToCondemn()
        {
            Debug.Log("Se llama a ResetToCondemn");
            yield return new WaitForSeconds(1f);
            playerStateController.SetState(new State_Condemn(playerStateController));
            yield return null;
        }
    }
}
