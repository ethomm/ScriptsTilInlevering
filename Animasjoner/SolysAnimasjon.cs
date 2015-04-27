using UnityEngine;
using System.Collections;

public class SolysAnimasjon : MonoBehaviour {
	private Animator anim;
	private HashIDs hash;
	private bool soloppgang;
	private bool solnegang;
	private FasebytteGraphics fase;
	private bool erDag;
	private bool faseBytte;


	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
		hash = GameObject.Find ("gameController").GetComponent<HashIDs> ();
		fase = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
	}

	void Update(){
		erDag = fase.getErDag ();
		faseBytte = fase.getBytterFase ();
	}

	void FixedUpdate(){
		if (erDag && faseBytte) {
			anim.SetBool (hash.solnedgang, true);
		} else if (!erDag && faseBytte) {
			anim.SetBool (hash.soloppgang, true);
		} else {
		
			anim.SetBool (hash.solnedgang, false);
			anim.SetBool (hash.soloppgang, false);
		}



	}
	
}
