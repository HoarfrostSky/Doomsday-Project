using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sword
{
    public class SwordScript : MonoBehaviour
    {
        public float weight;

        public void SetWeight(float n)
        {
            this.weight = n;
        }

        public float GetWeight()
        {
            return weight;
        }
    }
}