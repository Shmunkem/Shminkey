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
