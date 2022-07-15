using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera MainCamera;
    public Transform PlayerTransform;

	
    void Update()
    {
        
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);

        Plane plane = new Plane(Vector3.up, PlayerTransform.position);

        float distance;

        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        Aim.position = point;
        
        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
