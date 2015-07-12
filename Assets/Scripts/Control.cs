using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	Rigidbody rb;
	public float speed = 0.2f;
	public float jumpspeed = 100.0f;
	private bool canJump = true;
	Vector3 p0;
	Quaternion r0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		p0 = transform.position;
		//r0 = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * 5.0f);
		transform.localPosition += (Input.GetAxis("Horizontal") * speed * Vector3.right);

		if ((Input.GetKeyDown ("space"))&&(canJump == true))
		{
			//transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
			rb.AddForce(Vector3.up * jumpspeed);
			//canJump = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Piso")
			canJump = true;

		if (col.gameObject.name == "Cube") {
			Vector3 p1 = transform.position;
			p1.x -= 4.0f;
			p1.y += 1.0f;
			transform.position = p1;
			//transform.rotation = r0;
		}
		if (col.gameObject.name == "Void") {
			transform.position = p0;
			//transform.rotation = r0;
		}
		if (col.gameObject.name == "Piso")
			canJump = true;
	}

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name == "Piso")
			canJump = false;
	}
}