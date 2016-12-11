using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	public float mouseSpeed = 1;
	private float velocity = 0;
	public float decelleration = 1;

	public float maxVelocity = 10;

//	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
			velocity += Input.GetAxis ("Mouse X");

		transform.Rotate (Vector3.up * velocity, Space.World);

		velocity = Mathf.MoveTowards (velocity, 0, Time.deltaTime * decelleration * 10);
		velocity = Mathf.Sign(velocity)	* Mathf.Min(Mathf.Abs(velocity), maxVelocity);
	}
}
