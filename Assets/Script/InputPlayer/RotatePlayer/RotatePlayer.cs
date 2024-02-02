using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Input
{
    public class RotatePlayer : MonoBehaviour
    {
        [SerializeField] private RotatseSetting settings;
        [SerializeField] private Camera cameraComponent;
        [SerializeField] private GameObject childGameObject;
        private float rotateSpeed,angle;
        private Vector2 currentMousePosition, direction;
        private Vector3 worldMousePosition;
        private Vector3 scale;
        private bool isMoveTrigger, isFlipTrigger;
        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        [Inject]
        public void Init(IInput x)
        {
            inputData = x;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            rotateSpeed = settings.RotateSpeed;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                isRun = true;
            }
        }
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Rotate();
        }
        private void Rotate()
        {
            currentMousePosition = (Vector2)inputData.Updata().MousePosition;
            worldMousePosition = cameraComponent.ScreenToWorldPoint(currentMousePosition);
            direction = worldMousePosition - gameObject.transform.position;
            angle = Vector2.SignedAngle(Vector2.right, direction);
            Debug.Log(angle);

            if ((angle > 90 || angle < -90)& isFlipTrigger == true) {  Flip(); }
            if ((angle > 90 || angle < -90) & isFlipTrigger == false) { Flip(); }
            childGameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        }
        private void Flip()
        {
            isFlipTrigger = !isFlipTrigger;
            scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            //rbThisObject.velocity.magnitude
        }
    }
}

