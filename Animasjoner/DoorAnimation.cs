using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
	/* Dette skriptet åpner og lukker dørene til landsbyen basert på
	* om spilleren befinner seg i kampfase eller i forberedelsesfase
	* Dette skripet er koblet til hvert av dør elementene
	*/

	//lager en variabel for å holde referansen til animator komponenten
	private Animator anim;
	// Variabel som holder på referanse til hashIden
	private HashIDs hash;
	//Variabel som holder på referansen til FasebytteGraphichs skriptet
	private FasebytteGraphics fasebytteGraphics;
	//Bool variabel som forteller om det er dag eller ikke
	private bool erDag;
	//Bool variabel som forteller om det er satt igang et fasebytte.
	private bool fasebytte = false;

	//Fyller referanse variablene med inn hold ved oppstart
	void Awake(){
		//HEnter komponetntet anmator i objektet skriptet er koblet til
		anim = GetComponent<Animator> ();
		//Finner spillobjektet gameCotroller og dens komponent HashIDs hvor HashID skriptet befinner seg
		hash = GameObject.Find("gameController").GetComponent<HashIDs> ();
		//Finner spillobjektet gameController for skripetet FasebytteGraphics er koblet til
		fasebytteGraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
	}

	void FixedUpdate(){
		//Finner ut om FaseBytteGrapichs sin erDag er sann eller falsk
	 	erDag = fasebytteGraphics.getErDag ();
	 	//Finner ut om FasebytteGraphics sin bytterfase er sann eller falsk.
		fasebytte = fasebytteGraphics.getBytterFase ();
		//Sender innhentet infromasjon videre til animatorControlleren via HasIDene.
		anim.SetBool (hash.dagbool, erDag);
		anim.SetBool(hash.fasebool, fasebytte);
		/*Informasjonen om hvordan denne infromasjonen skal behandles og tolkes
		* Ligger i Animator Controlleren som er knyttet til hasIDen "dagbool" og "fasebool"
		* Animatorkontrolleren vil deretter kjøre animasjoner basert på forutsetninger definert her.
		*/

	}

}
