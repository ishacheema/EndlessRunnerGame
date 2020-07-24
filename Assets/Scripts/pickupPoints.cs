using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource coinSound;
    private AudioSource powerupSound;

	// Use this for initialization
	void Start () {

        theScoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();

        powerupSound = GameObject.Find("PowerupSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);

            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            } else     
            {

                coinSound.Play();
            }

            if (powerupSound.isPlaying)
            {
                powerupSound.Stop();
                powerupSound.Play();
            }
            else
            {

                powerupSound.Play();
            }

        }
    }

}
