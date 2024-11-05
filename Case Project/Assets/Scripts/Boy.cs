using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    Vector3 _startPosition;

    private void Start()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _startPosition;
        }
    }


}
