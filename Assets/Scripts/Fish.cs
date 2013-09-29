using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {
	
	public Vector3 destination;
	public float moveSpeed;
	public float attentionSpan;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("SetNewDestination", 0f, attentionSpan);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
		//transform.LookAt(destination);
	}
	
	void FixedUpdate() {
		Vector3 direction = Vector3.Normalize(destination - transform.position);
		rigidbody.AddForce(moveSpeed * direction, ForceMode.VelocityChange);
	}
	
	void SetNewDestination() {
		destination = Random.insideUnitSphere * 30f;
	}
}
