using UnityEngine;
using System.Collections;

public class AudioQueuer : MonoBehaviour {
	public static void PlayAudioOnNextBar (AudioSource toPlay, float barLength, float defaultBarLength){
		AudioQueuer.instance.StartWaitForNextBar (toPlay, barLength, defaultBarLength);
	}

	private void StartWaitForNextBar (AudioSource toPlay, float barLength, float defaultBarLength) {
		StartCoroutine (WaitForNextBar (toPlay, barLength, defaultBarLength));
	}

	private IEnumerator WaitForNextBar (AudioSource toPlay, float barLength, float defaultBarLength) {
		if (barLength == 0) {
			barLength = defaultBarLength;
		}
		float timeTil2Secs = barLength-Time.time%barLength;
		yield return new WaitForSeconds (timeTil2Secs);
		toPlay.Play ();
	}

	static AudioQueuer _instance;
	public static AudioQueuer instance {
		get {
			if (_instance == null) {
				AudioQueuer prev = FindObjectOfType (typeof(AudioQueuer)) as AudioQueuer;
				if (prev) {
					_instance = (AudioQueuer)prev;
				} else {
					GameObject g = new GameObject ("_AudioQueuer");
					_instance = g.AddComponent<AudioQueuer> ();
					DontDestroyOnLoad (g);
					g.hideFlags = HideFlags.HideInHierarchy;
				}
			}
			return _instance;
		}
	}
}
