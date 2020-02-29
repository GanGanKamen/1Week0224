using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class NumberManager : MonoBehaviour
    {
        public GameObject numberSix;

        [SerializeField] PlayerInterface playerInterface;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GetInterface();
        }

        private void GetInterface()
        {
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


