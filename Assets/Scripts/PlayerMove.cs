using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody Rigidbody;
    [SerializeField] float MoveSpeed;
    [SerializeField] float MaxSpeed;
    [SerializeField] float JumpSpeed;

    [SerializeField] Transform ColliderTransform;
    [SerializeField] bool Ground;

    void Update()
    {
        if(Ground){
            if(Input.GetKeyDown(KeyCode.Space)){
                Rigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
            }
		}

        if(Input.GetKey(KeyCode.LeftControl) || Ground == false){
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
		}
        else{
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
		}
    }

	public void FixedUpdate()
	{
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(horizontal, 0f, vertical);
        Vector3 speedPlayer = inputVector * MoveSpeed;
        Vector3 speedVectorRelativeToPlayer = transform.TransformVector(speedPlayer);
  
        Rigidbody.velocity = new Vector3(speedVectorRelativeToPlayer.x, Rigidbody.velocity.y, speedVectorRelativeToPlayer.z);
	}

	private void OnCollisionStay(Collision collision)
	{
		for(int i = 0; i < collision.contactCount; i++){
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if(angle < 45){
                Ground = true;
			}
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		Ground = false; 
	}
}
