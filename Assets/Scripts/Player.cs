using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2 (3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;
	private PlayerController controller;
	private Animator animator;

	void Start () {
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelocityX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		var absVelocityY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);

		if (absVelocityY < 0.2f) {
			standing = true;
		} else {
			standing = false;
		}
			
		if (controller.moving.x != 0) {
			if (absVelocityX < maxVelocity.x) {
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
		}


		if (controller.moving.y > 0) {
			if (absVelocityY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}
			animator.SetInteger ("AnimState", 2);
		} else if (absVelocityY > 0) {
			animator.SetInteger ("AnimState", 3);
		}




		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (forceX, forceY));

	}
}
