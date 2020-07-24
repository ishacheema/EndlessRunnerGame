using UnityEngine;
using System.Collections;

public class PowerUpsManager : MonoBehaviour {

    private bool doublePoints;
    private bool triplePoints;
    private bool safeMode;
    private bool ultimatePowerup;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float enemyRate;

    private PlatformDestroyer[] enemyList;

    // Use this for initialization
    void Start () {

        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
	}
	
	// Update is called once per frame
	void Update () {

        if(powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (doublePoints) 
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2f;
                theScoreManager.shouldDouble = true;
            }

            if (triplePoints) 
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 3f;
                theScoreManager.shouldTriple = true;
            }

            if (ultimatePowerup)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 100f;
                theScoreManager.shouldMultiply = true;
            }

            if (safeMode) 
            {
                thePlatformGenerator.randomAlThreshold = 0f;
                thePlatformGenerator.randomWilsonThreshold = 0f;

            }


            if (powerupLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                thePlatformGenerator.randomAlThreshold = enemyRate;
                thePlatformGenerator.randomWilsonThreshold = enemyRate;

                theScoreManager.shouldDouble = false;
                theScoreManager.shouldTriple = false;
                theScoreManager.shouldMultiply = false;
                powerupActive = false;
            }



        }
	
	}

    public void ActivatePowerup(bool doublepoints, bool triplepoints, bool ultimatepowerup, bool safe, float time)
    {
        doublePoints = doublepoints;
        triplePoints = triplepoints;
        ultimatePowerup = ultimatepowerup;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        enemyRate = thePlatformGenerator.randomAlThreshold;
        enemyRate = thePlatformGenerator.randomWilsonThreshold;

        if (safeMode)
        {
            enemyList  = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < enemyList.Length; i++)
            {
                if (enemyList[i].gameObject.name.Contains("Wilson"))
                {
                    enemyList[i].gameObject.SetActive(false);
                }

                if (enemyList[i].gameObject.name.Contains("EvilAl"))
                {
                    enemyList[i].gameObject.SetActive(false);
                }
            }
        }
     

        powerupActive = true;
 }
}

