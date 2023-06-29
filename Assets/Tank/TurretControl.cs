using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class TurretControl : MonoBehaviour
    {

        public Transform turret;

        public float rotationRatio = 1.0f;

        private CircularDrive circularDrive;

        // Start is called before the first frame update
        void Start()
        {
            circularDrive = GetComponent<CircularDrive>();
        }

        // Update is called once per frame
        void Update()
        {
            if (circularDrive && turret)
            {
                turret.localEulerAngles = new Vector3(turret.localEulerAngles.x, circularDrive.outAngle * rotationRatio, turret.localEulerAngles.z);
            }
        }
    }
}