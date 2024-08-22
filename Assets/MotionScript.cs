using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;

    private Vector3 _input;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _input = new Vector3(vertical, 0, -horizontal);
        if (_input.sqrMagnitude > 0.05f)
        {
            _input.y = 0;
            _input.Normalize();
            transform.forward = _input;
            _controller.Move(_input * _speed * Time.deltaTime);
            _animator.SetFloat("Speed", _controller.velocity.magnitude);
        }
        else _animator.SetFloat("Speed", 0);
    }
}
