using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[ExecuteAlways]
public class LightRotate : MonoBehaviour
{
    [SerializeField] private Transform diamondTransform;
   
    private void LateUpdate()
    {
        Vector3 direction = diamondTransform.position - transform.position;
        Debug.DrawRay(transform.position, direction);
        transform.rotation = Quaternion.LookRotation(direction);
    }

}
