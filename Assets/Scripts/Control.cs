using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	Rigidbody rb;
	public float speed = 0.25f;
	public float jumpSpeed = 100.0f;
	public float waitTime = 1.0f;
	public float flicker = 1.0f;
	private bool canMove = true;
	private bool canJump = true;
	Vector3 p0;

	// Use this for initialization
	void Start () {
		p0 = transform.position;
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		//rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * 5.0f);

		if ((Input.GetKeyDown ("space"))&&(canJump == true))
		{
			rb.AddForce(Vector3.up * jumpSpeed);
		}

		Color color = gameObject.GetComponent<Renderer> ().material.color;
		if (!canMove) {
			color.a = (Mathf.Abs(Mathf.Sin(Time.fixedTime * flicker)) * 0.5f) + 0.5f;
		} else {
			color.a = 1.0f;
		}
		gameObject.GetComponent<Renderer> ().material.color = color;
	}

	void FixedUpdate () {
		if(canMove)
			transform.localPosition += (Input.GetAxis("Horizontal") * speed * Vector3.right);
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
			canMove = false;
			StartCoroutine(delay());
		}
		if (col.gameObject.name == "Void") {
			transform.position = p0;
			canMove = false;
			StartCoroutine(delay());
		}
		if (col.gameObject.name == "Piso")
			canJump = true;
	}

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name == "Piso")
			canJump = false;
	}

	IEnumerator delay() {
		yield return new WaitForSeconds(waitTime);
		canMove = true;
	}
}