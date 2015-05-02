using UnityEngine;
using System.Collections;

public class StorVikingMovement : MonoBehaviour {
	/* Denn klassen håndter bevegelsene til objektet stor viking
	 */

	//Referanse variabler
	private NavMeshAgent nav;
	private Animator anim;
	private HashIDs hash;
	private FiendeAngrep angrep;
	private bool angriper = false;
	private StorVikingAnimatorSetup animSetup;
	private float originalSpeed;
	

	void Awake(){
		//Fyller variablene med referanser
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		hash = GameObject.Find ("gameController").GetComponent<HashIDs> ();
		angrep = GetComponent<FiendeAngrep> ();
		//Kjører konstruktøren
		animSetup = new StorVikingAnimatorSetup (anim, hash);
	}
	
	void Update(){
		angriper = angrep.angriper;
		NavAnimSetup ();
	}
	
	//Sender infromasjon til animatoren
	void NavAnimSetup(){
		float speed;
		speed = nav.speed;
		animSetup.Setup (speed, angriper);
	}
}
