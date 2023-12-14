using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Souls.Interfaces;

namespace Player
{
    public class AttackSoulManager : MonoBehaviour
    {
        private int currentAttack = 0;
        private int maxAttacks;
        GameObject soul;

        public void RegisterAttack()
        {
            soul = GameObject.FindGameObjectWithTag("Soul");
            maxAttacks = soul.GetComponent<ASoul>().maxAtaques;
            Debug.Log("Ataques maximos: " + maxAttacks);

            switch(currentAttack)
            {
                case 0:
                    soul.GetComponent<Animator>().SetTrigger("SoulDamage");
                    currentAttack++;
                    break;
                case 1:
                    soul.GetComponent<Animator>().SetTrigger("SoulDamage2");
                    currentAttack++;
                    break;
                case 2:
                    soul.GetComponent<Animator>().SetTrigger("SoulDamage3");
                    currentAttack++;
                    break;
                default:
                    Debug.Log("YA NO HAY M�S ATAQUES");
                    break;
            }
        }

        public int GetCurrentAttack()
        {
            return currentAttack;
        }

        public int GetMaxAttacks()
        {
            return maxAttacks;
        }

        public void ResetCurrentAttack()
        {
            this.currentAttack = 0;
        }
    }
}
