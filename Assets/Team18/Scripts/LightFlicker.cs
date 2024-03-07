using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team18
{
    public class LightFlicker : MonoBehaviour
    {
        public float lowestIntensity = 1;
        public float highestIntensity = 1;

        public float diff = 1;

        Light changedLight;

        private void Start()
        {
            changedLight = GetComponent<Light>();
        }

        // Update is called once per frame
        void Update()
        {
            float newIntensity = changedLight.intensity + Random.Range(-diff, diff);

            if (newIntensity < lowestIntensity)
            { 
                newIntensity = lowestIntensity; 
            }
            else if (newIntensity > highestIntensity)
            {
                newIntensity = highestIntensity;
            }

            changedLight.intensity = newIntensity;
        }
    }
}
