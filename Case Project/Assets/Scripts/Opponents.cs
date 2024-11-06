using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponents : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Animator _animator;
    private NavMeshAgent _agent;
    private Rigidbody _rb;
    private Vector3 _agentStartPosition;

    Boy _boy;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _agentStartPosition = transform.position;
        _boy = GameObject.Find("BOY").GetComponent<Boy>();
    }

    void AnimPlay(string animName)
    {
        _animator.SetBool("run", false);
        _animator.SetBool("idle", false);
        _animator.SetBool(animName, true);
    }

    public void AgentStart()
    {
        _agent.enabled = true;
        _agent.SetDestination(target.transform.position);
        AnimPlay("run");
    }

    private void Update()
    {
        _boy.FallReturn();
        if (GameManager.Instance.isGameOver)
        {
            _agent.isStopped = true;
            AnimPlay("idle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _agentStartPosition;
        }

        if (collision.gameObject.CompareTag("RotatorStick"))
        {
            StartCoroutine(ObstacleHit());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _agent.speed = 0;
            AnimPlay("idle");
        }
    }

    IEnumerator ObstacleHit()
    {
        _agent.enabled = false;
        yield return new WaitForSeconds(0.5f);
        _agent.enabled = true;
        _agent.SetDestination(target.transform.position);
    }
}
