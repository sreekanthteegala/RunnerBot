using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float jumpForce = 6f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.55f;
    public LayerMask groundLayer;

    Rigidbody rb;
    public bool IsGrounded { get; private set; }
    public bool IsAlive { get; private set; } = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Constant forward movement on Z axis
        Vector3 vel = rb.linearVelocity;
        vel.z = forwardSpeed;
        rb.linearVelocity = new Vector3(vel.x, vel.y, vel.z);

        CheckGround();
    }

    void CheckGround()
    {
        if (groundCheck == null)
        {
            IsGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        }
        else
        {
            IsGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);
        }
    }

    public void Jump()
    {
        if (!IsAlive) return;

        if (IsGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            IsAlive = false;
        }
    }

    public void ResetPlayer(Vector3 startPosition)
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector3.zero;
        IsAlive = true;
    }
}
