using UnityEngine;
using System.Collections;

public class TennSlokkFakkel : MonoBehaviour {
	/* Denne Classen tenner og slukker faklene basert på om det er dag eller natt
	*/
	
	//Samler alle faklene i en array
	private GameObject [] fakler;
	//Variabel for å holde på fasebyttegraphics skriptet
	private FasebytteGraphics fasebytteGraphics;
	//Bool verdi om det er dag eller ikke
	private bool erDag;
		
	void Awake(){
		//Hanter faklene til arrauen basert på taggen "fakkel"
		fakler = GameObject.FindGameObjectsWithTag ("fakkel");
		//Henter referansen til fasebytteGraphics
		fasebytteGraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
	}
	void Update(){
		// Dersom det er dag
		erDag = fasebytteGraphics.getErDag ();
		if (erDag) {
			//Settes alle objektene i arrayen fakkel
			foreach (GameObject f in fakler) {
				//Til aktive
				f.SetActive (false);
			} 
		}
		//Dersom det er natt
		else if (!erDag) {
			//Settes alle objektene i arrayen fakkel
			foreach (GameObject f in fakler) {
				//Til inaktive
				f.SetActive(true);
			}	
		}		
	}
}
