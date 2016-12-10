using UnityEngine;
using System.Collections;

public class clicking : MonoBehaviour {
	AudioTimer aT;
	// Use this for initialization
	void Start () {
		aT = GameObject.FindObjectOfType<AudioTimer> ();
	}
	GameObject lastObject;
	// Update is called once per frame
	void Update() {
		for (int i = 0; i < Input.touchCount; i++) {
			Touch t =Input.GetTouch (i);
			if (t.phase == TouchPhase.Began) {
				Click (t.position);
			}
		}



		if (Input.GetMouseButtonDown (0)) {
			//Clicked
			Click(Input.mousePosition);
		} else {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (lastObject != hit.collider.gameObject) {
					AudioSource audio = hit.collider.gameObject.GetComponent<AudioSource> ();
					if (audio != null) {
						audio.PlayOneShot (audio.clip);
					}
					lastObject = hit.collider.gameObject;
				}
			}
		}
	}

	void Click(Vector3 screenPos) {
		Ray ray = Camera.main.ScreenPointToRay (screenPos);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			Debug.DrawLine (ray.origin, hit.point, Color.green, 5);
//			Renderer r = hit.collider.gameObject.GetComponent<Renderer> ();

			//float randomNum = Random.value;
			float randomNum1 = Random.Range (0.5f, 1);
			float randomNum2 = Random.Range (0, 0.5f);
			// if colour is on, turn it off
			AudioManager aM = hit.collider.gameObject.GetComponent<AudioManager>();
			if (aM != null) { 
				if (aM.colour != Color.white) {
					aM.colour = Color.white;
				} else if (hit.collider.gameObject.CompareTag ("cube")) { //cubes are greeny blue
					aM.colour = new Color (0, Random.Range (0.5f, 1), Random.Range (0, 0.5f));
				} else if (hit.collider.gameObject.CompareTag ("sphere")) { //spheres are really light blue to pink
					aM.colour = new Color (0.7f, Random.Range (0.7f, 1), 1);
				} else if (hit.collider.gameObject.CompareTag ("longsphere")) {//longspheres are light red
					aM.colour = new Color (1, randomNum1, randomNum1);
				} else if (hit.collider.gameObject.CompareTag ("ovalcapsule")) {//ovalcapsules are light green
					aM.colour = new Color (randomNum1, 1, randomNum1);
				} else if (hit.collider.gameObject.CompareTag ("rectangle")) {//rectangles dark red
					aM.colour = new Color (1, randomNum2, randomNum2);
				} else if (hit.collider.gameObject.CompareTag ("capsule")) {//capsules are reddy blue
					aM.colour = new Color (randomNum1, 0, randomNum2);
				} else { //everything else is dark purple
					aM.colour = new Color (Random.Range (0, 0.5f), 0, Random.Range (0, 0.5f));
				}
			}
			AudioSource audio = hit.collider.gameObject.GetComponent<AudioSource> ();
			if (audio != null) {
				audio.loop = !audio.loop;
				if (audio.loop) {
					AudioQueuer.PlayAudioOnNextBar (audio, aT.GetOffset (audio), 2);
				}
			}
		}
	}
}

