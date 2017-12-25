using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogic : MonoBehaviour {
    GameObject door;
    public bool open;

	// Use this for initialization
	void Start () {
        door = this.gameObject;

        open = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D()
    {

        GameObject.Destroy(door);
        open = true;

    }
}
