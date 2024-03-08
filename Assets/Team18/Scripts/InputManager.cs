using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Team18
{
    public class InputManager : MicrogameInputEvents
    {
        GameObject campfire;
        GameObject childStick;

        public Vector2 direction;
        Vector2 lastDirection = Vector2.zero;
        List<Vector2> directionHistory = new List<Vector2>();
        Vector2[] directionArray = { 
            new Vector2(0, 1), 
            new Vector2(0.71f, 0.71f), 
            new Vector2(1, 0), 
            new Vector2(0.71f, -0.71f), 
            new Vector2(0, -1), 
            new Vector2(-0.71f, -0.71f), 
            new Vector2(-1, 0), 
            new Vector2(-0.71f, 0.71f) 
        };

        float turnSpeed = 0;

        bool button1Held = false;
        bool button2Held = false;

        HingeJoint joint;


        // Start is called before the first frame update
        void Start()
        {
            // Tag0 is the campfire
            campfire = GameObject.FindGameObjectWithTag("Tag0");
            childStick = transform.GetChild(0).gameObject;

            joint = GetComponent<HingeJoint>();
            joint.useMotor = false;

            // the position the marshmellow stick will look at
            Vector3 lookAtPos = campfire.transform.position;
            lookAtPos.y = transform.position.y;

            transform.LookAt(lookAtPos);
        }

        // Update is called once per frame
        private void Update()
        {
            direction = GetStickDirection();

            TurnMarshmallow();

            button1Held = GetButton1Input();
            button2Held = GetButton2Input();

            if (button1Held)
            {
                joint.useMotor = true;
            }
            else
            {
                joint.useMotor = false;
            }
        }

        Vector2 GetStickDirection()
        { 
            return stick.normalized;
        }

        void TurnMarshmallow()
        {
            if (direction != lastDirection && direction != Vector2.zero)
            {
                Vector3 offset = Vector3.up * 5 + Vector3.right * 2;

                Vector2 lastDirRounded;
                lastDirRounded.x = Round(lastDirection.x, 2);
                lastDirRounded.y = Round(lastDirection.y, 2);

                // find the index of the rounded last direction in the directionArray
                int dirIndex = 0;
                foreach (Vector2 dir in directionArray)
                {
                    if (lastDirRounded == dir)
                    {
                        break;
                    }
                    dirIndex++;
                }


                for (int directionNum = 1; directionNum < 4; directionNum++)
                {
                    int highIndex = (dirIndex + directionNum) % 8;
                    int lowIndex = (dirIndex - directionNum) % 8;
                    if (lowIndex < 0) { lowIndex = 8 - directionNum; }

                    if (directionArray[highIndex] == direction)
                    {
                        turnSpeed += 0.75f;
                        break;
                    }
                    else if (directionArray[lowIndex] == direction)
                    {
                        turnSpeed -= 0.75f;
                        break;
                    }
                }

                if (direction != Vector2.zero)
                {
                    lastDirection = direction;
                    directionHistory.Add(direction);
                }
            }

            childStick.transform.Rotate(Vector3.up, turnSpeed);

            turnSpeed = Mathf.Lerp(turnSpeed, 0, Time.deltaTime);
        }

        float Round(float value, int decimalPlaces)
        {
            return Mathf.Round(value * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
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

        protected override void OnTimesUp()
        {
            Invoke("CallCalcPoints", 0.5f);
        }

        void CallCalcPoints()
        {
            transform.GetChild(0).GetChild(0).GetComponentInChildren<BurnableAsset>();
            List<GameObject> marshmellows = new List<GameObject>();

            foreach (Transform m in transform.GetChild(0).GetChild(0))
            {
                marshmellows.Add(m.gameObject);
            }

            gameObject.GetComponent<CalcPoints>().CalcMarshmellowPoints(marshmellows.ToArray());
        }
    }


}
