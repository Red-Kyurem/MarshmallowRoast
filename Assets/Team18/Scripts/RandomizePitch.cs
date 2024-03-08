using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team18
{
    public class RandomizePitch : MonoBehaviour
    {
        public float lowestPitch = 2.5f;
        public float highestPitch = 4f;

        public float lowestVolume = 0.75f;
        public float highestVolume = 1.25f;


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
