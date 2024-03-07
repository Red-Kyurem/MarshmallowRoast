using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team18
{
    public class FireDamage : MonoBehaviour
    {
        public float damageAmount = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            RaycastHit[] hits = Physics.BoxCastAll(transform.position, transform.lossyScale/2, Vector3.down, Quaternion.identity, 1, LayerMask.GetMask("Detect Hazard"));

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.GetComponent<BurnableAsset>())
                {
                    BurnableAsset BA = hit.collider.GetComponent<BurnableAsset>();
                    BA.RemoveHealth(damageAmount);
                }
            }

        }
    }
}
