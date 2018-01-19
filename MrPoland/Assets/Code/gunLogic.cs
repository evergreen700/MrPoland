using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLogic : MonoBehaviour {
    public GameObject player;
    public GameObject gun;
    public Vector3 position;
	// Use this for initialization
	void Start () {
        position = new Vector3(3.0f, 0.0f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        gun.transform.position = player.transform.position + position;
    }
}
