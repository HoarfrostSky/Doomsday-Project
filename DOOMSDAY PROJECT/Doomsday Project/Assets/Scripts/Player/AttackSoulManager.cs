using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AttackSoulManager : MonoBehaviour
    {
        public void RegisterAttack()
        {
            GameObject.FindGameObjectWithTag("Soul").GetComponent<Animator>().SetTrigger("SoulDamage");
        }
    }
}
