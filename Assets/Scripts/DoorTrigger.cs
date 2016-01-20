using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public Door door;
	public bool ignoreTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D target) {

		if (ignoreTrigger) {
			return;
		}


		if (target.gameObject.tag == "Player") {
			door.Open ();
		}
	}

	void OnTriggerExit2D (Collider2D target) {

		if (ignoreTrigger) {
			return;
		}

		if (target.gameObject.tag == "Player") {
			door.Close ();
		}
	}

	public void Toggle(bool value){
		if (value) {
			door.Open ();

		} else {
			door.Close ();
		}
	}

	public void OnDrawGizmos () {
		Gizmos.color = ignoreTrigger ? Color.gray : Color.green;

		var bc2D = GetComponent<BoxCollider2D> ();
		var bc2DPos = bc2D.transform.position;
		var newPos = new Vector2 (bc2DPos.x + bc2D.offset.x, bc2DPos.y + bc2D.offset.y);
		Gizmos.DrawWireCube (newPos, new Vector2(bc2D.size.x, bc2D.size.y));
	}
}
