using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponents : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public NavMeshAgent _agent;
    [SerializeField] public Vector3 startingPoint;
    private Rigidbody _rb;
    Vector3 _agentStartPosition;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(target.transform.position);
        _rb = GetComponent<Rigidbody>();
        _agentStartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //StartCoroutine(ObstacleHit());
            transform.position = _agentStartPosition;
        }
    }

}
