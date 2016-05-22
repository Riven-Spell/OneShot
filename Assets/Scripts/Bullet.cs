using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject pickup;

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Environment") {
			Network.Instantiate (pickup, transform.position, transform.rotation,0);
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
