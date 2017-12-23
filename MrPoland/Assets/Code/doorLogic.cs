using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogic : MonoBehaviour {
    GameObject door;
    GameObject opendoor;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        door.SetActive(false);
        opendoor.SetActive(true);
    }
}
