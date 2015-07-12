using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float amplitude = 5.0f;
	public float speed;
	Vector3 direction = Vector3.down;
	Vector3 p0;

	// Use this for initialization
	void Start () {
		p0 = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = transform.TransformDirection(direction);
		transform.position = p0 + amplitude * dir * Mathf.Sin(6.28f * speed * Time.time);
		//yield return new WaitForFixedUpdate();
	}
}
