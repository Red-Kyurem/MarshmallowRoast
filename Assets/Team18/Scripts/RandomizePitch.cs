using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team18
{
    public class RandomizePitch : MonoBehaviour
    {
        public float lowestPitch = 100;
        public float highestPitch = 100;

        public float lowestVolume = 1;
        public float highestVolume = 1;


        AudioSource source;
        // Start is called before the first frame update
        void Start()
        {
            source = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (source.isPlaying)
            {
                source.pitch = Random.Range(lowestPitch, highestPitch);
                source.volume = Random.Range(lowestVolume, highestVolume);
            }
        }
    }
}
