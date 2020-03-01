using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class NumberManager : MonoBehaviour
    {
        public GameObject numberSix;
        public int score;
        [SerializeField] PlayerInterface playerInterface;
        public bool isApp = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Appearance();
            GetInterface();
        }

        private void Appearance()
        {
            if (numberSix.transform.localScale.x < 1)
            {
                numberSix.transform.localScale += Vector3.one * Time.deltaTime;
            }
            else
            {
                numberSix.transform.localScale = Vector3.one;
                isApp = true;
            }
        }

        private void GetInterface()
        {
            if (isApp == false) return;
            if (playerInterface.InputSlide)
            {
                switch (playerInterface.InputSlideDirection)
                {
                    case SlideDirection.Up:
                        FlipVertical();
                        break;
                    case SlideDirection.Down:
                        FlipVertical();
                        break;
                    case SlideDirection.Left:
                        FlipHorizontal();
                        break;
                    case SlideDirection.Right:
                        FlipHorizontal();
                        break;
                }
            }
        }

        private void FlipVertical()
        {
            numberSix.transform.Rotate(180, 0, 0);
        }

        private void FlipHorizontal()
        {
            numberSix.transform.Rotate(0, 180, 0);
        }
    }
}


