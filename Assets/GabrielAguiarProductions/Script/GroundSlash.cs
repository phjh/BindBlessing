using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlash : MonoBehaviour
{
	public float speed = 30;
	public float slowDownRate = 0.01f;
	public float detectingDistance = 0.1f;
	public float destroyDelay = 5;

	private Rigidbody rb;

	void Start()
	{
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		if (GetComponent<Rigidbody>() != null)
		{
			rb = GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * speed, ForceMode.Impulse);
			//StartCoroutine(SlowDown());
		}
		else
			Debug.Log("No Rigidbody");

		Destroy(gameObject, destroyDelay);
	}

	private void FixedUpdate()
	{
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	}
}
