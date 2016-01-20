using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public DoorTrigger[] doorTriggers;
	private Animator animator;
	public bool sticky;
	private bool down;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		animator.SetInteger ("AnimState", 1);
		down = true;
		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null) {
				trigger.Toggle (true);
			}

		}
	}

	void OnTriggerExit2D(Collider2D target){
		animator.SetInteger ("AnimState", 2);
		if (sticky && down)
			return;

		down = false;
		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null) {
				trigger.Toggle (false);
			}

		}
	}

	void OnDrawGizmos () {
		Gizmos.color = sticky ? Color.red : Color.green;
		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null) {
				Gizmos.DrawLine (transform.position, trigger.door.transform.position);
			}

		}
	}
}
