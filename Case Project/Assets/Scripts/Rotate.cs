using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject rotateObject;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool rotateInverted;

    private void Start()
    {
        if (rotationSpeed == 0f)
        {
            rotationSpeed = Random.Range(5f, 30f);
        }
        if (rotateInverted)
        {
            rotationSpeed = -rotationSpeed;
        }

        if (rotateObject == null)
        {
            rotateObject = gameObject;
        }
    }


    private void Update()
    {
        rotateObject.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
