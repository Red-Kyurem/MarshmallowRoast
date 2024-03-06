using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace team18
{
    public class InputManager : MicrogameInputEvents
    {
        GameObject campfire;

        public Vector2 direction;
        bool button1Held = false;
        bool button2Held = false;

        HingeJoint hingeJoint;

        // Start is called before the first frame update
        void Start()
        {
            // Tag0 is the campfire
            campfire = GameObject.FindGameObjectWithTag("Tag0");

            hingeJoint = GetComponent<HingeJoint>();
            hingeJoint.useMotor = false;

            // the position the marshmellow stick will look at
            Vector3 lookAtPos = campfire.transform.position;
            lookAtPos.y = transform.position.y;

            transform.LookAt(lookAtPos);
            Debug.Log("hello!");
        }

        // Update is called once per frame
        void Update()
        {
            direction = GetStickDirection();

            button1Held = GetButton1Input();
            button2Held = GetButton2Input();

            if (button1Held)
            {
                hingeJoint.useMotor = true;
            }
            else
            { 
                hingeJoint.useMotor = false;
            }
        }

        Vector2 GetStickDirection()
        { 
            return stick.normalized;
        }

        bool GetButton1Input()
        {
            if (button1.IsPressed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool GetButton2Input()
        {
            if (button2.IsPressed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
