using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float TurnAmount;
	public float tilt;
	private Rigidbody rb;
	public float speed;
	public float maxVelocity;
	public float brakeForce;

	public GameObject Shot;
	public Transform ShotSpawn;

	public float fireRate;
	private float nextFire;

	public bool ObjectThrowable = false;
	public Image SpeedImage;
	public float currentVelocity;
	public Text SpeedText;
	public float raceTime;
	public float savedRaceTime;
	public Text RaceTimeText;
	public bool RaceFinished;

	public float JumpSpeed;
	public bool isGrounded;

	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		ObjectThrowable = false;
		RaceFinished = false;
		isGrounded = true;
	}

	void Update ()
	{

		currentVelocity = GetComponent<Rigidbody> ().velocity.z;
		SpeedImage.fillAmount = currentVelocity / 150;
		SpeedText.text = Mathf.Round (currentVelocity) + " km/h";
		if (Input.GetButton("Fire1") && Time.time > nextFire && ObjectThrowable == true) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
			ObjectThrowable = false;
		}

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (RaceFinished == true)
		{
			raceTime = savedRaceTime;
			RaceTimeText.text = "" + Mathf.Round(savedRaceTime);
		}

		if (RaceFinished == false)
		{
			raceTime = Time.timeSinceLevelLoad;
			RaceTimeText.text = "" + Mathf.Round(raceTime);
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

		if (Input.GetButtonDown ("Jump") && isGrounded == true)
		{
			rb.velocity = new Vector3(0.0f, JumpSpeed, rb.velocity.z);
			isGrounded = false;
		}

	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Pickup") {
			ObjectThrowable = true;
			Destroy(other.gameObject);
		}

		if (other.tag == "RaceTrigger")
		{
			saveRaceTime ();
			RaceTimeText.text = "" + savedRaceTime;
			Debug.Log ("Saved race time");
		}
	}

	void saveRaceTime ()
	{
		savedRaceTime = raceTime;
		RaceFinished = true;
	}
}
