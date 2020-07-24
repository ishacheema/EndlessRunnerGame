using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;


    private float platformWidth;


    public float distanceBetweenMin;
    public float distanceBetweenMax;

    
    // public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;


    public ObjectPooler[] theObjectPools;


    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomAlThreshold;
    public ObjectPooler AlPooler;

    public float randomWilsonThreshold;
    public ObjectPooler WilsonPooler;

    public ObjectPooler powerupJournal1Pool;
    public ObjectPooler powerupJournal2Pool;
    public ObjectPooler powerupJournal3Pool;
    public ObjectPooler powerupKellawanPool;
    public float powerupThreshold;


    // Use this for initialization
    void Start()
    {


        platformWidths = new float[theObjectPools.Length];


        for (int i = 0; i < theObjectPools.Length; i++)
        {


            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;


        }


        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;


        theCoinGenerator = FindObjectOfType<CoinGenerator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {


            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);


            platformSelector = Random.Range(0, theObjectPools.Length);


            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);


            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }


           
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);


          


            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();


            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomAlThreshold)
            {
                GameObject newAl = AlPooler.GetPooledObject();

                float alXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 alPosition = new Vector3(alXPosition, 0.5f, 0f);

                newAl.transform.position = transform.position + alPosition;
                newAl.transform.rotation = transform.rotation;
                newAl.SetActive(true);
            }

            if (Random.Range(0f, 100f) < randomWilsonThreshold)
            {
                GameObject newWilson = WilsonPooler.GetPooledObject();

                float wilsonXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 wilsonPosition = new Vector3(wilsonXPosition, 0.6f, 0f);

                newWilson.transform.position = transform.position + wilsonPosition;
                newWilson.transform.rotation = transform.rotation;
                newWilson.SetActive(true);
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newJ1Powerup = powerupJournal1Pool.GetPooledObject();

                float powerupJ1XPosition = Random.Range(-platformWidths[platformSelector] / 2f - 1f, platformWidths[platformSelector] / 2f + 1f);

                Vector3 powerupJ1Position = new Vector3(powerupJ1XPosition, 1.2f, 0f);

                newJ1Powerup.transform.position = transform.position + powerupJ1Position;
                newJ1Powerup.transform.rotation = transform.rotation;
                newJ1Powerup.SetActive(true);
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newJ2Powerup = powerupJournal2Pool.GetPooledObject();

                float powerupJ2XPosition = Random.Range(-platformWidths[platformSelector] / 2f - 1f, platformWidths[platformSelector] / 2f + 1f);

                Vector3 powerupJ2Position = new Vector3(powerupJ2XPosition, 1.2f, 0f);

                newJ2Powerup.transform.position = transform.position + powerupJ2Position;
                newJ2Powerup.transform.rotation = transform.rotation;
                newJ2Powerup.SetActive(true);
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newJ3Powerup = powerupJournal3Pool.GetPooledObject();

                float powerupJ3XPosition = Random.Range(-platformWidths[platformSelector] / 2f - 1f, platformWidths[platformSelector] / 2f + 1f);

                Vector3 powerupJ3Position = new Vector3(powerupJ3XPosition, 1.2f, 0f);

                newJ3Powerup.transform.position = transform.position + powerupJ3Position;
                newJ3Powerup.transform.rotation = transform.rotation;
                newJ3Powerup.SetActive(true);
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newKellawanPowerup = powerupKellawanPool.GetPooledObject();

                float powerupKellawanXPosition = Random.Range(-platformWidths[platformSelector] / 2f - 1f, platformWidths[platformSelector] / 2f + 1f);

                Vector3 powerupKellawanPosition = new Vector3(powerupKellawanXPosition, 1.2f, 0f);

                newKellawanPowerup.transform.position = transform.position + powerupKellawanPosition;
                newKellawanPowerup.transform.rotation = transform.rotation;
                newKellawanPowerup.SetActive(true);
            }

           // if()

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


        }


    }
}
