using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorLogic : MonoBehaviour
    {
    GameObject door;



    // Use this for initialization
    void Start()
    {
        door = this.gameObject;
    
        GameObject.Find("opendoor").transform.localScale = new Vector3(0, 0, 0);
    }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D()
        {
if (GameObject.FindWithTag("door"))
        {
            Destroy(door);
        }

        GameObject.Find("opendoor").transform.localScale = new Vector3(1, 1, 1);
    }

}
