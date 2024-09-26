using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody2D;
    [SerializeField] private float _playerSpeed;
    private Animator _playerAnimator;
    private Vector2 _playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        TransitionAnimations();
        Flip();
    }

    void FixedUpdate()
    {
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }

    void TransitionAnimations()
    {
        if (_playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetInteger("Movement", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movement", 0);
        }

         if (_playerDirection.y < 0)
         {
            _playerAnimator.SetInteger("LookDirection", 0);
         }
         else if (_playerDirection.y > 0)
         {
            _playerAnimator.SetInteger("LookDirection", 1);
         }

         if (_playerDirection.x > 0)
         {
            _playerAnimator.SetInteger("LookDirection", 2);
         }
         else if (_playerDirection.x < 0)
         {
            _playerAnimator.SetInteger("LookDirection", 2);
         }
    }
    void Flip()
    {
        if (_playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (_playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
}
