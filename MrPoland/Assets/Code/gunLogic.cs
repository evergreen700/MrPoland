using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLogic : MonoBehaviour {
    public GameObject player;
    public GameObject gun;
    public GameObject bullet;
    public GameObject bulletClone;
    Vector3 position;
    public float speed = 5f;
    private float timeCount;

    //shooting vars
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask notToHit;
    public bool coll = false;

    float timeToFire = 0;
	// Use this for initialization
	void Start () {
        position = new Vector3(-0.5f, -0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update () {

        gun.transform.position = player.transform.position + position;
        mouseControl();
        if(coll)
        {
            Destroy(bulletClone);
        }
     }
    void mouseControl()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, speed * Time.deltaTime);
        if (Input.GetButton("Fire1"))
        {
            bulletLogic(rotation);
        }
    }
    void bulletLogic(Quaternion rotation)
    {
        bulletClone = Instantiate(bullet, transform.position, Quaternion.Slerp(gun.transform.rotation, rotation, speed * Time.deltaTime));
        bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * 5000);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        coll = true;
    }
}
