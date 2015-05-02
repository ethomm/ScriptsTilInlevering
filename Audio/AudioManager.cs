using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	/* Denne Classen skal håndtere alt av lyd som ikke er knyttet til et spesielt objekt,
	* og dermed ikke må ha en egen source i spillverdenen
	*/

	//Offentlige variabler som holder på Lydklipp
	public AudioClip tilNatt;
	public AudioClip tilDag;

	//Kilden for lyden
	private AudioSource source;

	void Awake(){
		//Henter kildekomponente som er lagt på objetet
		source = GetComponent<AudioSource> ();
	}

	// Metode for å spille av lyden om at der blitt dag
	public void TilDagAudio(){
		source.PlayOneShot (tilDag);
	}
	//Metode for å spille av lyden om at der blitt natt
	public void TilNatAudio(){
		source.PlayOneShot (tilNatt);
	}

}
