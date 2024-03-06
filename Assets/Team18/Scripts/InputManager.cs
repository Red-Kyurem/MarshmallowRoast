using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team18
{
    public class InputManager : MicrogameInputEvents
    {
        GameObject campfire;
        // Start is called before the first frame update
        void Start()
        {
            // Tag0 is the campfire
            campfire = GameObject.FindGameObjectWithTag("Tag0");

            // the position the marshmellow stick will look at
            Vector3 lookAtPos = campfire.transform.position;
            lookAtPos.y = transform.position.y;

            transform.LookAt(lookAtPos);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void DetectSpinning()
        { 
        
        }
    }
}
