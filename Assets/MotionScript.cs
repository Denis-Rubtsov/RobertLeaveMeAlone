using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;

    private Vector3 _input;

    internal void Move(Vector3 motion)
    {
        if (motion.sqrMagnitude > 0.05f)
        {
            motion.y = 0;
            motion.Normalize();
            transform.forward = motion;
            _controller.Move(motion * _speed * Time.deltaTime);
            _animator.SetFloat("Speed", _controller.velocity.magnitude);
        }
        else _animator.SetFloat("Speed", 0);
    }

    void Update()
    {
    }
}