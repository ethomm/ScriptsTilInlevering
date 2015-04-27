using UnityEngine;
using System.Collections;

public class StorVikingMovement : MonoBehaviour {

	private NavMeshAgent nav;
	private Animator anim;
	private HashIDs hash;
	private FiendeAngrep angrep;
	private bool angriper = false;
	private StorVikingAnimatorSetup animSetup;
	private float originalSpeed;
	

	void Awake(){
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		hash = GameObject.Find ("gameController").GetComponent<HashIDs> ();
		angrep = GetComponent<FiendeAngrep> ();
		animSetup = new StorVikingAnimatorSetup (anim, hash);
	}
	
	void Update(){
		angriper = angrep.angriper;
		NavAnimSetup ();
	}
	

	void NavAnimSetup(){
		float speed;

		speed = nav.speed;
		
		animSetup.Setup (speed, angriper);
		
	}
}
