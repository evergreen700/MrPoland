using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 10f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public bool isGrounded = true;
    public Vector3 jumpv;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        jumpv = new Vector3(0.0f, 27.0f, 0.0f);
    }
    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown("space") && isGrounded)
          {
            rb2d.AddForce(jumpv, ForceMode2D.Impulse);
            isGrounded = false;
          }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}