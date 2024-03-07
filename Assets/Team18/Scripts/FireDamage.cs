using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team18
{
    public class FireDamage : MonoBehaviour
    {
        public float damageAmount = 0;
        public bool playWarningSound = false;

        AudioSource warningAudio;

        // Start is called before the first frame update
        void Start()
        {
            warningAudio = GetComponent<AudioSource>();
            warningAudio.Play();
            warningAudio.Pause();
        }

        // Update is called once per frame
        void Update()
        {

            RaycastHit[] hits = Physics.BoxCastAll(transform.position, transform.lossyScale/2, Vector3.down, Quaternion.identity, 1, LayerMask.GetMask("Detect Hazard"));

            bool isHit = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.GetComponent<BurnableAsset>())
                {
                    isHit = true;
                    BurnableAsset BA = hit.collider.GetComponent<BurnableAsset>();
                    BA.RemoveHealth(damageAmount);
                }
            }
            if (isHit && playWarningSound && !warningAudio.isPlaying)
            {
                warningAudio.UnPause();
            }
            else if(!isHit && playWarningSound)
            {
                warningAudio.Pause();
            }
        }
    }
}
