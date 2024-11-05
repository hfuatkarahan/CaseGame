using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float speed;

    void AnimPlay(string animName)
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Idle", false);
        _animator.SetBool(animName, true);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * speed, _rigidbody.velocity.y, _joystick.Vertical * speed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            AnimPlay("Run");
        }
        else
        {
            AnimPlay("Idle");
        }

    }
}
