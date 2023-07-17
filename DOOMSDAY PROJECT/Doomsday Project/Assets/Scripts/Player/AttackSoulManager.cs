using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Souls.Interfaces;

namespace Player
{
    public class AttackSoulManager : MonoBehaviour
    {
        private int currentAttack = 0;
        private int maxAttacks = 1;
        GameObject soul;

        public void RegisterAttack()
        {
            soul = GameObject.FindGameObjectWithTag("Soul");
            maxAttacks = soul.GetComponent<ASoul>().maxAtaques;

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
                    Debug.Log("YA NO HAY MÁS ATAQUES");
                    break;
            }
        }

        public int GetCurrentAttack()
        {
            return currentAttack;
        }
    }
}
