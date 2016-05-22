using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    // Update is called once per frame
    public GameObject camera;

    public override void OnStartLocalPlayer() {
        camera.SetActive(true);
    }


    void Update () {
        if (!       isLocalPlayer)
            return;

        gameObject.transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Mouse X"));
    }
}
