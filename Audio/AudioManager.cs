using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip tilNatt;
	public AudioClip tilDag;

	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

	public void TilDagAudio(){
		source.PlayOneShot (tilDag);
	}

	public void TilNatAudio(){
		source.PlayOneShot (tilNatt);
	}

}
