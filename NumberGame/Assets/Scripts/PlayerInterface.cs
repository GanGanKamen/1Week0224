using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public enum SlideDirection
    {
        Non,
        Up,
        Down,
        Left,
        Right
    }

    public class PlayerInterface : MonoBehaviour
    {
        public bool InputSlide { get { return GetSlideCheck(); } }
        public bool InputIsPress { get { return isPress; } }
        public SlideDirection InputSlideDirection { get { return slideDirection; } }

        [SerializeField] private GameObject controllerObject;
        [SerializeField] private Image[] directionIcons;
        [SerializeField] private float slideDistance;
        [SerializeField] private Vector2 touchLimitRangeX;
        [SerializeField] private Vector2 touchLimitRangeY;

        [SerializeField]private SlideDirection slideDirection = SlideDirection.Non;
        private bool isPress = false;
        private Vector2 startPosition;
        private Vector2 nowMousePosition;
        [SerializeField]private int slideCountPre = 0;
        [SerializeField]private int slideCount = 0;

        private Camera uiCamera;
        // Start is called before the first frame update
        private void Awake()
        {
            if (GameObject.FindGameObjectWithTag("UICamera") == null)
                uiCamera = Camera.main;

            else uiCamera = GameObject.FindGameObjectWithTag("UICamera")
                    .GetComponent<Camera>();
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            MouseOperate();
        }

        private void MouseOperate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = uiCamera
                    .ScreenToViewportPoint(Input.mousePosition);
                if (mousePos.x < touchLimitRangeX.x ||
                    mousePos.x > touchLimitRangeX.y ||
                    mousePos.y < touchLimitRangeY.x ||
                    mousePos.y > touchLimitRangeY.y) return;
                controllerObject.SetActive(true);
                startPosition = mousePos;
                isPress = true;
            }

            if(Input.GetMouseButton(0) && isPress)
            {
                nowMousePosition = uiCamera
                    .ScreenToViewportPoint(Input.mousePosition);
                var distanceFromStart = Vector2.Distance(startPosition, nowMousePosition);
                if(distanceFromStart >= slideDistance)
                {
                    var angle = GetAngle(startPosition, nowMousePosition);
                    if (angle <= 135 && angle > 45)
                    {
                        slideDirection = SlideDirection.Up;
                        SetTargetIcon(0);
                    }
                    else if (angle <= 45 && angle > -45)
                    {
                        slideDirection = SlideDirection.Right;
                        SetTargetIcon(3);
                    }
                    else if (angle <= -45 && angle > -135)
                    {
                        slideDirection = SlideDirection.Down;
                        SetTargetIcon(1);
                    }
                    else
                    {
                        slideDirection = SlideDirection.Left;
                        SetTargetIcon(2);
                    }
                }
                else
                {
                    slideDirection = SlideDirection.Non;
                    IconSizeReset();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                IconSizeReset();
                controllerObject.SetActive(false);
                Debug.Log(slideDirection);
                if (slideDirection != SlideDirection.Non) slideCount += 1;
                isPress = false;
            }
        }

        private void SetTargetIcon(int num)
        {
            for (int i = 0; i < directionIcons.Length; i++)
            {
                directionIcons[i].rectTransform.localScale = Vector3.one;
            }
            directionIcons[num].rectTransform.localScale = Vector3.one * 1.5f;
        }

        private void IconSizeReset()
        {
            for(int i = 0; i < directionIcons.Length; i++)
            {
                directionIcons[i].rectTransform.localScale = Vector3.one;
            }
        }

        private bool GetSlideCheck()
        {
            if(slideCount != slideCountPre)
            {
                slideCountPre = slideCount;
                return true;
            }
            else
            {
                return false;
            }
        }

        private float GetAngle(Vector2 start, Vector2 target)
        {
            Vector2 dt = target - start;
            float rad = Mathf.Atan2(dt.y, dt.x);
            float degree = rad * Mathf.Rad2Deg;

            return degree;
        }
    }
}
