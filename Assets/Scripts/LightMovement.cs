using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    [SerializeField] private Transform diamondTransform;
    [SerializeField] private Transform lightTransform;
    [SerializeField] private float speed;
    private void Start()
    {
        transform.position = diamondTransform.position;
        lightTransform.position = new Vector3 (0, 0, 8);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, diamondTransform.position, speed * Time.deltaTime);
        transform.Rotate(Vector3.up * .3f);
    }
}
