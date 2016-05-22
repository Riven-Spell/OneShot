using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject pickup;

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Environment") {
			GameObject.Instantiate (pickup, transform.position, transform.rotation);
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
