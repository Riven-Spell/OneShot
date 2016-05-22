using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour {
    public GameObject prefab;
    public GameObject currentPlayerPrefab;

	// Update is called once per frame
	void Start () {
        PlayerDied();
	}

    void PlayerDied() {
        //if (!isLocalPlayer)
        //    return;
        GameObject sl = GameObject.Find("NM").GetComponent<SpawnService>().Spawn();
        currentPlayerPrefab = (GameObject) Instantiate(prefab, sl.transform.position, sl.transform.rotation);
    }
}
