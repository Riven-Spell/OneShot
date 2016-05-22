using UnityEngine;
using System.Collections;

public class SpawnService : MonoBehaviour {
    public GameObject[] spawns;

    public GameObject Spawn()
    {
        int i = Random.Range(0, spawns.Length - 1);
        return spawns[i];
    }
}
