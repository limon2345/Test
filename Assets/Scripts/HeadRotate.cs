using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotate : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        float xAimDistance = _target.position.x - transform.position.x;
        float Interpolant = Mathf.InverseLerp(15f, -15f, xAimDistance);
        float angle = Mathf.Lerp(-90f, 90f, Interpolant);

        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }
}
