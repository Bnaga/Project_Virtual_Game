using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementScript : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float jumpHeight = 1;

    public float gravity = -10;
    private float _velocityY;
    private float _currentSpeed;

    public float turnSmoothTime = 0.2f;
    private float _turnSmoothVelocity;

    public float speedSmoothTime = 0.2f;
    private float _speedSmoothVelocity;

    [Range(0,1)]
    public float airControlPercent = 0.5f;

    public Animator animator;

    private Vector2 _input;
    private Vector2 _direction;

    private Transform _cameraTransform;

    private CharacterController _controller;
    private bool _isRagdolled;

    private Vector3 startPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        _cameraTransform = Camera.main.transform;
        _controller = GetComponent<CharacterController>();

        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R)) // R: reset player
        {
            resetPlayer();
        }

        if (_isRagdolled) return;

        if (transform.position.y < 0)
        {
            enterRagdoll();
        }
        if (Input.GetKey(KeyCode.F)) // F: manually enter ragdoll
        {
            enterRagdoll();
        }

        //movement direction depending on WASD/Arrow keys and camera rotation
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _direction = _input.normalized;

        if (_direction != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _turnSmoothVelocity, getSmoothValue(turnSmoothTime));
        }

        //speed calculation
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * _direction.magnitude;
        _currentSpeed = Mathf.SmoothDamp(_currentSpeed, targetSpeed, ref _speedSmoothVelocity, getSmoothValue(speedSmoothTime));

        _velocityY += gravity * Time.deltaTime;
        Vector3 velocity = transform.forward * _currentSpeed + Vector3.up * _velocityY;
        _controller.Move(velocity * Time.deltaTime);

        float currentVelocity = new Vector2(_controller.velocity.x, _controller.velocity.z).magnitude;


        if (_controller.isGrounded)
        {
            _velocityY = 0;
        }

        //change the animator parameter for animation blending depending on speed (0 = idle, 0.5 = walk, 1 = run)
        float animatorSpeedPercent = ((running) ? currentVelocity / runSpeed : currentVelocity / walkSpeed * 0.5f);
        animator.SetFloat("speedPercent", animatorSpeedPercent);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(gravity * jumpHeight * -2);
            _velocityY = jumpVelocity;
        }
    }

    private float getSmoothValue(float smoothTime)
    {
        if (_controller.isGrounded)
        {
            return smoothTime;
        }
        if (airControlPercent == 0)
        {
            return float.MaxValue;
        }
        return smoothTime / airControlPercent;
    }

    public void enterRagdoll()
    {
        animator.enabled = false;
        _controller.enabled = false;
        _isRagdolled = true;
    }

    public void resetPlayer()
    {
        _isRagdolled = false;
        animator.enabled = true;
        _controller.enabled = true;
        transform.position = startPosition;
        _currentSpeed = 0;
        _velocityY = 0;
    }
}
