using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float width = 2f;

    private GameObject movingObject;
    
    private void Start()
    {
        if (movingObject == null)
        {
            movingObject = this.gameObject;
        }
    }


    private void Update()
    {
        movingObject.transform.position = new Vector3(
            Mathf.Sin(Time.time * speed) * width,
            movingObject.transform.position.y,
            movingObject.transform.position.z);
    }
}
