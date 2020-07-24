using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject plaftormDestructionPoint;


	// Use this for initialization
	void Start () {

        plaftormDestructionPoint = GameObject.Find("PlatformDestructionPoint");


            	}
	
	// Update is called once per frame
	void Update () {
	
        if (transform.position.x < plaftormDestructionPoint.transform.position.x)
        {


            gameObject.SetActive(false);

        }

	}
}
