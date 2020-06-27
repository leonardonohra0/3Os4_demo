using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject bird;
    public GameObject[] spawnpoints;

    public bool can_spawn;
    public float time;
    public int spawn_id;

	// Use this for initialization
	void Start () {

        spawnpoints = GameObject.FindGameObjectsWithTag("spawn");
        can_spawn = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (can_spawn)
        {
            can_spawn = false;
            time = Random.Range(1.0f, 4.0f);
            Invoke("ResetSpawn", time);
        }

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);

    }

    void ResetSpawn()
    {
        can_spawn = true;

        spawn_id = Random.Range(0, 6);
        Instantiate(bird, spawnpoints[spawn_id].transform.position, spawnpoints[spawn_id].transform.rotation);
    }
}
