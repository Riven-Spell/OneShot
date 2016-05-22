using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    // Update is called once per frame
    public GameObject camera;
    public GameObject bullet;
	bool hasBullet = false;

    public bool isCharging = false;
	int charged = 0;

    public override void OnStartLocalPlayer() {
        camera.SetActive(true);
    }

    void Start() {
        InvokeRepeating("Charge", 0.0f, 1.0f);
    }

    void Charge()
    {
        if (isCharging)
            charged += 1;
		Debug.Log (charged);
    }

    void Fire()
    {
        if (hasBullet)
        {
			GameObject b = (GameObject) GameObject.Instantiate (bullet, transform.position + (transform.forward * 2), transform.rotation);
			b.GetComponent<Rigidbody> ().AddForce (transform.forward * (600 * charged));
			hasBullet = false;
		}
    }

    void Update() {
        if (!isLocalPlayer)
            return;

        gameObject.transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Mouse X"));
        gameObject.transform.position += gameObject.transform.forward * (Input.GetAxis("Vertical") * 0.1f);
        gameObject.transform.position += gameObject.transform.right * (Input.GetAxis("Horizontal") * 0.1f);
<<<<<<< HEAD
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            gameObject.transform.position += Vector3.up;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * -10);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position += Vector3.up;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 10);
=======

		if (Input.GetAxis("Fire1") > 0)
        {
            isCharging = true;
            if (charged >= 9)
            {
				Fire ();
            }
        }
        else
        {
			if (isCharging)
				Fire ();
            isCharging = false;
            charged = 0;
>>>>>>> origin/master
        }
        //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * 10, 0, Input.GetAxis("Vertical") * 10));
    }

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "bulletpickup") {
			hasBullet = true;
			Destroy (collision.gameObject);
		}

        if (collision.gameObject.tag == "bullet")
        {
            //DEATH STRIKES!
            camera.transform.SetParent(GameObject.Find("SpecPoint").transform);
            camera.transform.localPosition = new Vector3(0, 0, 0);
            camera.transform.localRotation = Quaternion.identity;
            Destroy(gameObject);
        }
	}
}





