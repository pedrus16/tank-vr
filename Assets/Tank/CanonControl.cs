using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class CanonControl : MonoBehaviour
    {
        public float rotationRatio = 1.0f;
        public float angle = 0.0f;

        public Transform cannon;

        private CircularDrive circularDrive;

        // Start is called before the first frame update
        void Start()
        {
            circularDrive = GetComponent<CircularDrive>();
        }

        // Update is called once per frame
        void Update()
        {
            if (circularDrive)
            {
                angle = circularDrive.outAngle * rotationRatio;
                cannon.localEulerAngles = new Vector3(angle, cannon.localEulerAngles.y, cannon.localEulerAngles.z);
            }
        }
    }
}