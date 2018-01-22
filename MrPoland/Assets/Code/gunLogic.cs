using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLogic : MonoBehaviour {
    public GameObject player;
    public GameObject gun;
    Vector3 position;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        position = new Vector3(-0.5f, -0.5f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        gun.transform.position = player.transform.position + position;
    }

    void mouseControl()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, speed * Time.deltaTime);
    }
}
