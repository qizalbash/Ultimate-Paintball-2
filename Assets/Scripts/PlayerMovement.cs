using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float jumpHeight = 3f;

    [SerializeField] float gravity = -9.81f;

    [SerializeField] LayerMask groundMask = 0;

    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;
    Vector3 groundCheck;
    float groundDistance;

    private void Start()
    {
        // Declare some variables
        // We don't have to check if GetComponent<CharacterController>() returns null because we used a [RequireComponent] attribute.
        controller = GetComponent<CharacterController>();
        groundDistance = controller.radius + controller.skinWidth + 0.0001f;
        // The +0.0001f may not be necessary but I'm putting it in to hopefully avoid any errors with this later
    }

    void Update()
    {
        // Check if grounded
        groundCheck = transform.position;
        groundCheck += new Vector3(0f, controller.radius, 0f);
        isGrounded = Physics.CheckSphere(groundCheck, groundDistance, groundMask);

        // Set slope limit to normal if on ground
        if (isGrounded && velocity.y < 0)
        {
            controller.slopeLimit = 45.0f;
            velocity.y = -9.81f;
        }

        // Get movement inputs
        float _x = Input.GetAxis("Horizontal");
        float _z = Input.GetAxis("Vertical");

        // Normalize movements
        Vector3 move = transform.right * _x + transform.forward * _z;
        float magnitude = Mathf.Clamp01(move.magnitude);
        move = Vector3.Normalize(move) * magnitude;

        // Move
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump if on ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Do gravity stuff
        // Time.deltaTime is used twice because gravity on earth uses time squared
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // If player hits their head then reset gravity
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            velocity.y = -9.81f;
        }
    }
}