using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Controlls controlls;
    [SerializeField] Controlls.OnFootActions onFoot;

    [SerializeField] Rigidbody rb;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] ForceMode jumpMode;

    [SerializeField] bool grounded;

    [SerializeField] float moveX;
    [SerializeField] float moveZ;

    [SerializeField] float gravity;
    [SerializeField] float maxSpeedGravity;
    [SerializeField] ForceMode forcemode;

    bool jump;

    Vector3 tamañoAgachado;
    Vector3 tamañoParado;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent(out Rigidbody rb);
        this.rb = rb;

        controlls = new Controlls();
        onFoot = controlls.OnFoot;
        onFoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = onFoot.MoveX.ReadValue<float>();
        moveZ = onFoot.MoveZ.ReadValue<float>();
        if (onFoot.Jump.triggered) jump = true;
    }

    private void FixedUpdate()
    {
        Move();

        if (jump && grounded) Jump();

        if (!grounded && rb.velocity.y > -maxSpeedGravity)
        {
            rb.AddForce(transform.up * (-gravity + (rb.velocity.y * 20f)), forcemode);
        }

        jump = false;
    }

    private void Move()
    {
        if (moveX != 0 || moveZ != 0)
        {
            Vector3 directionX = transform.right * moveSpeed * moveX;
            Vector3 directionZ = transform.forward * moveSpeed * moveZ;
            rb.AddForce(directionX, ForceMode.VelocityChange);
            rb.AddForce(directionZ, ForceMode.VelocityChange);
        }
    }
    private void Jump()
    {
        Vector3 directionY = transform.up * jumpForce;
        rb.AddForce(directionY, jumpMode);
    }

    public void SetGrounded(bool ground) => grounded = ground;
}
