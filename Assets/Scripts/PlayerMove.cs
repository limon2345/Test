using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private Transform _colliderTransform;
    public bool Ground;

    void Update()
    {
        if(Ground){
            if(Input.GetKeyDown(KeyCode.Space)){
                _rigidbody.AddForce(0f, _jumpSpeed, 0f, ForceMode.VelocityChange);
            }
		}

        if(Input.GetKey(KeyCode.LeftControl) || Ground == false){
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
		}
        else{
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
		}
    }

	public void FixedUpdate()
	{
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(horizontal, 0f, vertical);
        Vector3 speedPlayer = inputVector * _moveSpeed;
        Vector3 speedVectorRelativeToPlayer = transform.TransformVector(speedPlayer);
  
        _rigidbody.velocity = new Vector3(speedVectorRelativeToPlayer.x, _rigidbody.velocity.y, speedVectorRelativeToPlayer.z);
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
