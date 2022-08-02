using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _playerTransform;
   

    void Update()
    {
       Ray ray =  _camera.ScreenPointToRay(Input.mousePosition);
       Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);
       Plane plane = new Plane (Vector3.up, _playerTransform.position);

        float distance;

        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;

        Vector3 toAim = _aim.position - _playerTransform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }

}
