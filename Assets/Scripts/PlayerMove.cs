using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove: MonoBehaviour
{
		public Rigidbody Rigidbody;
		public float Speed;
		public float JumpSpeed;
		public float MaxSpeed;
		public float Friction;
		public Transform ColliderTransform;


		public bool Grounded;


		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (Grounded)
				{
					Rigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
				}
			}

			if (Input.GetKey(KeyCode.LeftControl) || Grounded == false)
			{
				ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
			}
			else
			{
				ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
			}


		}

		public void FixedUpdate()
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			Vector3 inputVector = new Vector3(horizontal, 0f, vertical);
			Vector3 speedPlayer = inputVector * Speed;
			Vector3 speedRelativeVectorToPlayer = transform.TransformVector(speedPlayer);

			Rigidbody.velocity = new Vector3(speedRelativeVectorToPlayer.x, Rigidbody.velocity.y, speedRelativeVectorToPlayer.z);

			float speedMultiplier = 1f;
			if (Grounded == false)
			{
				speedMultiplier = 0.4f;

				if (Rigidbody.velocity.x > MaxSpeed && horizontal > 0 && vertical > 0)
				{
					speedMultiplier = 0.2f;
				}
				if (Rigidbody.velocity.x < -MaxSpeed && horizontal < 0 && vertical < 0)
				{
					speedMultiplier = 0.2f;
				}
			}
			Rigidbody.velocity = new Vector3(speedRelativeVectorToPlayer.x * Speed * speedMultiplier, Rigidbody.velocity.y,
			speedRelativeVectorToPlayer.z * Speed * speedMultiplier);

			if (Grounded)
			{
				Rigidbody.velocity -= new Vector3(speedRelativeVectorToPlayer.x * Friction, 0f,
				speedRelativeVectorToPlayer.z * Friction);
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			for (int i = 0; i < collision.contactCount; i++)
			{
				float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
				if (angle < 45f)
				{
					Grounded = true;
				}
			}
		}
		private void OnCollisionExit(Collision collision)
		{
			Grounded = false;
		}
	
}
