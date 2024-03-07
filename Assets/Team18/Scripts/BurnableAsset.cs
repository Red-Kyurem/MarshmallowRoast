using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team18
{
    public class BurnableAsset : MonoBehaviour
    {

        public float currentHealth = 0;
        public float maxHealth = 100;

        public Gradient gradient;
        Material material;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            material = GetComponent<MeshRenderer>().material;


            ChangeGradientColour();
        }


        public void RemoveHealth(float amount)
        {
            currentHealth -= amount * Time.deltaTime;

            ChangeGradientColour();
        }

        // changes colour based on the object's remaining health
        void ChangeGradientColour()
        {
            float healthProgress = currentHealth / maxHealth;

            material.color = gradient.Evaluate(1 - healthProgress);
            
        }
    }
}
