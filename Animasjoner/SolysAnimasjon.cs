using UnityEngine;
using System.Collections;

public class SolysAnimasjon : MonoBehaviour {
	/* Denn Classen kontrollerer animasjonen av slyset under faseskiftene
	*	Sollyset er en Animasjon som er tatt opp og dette skriptet viser dermet til 
	* 	En animator controller og sender variabler til parametere i denne controlleren
	*/

	// Lager variabler for å sette verdier og hente komponenter
	private Animator anim;
	private HashIDs hash;
	private bool soloppgang;
	private bool solnegang;
	private FasebytteGraphics fase;
	private bool erDag;
	private bool faseBytte;


	void Awake(){
		//Henter komponentene
		anim = gameObject.GetComponent<Animator> ();
		hash = GameObject.Find ("gameController").GetComponent<HashIDs> ();
		fase = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
	}

	void Update(){
		//Ser om det er dag
		erDag = fase.getErDag ();
		//Ser om fasebytte er satt igang
		faseBytte = fase.getBytterFase ();
	}

	void FixedUpdate(){
		//Dersom det er dag og fasebytte er satt igang skal det bli natt
		if (erDag && faseBytte) {
			anim.SetBool (hash.solnedgang, true);
			//Dersom det er natt og fasebytte, skal det bli dag
		} else if (!erDag && faseBytte) {
			anim.SetBool (hash.soloppgang, true);
		} else {
			//dersom ingen av delene er det ikke noen animasjon.
			anim.SetBool (hash.solnedgang, false);
			anim.SetBool (hash.soloppgang, false);
		}

	}
}
