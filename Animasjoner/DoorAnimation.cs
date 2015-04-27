using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
	private Animator anim;
	private HashIDs hash;
	private FasebytteGraphics fasebytteGraphics;
	private bool erDag;
	private bool fasebytte = false;


	void Awake(){
		anim = GetComponent<Animator> ();
		hash = GameObject.Find("gameController").GetComponent<HashIDs> ();
		fasebytteGraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
	}
	void Start(){	
	}

	void FixedUpdate(){
	 	erDag = fasebytteGraphics.getErDag ();
		fasebytte = fasebytteGraphics.getBytterFase ();

		anim.SetBool (hash.dagbool, erDag);
		anim.SetBool(hash.fasebool, fasebytte);


	}

}
