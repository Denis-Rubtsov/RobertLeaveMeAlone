using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _animator;
    private Transform _player;

    void Start()
    {
        _player = FindObjectOfType<MotionScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_player.position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
}
