using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private KeyCode _jumpKeyCode;
    [SerializeField] private LayerMask _groundLayerMask;
    private bool isGrounded;
    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            Move();
        if (Input.GetKeyDown(_jumpKeyCode))
            JumpUp();
    }
    private void Move()
    {
        _rb.velocity = new Vector2(_speed * Input.GetAxis("Horizontal"), _rb.velocity.y);
    }
    private void JumpUp()
    {
        if (isGrounded)
        {
            _rb.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_groundLayerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = true;
        }
    }
}
