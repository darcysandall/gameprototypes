using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float TurnAmount;
	public float tilt;
	public Rigidbody rb;
	public float speed;
	public float maxVelocity;
	public float brakeForce;

	public GameObject Shot;
	public Transform ShotSpawn;

	public float fireRate;
	private float nextFire;

	public bool ObjectThrowable = false;

	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		ObjectThrowable = false;
	}

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire && ObjectThrowable == true) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
			ObjectThrowable = false;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void FixedUpdate () 
	{
		float TurningHorizontal = Input.GetAxis ("Horizontal");

		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);

		GetComponent<Transform>().rotation = Quaternion.Euler (0.0f, TurningHorizontal * tilt, 0.0f);

		if (Input.GetAxis ("Vertical") > 0)
		{
			rb.AddRelativeForce (Vector3.forward * speed);
		}

		if (Input.GetAxis ("Vertical") < 0)
		{
			rb.AddRelativeForce (-Vector3.forward * brakeForce);
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Pickup") {
			ObjectThrowable = true;
			Destroy(other.gameObject);
		}
	}
}
