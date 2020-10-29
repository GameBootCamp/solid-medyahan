using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] private float jumpForce = 3.5f;

    [SerializeField] private Transform cam;

    [SerializeField] private bool isGrounded;

    private bool isDead;
    private bool canDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Reset();
        isDead = false;
    }


    void Update()
    {
        Jump();

    }

    void FixedUpdate()
    {
        Move();
        transform.rotation = Quaternion.Lerp(transform.rotation, cam.transform.rotation, 0.1f); // Camera
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "floor")
        {
            isGrounded = true;
        }

        if(col.gameObject.tag == "area")
        {
            this.gameObject.SetActive(false);
            GameOver();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }

    private void Move()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * playerSpeed * Time.deltaTime;
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPos);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            canDoubleJump = true;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                    
            }
            
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                canDoubleJump = false;
            }
                
        }
    }

    private void GameOver()
    {
        isDead = true;
    }

    public void Reset()
    {
        gameObject.transform.position = new Vector3(0.0f, 1.59f, -5f);
    }

}

