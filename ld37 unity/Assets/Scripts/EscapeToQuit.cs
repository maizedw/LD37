using UnityEngine;
using System.Collections;
/*#if UNITY_EDITOR
using UnityEditor;
#endif*/

public class EscapeToQuit : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			/*#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
			#endif*/
			Application.Quit (); 

		}
	}
}
