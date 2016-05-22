using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {
	public GameObject pickup;
	bool duped = false;

	[Command]
	void CmdReuse(){
		GameObject b = (GameObject) Instantiate (pickup, transform.position, transform.rotation);
		NetworkServer.Spawn (b);
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Environment" && !duped) {
			CmdReuse ();
			duped = true;
		}
	}

	// Use this for initialization
	void Start () {	
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
