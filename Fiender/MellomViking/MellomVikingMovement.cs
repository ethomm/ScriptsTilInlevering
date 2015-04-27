using UnityEngine;
using System.Collections;

public class MellomVikingMovement : MonoBehaviour {

	private NavMeshAgent nav;
	private Animator anim;
	private HashIDs hash;
	private FiendeAngrep angrep;
	private bool angriper = false;
	private MellomVikinAnimatorSetup animSetup;
	private float originalSpeed;
	

	void Awake(){
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		hash = GameObject.Find ("gameController").GetComponent<HashIDs> ();
		angrep = GetComponent<FiendeAngrep> ();
		animSetup = new MellomVikinAnimatorSetup (anim, hash);
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
