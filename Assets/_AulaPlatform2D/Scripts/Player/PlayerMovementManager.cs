using System;
using UnityEngine;
public class PlayerMovementManager : MonoBehaviour
{
    [Header("Configuração")]
    [SerializeField] private float _moveSped = 10f;
    [SerializeField] private float _moveAceleration = 6f;
    [SerializeField] private float _airAceleration = 2f;
    [SerializeField] private float _jumpForce = 8f;

    [Header("Gravidade")]
    [SerializeField] private float _normalGravity = 1;
    [SerializeField] private float _fallGravityMult = 2;
    [SerializeField] private float _jumpCutGravityMult = 3;
    [SerializeField] private float _maxFallSpeed = 20f;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask _groundLayer = 1 << 3;
    [SerializeField] Vector2 _groundCheckSize = new(1f, 0.1f);
    [SerializeField] Vector2 _groundCheckOffset = new(0, -0.5f);



    public float VelocityY { get { return _rigidbody.linearVelocityY; } }

    //Variaveis de memoria
    private float _moveDirection;
    private bool _jumpPressed;
    private bool _isGrounded;
    private bool _isJumping;
    private bool _cancelJump;



    private Rigidbody2D _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        CheckJump();
        ApplyMove();
        ApplyGravity();
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(transform.position + (Vector3)_groundCheckOffset, _groundCheckSize, 0, _groundLayer))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void CheckJump()
    {
        if (_isJumping && VelocityY < 0.1)
        {
            _isJumping = false;
        }

        if (_isGrounded && !_isJumping)
        {
            _cancelJump = false;
        }

        if (_jumpPressed && _isGrounded && !_isJumping)
        {
            ApplyJump();
        }
    }

    private void ApplyJump()
    {
        Debug.Log("Player Pulando");
        _cancelJump = false;
        _isJumping = true;
        float force = _jumpForce;
        if (VelocityY < 0)
        {
            force -= VelocityY;
        }
        _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void ApplyMove()
    {
        float targetVelocity = _moveDirection * _moveSped;
        float diffVelocity = targetVelocity - _rigidbody.linearVelocityX;
        float move = diffVelocity * (_isGrounded ? _moveAceleration : _airAceleration);
        _rigidbody.AddForceX(move, ForceMode2D.Force);
        //_rigidbody.linearVelocityX = _moveDirection * _moveSped;

    }

    private void ApplyGravity()
    {
        float gravityScale = _normalGravity;
        if (_cancelJump && VelocityY > 0.1)
        {
            gravityScale *= _jumpCutGravityMult;
        }
        if (VelocityY < 0)
        {
            gravityScale *= _fallGravityMult;
        }

        _rigidbody.gravityScale = gravityScale;
        _rigidbody.linearVelocityY = Mathf.Max(VelocityY, -_maxFallSpeed);
    }

    public void SetInputs(PlayerInputValues values)
    {
        _moveDirection = values.Move.x;
        _jumpPressed = values.Jump;
        if (!_jumpPressed)
        {
            _cancelJump = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)_groundCheckOffset, _groundCheckSize);

    }
}
