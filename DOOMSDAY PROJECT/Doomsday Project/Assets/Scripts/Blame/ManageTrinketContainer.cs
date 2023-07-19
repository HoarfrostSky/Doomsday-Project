using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blame
{
    public class ManageTrinketContainer : MonoBehaviour
    {
        public void Relocate(Vector3 newPosition)
        {
            this.transform.position = newPosition;
        }
    }
}
