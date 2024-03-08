using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Team18
{
    public class CalcPoints : MonoBehaviour
    {
        public int pointsTotal = 0;
        GameObject[] marshmellows;

        [Range(0f, 1f)]
        public float uncookedBadScoreThresh = 0.1f;
        [Range(0f, 1f)]
        public float cookedBadScoreThresh = 0.85f;
        [Range(0f, 1f)]
        public float uncookedOkScoreThresh = 0.25f;
        [Range(0f, 1f)]
        public float cookedOkScoreThresh = 0.75f;
        [Range(0f, 1f)]
        public float uncookedGoodScoreThresh = 0.40f;
        [Range(0f, 1f)]
        public float cookedGoodScoreThresh = 0.60f;
        public GameObject scorePrefab;

        GameObject badImage;
        GameObject okImage;
        GameObject perfectImage;
        GameObject pointsText;

        public void CalcPointsStart(GameObject[] marshmellowArray, PlayerSide playerSide)
        {
            Vector3 offset = Vector3.zero;

            if (playerSide == PlayerSide.Left)
            {
                offset = Vector3.left * 350 + Vector3.down * 350;
            }
            else if (playerSide == PlayerSide.Right)
            {
                offset = Vector3.right * 350 + Vector3.down * 350;
            }
            

            Transform parent = GameObject.FindGameObjectWithTag("Tag1").transform;
            GameObject newScorePrefab = Instantiate(scorePrefab, parent);

            newScorePrefab.transform.position += offset;

            badImage = newScorePrefab.transform.GetChild(0).gameObject;
            okImage = newScorePrefab.transform.GetChild(1).gameObject;
            perfectImage = newScorePrefab.transform.GetChild(2).gameObject;
            pointsText = newScorePrefab.transform.GetChild(3).gameObject;

            badImage.SetActive(false);
            okImage.SetActive(false);
            perfectImage.SetActive(false);

            pointsText.GetComponent<TextMeshProUGUI>().text = "pts.";
            pointsText.SetActive(false);

            CalcMarshmellowPoints(marshmellowArray);
        }

        public void CalcMarshmellowPoints(GameObject[] marshmellowArray)
        {
            marshmellows = marshmellowArray;

            foreach (GameObject m in marshmellows)
            {
                float healthPercentage = m.GetComponent<BurnableAsset>().currentHealth / m.GetComponent<BurnableAsset>().maxHealth;

                if (healthPercentage <= uncookedBadScoreThresh || healthPercentage >= cookedBadScoreThresh)
                {
                    pointsTotal += 0;
                }
                else if (healthPercentage <= uncookedOkScoreThresh || healthPercentage >= cookedOkScoreThresh)
                {
                    pointsTotal += 1;
                }
                else if (healthPercentage <= uncookedGoodScoreThresh || healthPercentage >= cookedGoodScoreThresh)
                {
                    pointsTotal += 2;
                }
                else
                {
                    pointsTotal += 3;
                }
            }

            // adds enough points to help players get 100 points, so long as they have a point
            if (pointsTotal != 0)
            {
                pointsTotal += 4;
            }

            if (pointsTotal <= 30)
            {
                badImage.SetActive(true);
            }
            else if (pointsTotal < 80)
            {
                okImage.SetActive(true);
            }
            else
            {
                perfectImage.SetActive(true);
            }

            pointsText.GetComponent<TextMeshProUGUI>().text = (pointsTotal + " pts.");
            pointsText.SetActive(true);
        }


    }
}
