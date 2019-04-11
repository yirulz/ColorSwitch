using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class Death : MonoBehaviour
    {

        void onTriggerEnter(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}