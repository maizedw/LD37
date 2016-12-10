using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
	public AudioSource aS;
	public Renderer r;
	public float scale = 1;
	public Color colour = Color.white;
	private float emission;
	private Color lastColor = Color.white;
	// Use this for initialization
	void Start () {
		aS = GetComponent<AudioSource> ();
		r = GetComponent<Renderer> ();
		a_data = new float[16];
	}

	float[] a_data;

	// Update is called once per frame
	void Update () {
		aS.GetOutputData (a_data, 0);
		float vol = 0;
		for (int i = 0; i < a_data.Length; i++) {
			vol += a_data [i];
		}
		vol /= a_data.Length;
		vol *= scale;
//		r.material.SetColor ("_EmissionColor", new Color(vol,vol,vol));
//		r.material.EnableKeyword ("_EMISSION");

		if (colour != lastColor || emission != vol) {
			r.material.color = new Color(colour.r+vol,colour.g+vol,colour.b+vol,1);
			emission = vol;
			lastColor = colour;
		}
	}
}
