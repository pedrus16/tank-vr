using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Canon : MonoBehaviour
    {
        public Player player;
        public SteamVR_Action_Boolean fireAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Fire");

        public GameObject shell;

        private Transform muzzle;

        // Start is called before the first frame update
        void Start()
        {
            muzzle = transform.Find("Muzzle");
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(player.leftHand.handType);
            Debug.Log(fireAction);
            if (fireAction.GetStateDown(player.leftHand.handType))
            {
                GameObject projectile = Instantiate(shell, muzzle.position,
                                                     muzzle.rotation);
                projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * 200.0f;
            }
        }
    }
}
