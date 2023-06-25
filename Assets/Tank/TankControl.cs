using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class TankControl : MonoBehaviour
    {
        public LinearMapping linearMappingLeft;
        public LinearMapping linearMappingRight;

        public float speed = 1.0f;
        public float angularSpeed = 4.0f;

        public float throttleDeadzone = 0.1f;

        public Transform driverPosition;
        public Transform gunnerPosition;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float leftThrottle = (linearMappingLeft.value * 2) - 1.0f;
            float rightThrottle = (linearMappingRight.value * 2) - 1.0f;

            leftThrottle = RemapWithDeadzone(leftThrottle, throttleDeadzone);
            rightThrottle = RemapWithDeadzone(rightThrottle, throttleDeadzone);

            float forward = leftThrottle + rightThrottle; // Summed throttle from both levers;
            float rotation = leftThrottle - rightThrottle; // Net rotation from both levers;

            transform.Translate(Vector3.forward * forward * speed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotation * angularSpeed * Time.deltaTime);
        }

        /* Remap a linear value going from -1.0f to 1.0f and flatten the middle section which size correspond to the deadzone value */
        private static float RemapWithDeadzone(float value, float deadzone) 
        {
            if (Mathf.Abs(value) < deadzone) {
                return 0;
            }

            return (Mathf.Abs(value) - deadzone) / (1.0f - deadzone) * Mathf.Sign(value);
        }

    }
}
