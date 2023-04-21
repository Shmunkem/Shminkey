using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRB;
	public float speed = 10f;
	public float forwardinput;
	public bool isSliding = false;
	public float slidespeed = 0;
	public bool isOnGround = true;
	public GameObject slidingPlayer;
	public GameObject standingPlayer;
	public GameObject BulletR;
	public GameObject BulletL;
	public Vector3 BulletPositionL = new Vector3(-.7f, 1, 0);
	public Vector3 BulletPositionR = new Vector3(.7f, 1, 0);
	private KeyCode LastHorizontalMove;


    // Start is called before the first frame update
    void Start()
    {
	    playerRB = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		forwardinput = Input.GetAxis("Horizontal");
		transform.Translate(new Vector3(1,0,0)*forwardinput*speed*Time.deltaTime*(1+slidespeed));
		if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
			playerRB.AddForce(Vector3.up*12*(1+slidespeed), ForceMode.Impulse);
			isOnGround = false;
			isSliding = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftControl) && isOnGround) {
			isSliding = true;
			slidingPlayer.gameObject.SetActive(true);
			standingPlayer.gameObject.SetActive(false);
			StartCoroutine (slideTimer());
		}
		if(isSliding == true) {
			playerRB.mass = 3;
			slidespeed = 1.5f;
		}
		if(isSliding == false) {
			playerRB.mass = 1.5f;
			slidespeed = 0;
		}
			if (Input.GetKeyDown(KeyCode.A))
			{
				LastHorizontalMove = KeyCode.A;
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				LastHorizontalMove = KeyCode.D;
			}
		if (LastHorizontalMove == KeyCode.A && Input.GetKeyDown(KeyCode.LeftShift))  //launches bullet behind of player
        {
			Instantiate(BulletL, transform.position + BulletPositionL, BulletL.transform.rotation); 
        }
		if (LastHorizontalMove == KeyCode.D && Input.GetKeyDown(KeyCode.LeftShift)) //launches bullet in front of player
        {
			Instantiate(BulletR, transform.position + BulletPositionR, BulletR.transform.rotation);
		}
	}
	private void OnCollisionEnter(Collision collision) {
		isOnGround = true;
	}
	IEnumerator slideTimer() {
		yield return new WaitForSeconds(0.3f);
		isSliding = false;
		slidingPlayer.gameObject.SetActive(false);
		standingPlayer.gameObject.SetActive(true);
	}
}
