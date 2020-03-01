using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Collecter : MonoBehaviour
    {
        private NumberManager number;
        private AudioSource audioSource;
        // Start is called before the first frame update
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            number = transform.parent.parent.GetComponent<NumberManager>();
        }

        public void ScorePlus(int level)
        {
            audioSource.PlayOneShot(audioSource.clip);
            number.score += 100 * level;
        }
    }
}


