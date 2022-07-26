using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] GameObject EffectPrefab;
   void Satrt()
   {
		Destroy(gameObject, 2f);
   }

	private void OnCollisionEnter(Collision collision)
	{
		Instantiate(EffectPrefab, transform.position, Quaternion.identity );
	}
}
