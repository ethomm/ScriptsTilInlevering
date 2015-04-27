using UnityEngine;
using System.Collections;

public class TennSlokkFakkel : MonoBehaviour {
	
	private GameObject [] fakler;
	private FasebytteGraphics fasebytteGraphics;
	private bool erDag;
		
	void Awake(){
		fakler = GameObject.FindGameObjectsWithTag ("fakkel");
		fasebytteGraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
	}
	void Update(){
		erDag = fasebytteGraphics.getErDag ();
		if (erDag) {
			foreach (GameObject f in fakler) {
				f.SetActive (false);
			} 
		}
		else if (!erDag) {
			foreach (GameObject f in fakler) {
				f.SetActive(true);
			}
			
		}
			
	}

}
