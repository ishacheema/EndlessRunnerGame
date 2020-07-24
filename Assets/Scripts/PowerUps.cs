using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

    public bool doublePoints;
    public bool triplePoints;
    public bool safeMode;
    public bool ultimatePowerup;

    public float powerupLength;

    private PowerUpsManager thepowerupsManager;


	// Use this for initialization
	void Start () {

        thepowerupsManager = FindObjectOfType<PowerUpsManager>();

	}



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {           
            thepowerupsManager.ActivatePowerup(doublePoints, triplePoints, ultimatePowerup, safeMode, powerupLength);
        }

        gameObject.SetActive(false);

    }


}
