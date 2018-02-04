using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLogic : MonoBehaviour {
    public GameObject player;
    public GameObject gun;
    Vector3 position;
    public float speed = 5f;


    //shooting vars
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask notToHit;

    float timeToFire = 0;
	// Use this for initialization
	void Start () {
        position = new Vector3(-0.5f, -0.5f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        gun.transform.position = player.transform.position + position;
        mouseControl();
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 fire = new Vector2(gun.transform.position.x, gun.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(fire, mousePosition - fire, 100, notToHit);
    }
    void mouseControl()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, speed * Time.deltaTime);
        
    }
}
