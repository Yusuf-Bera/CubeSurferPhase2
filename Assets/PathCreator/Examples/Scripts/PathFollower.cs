using UnityEngine;

namespace PathCreation.Examples
{
    using UnityEngine;
    using PathCreation;

    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public float forwardSpeed = 10f;
        public float turnSpeed = 10f;
        public float maxHorizontalOffset = 5f;

        private float distanceTravelled;
        private float horizontalOffset = 0f;

        private Vector2 touchStartPosition;

        private void Start()
        {
            if (pathCreator != null)
            {
                transform.position = pathCreator.path.GetPointAtDistance(0);
            }
        }

        private void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += forwardSpeed * Time.deltaTime;
                Vector3 positionT = new Vector3(pathCreator.path.GetPointAtDistance(distanceTravelled).x,transform.position.y, pathCreator.path.GetPointAtDistance(distanceTravelled).z);
                transform.position = positionT;
                Quaternion rotations = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                rotations.z = 0f;
                transform.rotation = rotations;

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        touchStartPosition = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        float horizontalInput = (touch.position.x - touchStartPosition.x)*20 / Screen.width;
                        horizontalOffset = Mathf.Clamp(horizontalInput, -maxHorizontalOffset, maxHorizontalOffset);
                    }
                }

                Vector3 newPosition = transform.position + transform.right * horizontalOffset;
                transform.position = newPosition;
            }
        }
    }

}