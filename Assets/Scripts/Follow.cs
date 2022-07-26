using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float LerpRate;
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * LerpRate);
    }
}
