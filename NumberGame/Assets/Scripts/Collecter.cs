using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Collecter : MonoBehaviour
    {
        private NumberManager number;
        // Start is called before the first frame update
        private void Awake()
        {
            number = transform.parent.parent.GetComponent<NumberManager>();
        }

        public void ScorePlus(int level)
        {
            number.score += 100 * level;
        }
    }
}


