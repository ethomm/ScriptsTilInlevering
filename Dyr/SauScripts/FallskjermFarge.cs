using UnityEngine;
using System.Collections;

public class FallskjermFarge : MonoBehaviour {
	/* Dette skriptet tar seg av valg av fallskjerm til de forskjellige sauene
	* de forskjellige texturene legges inn i editoren til spillet
	* Hver sau får tildelt en fallskjerm ved starten av hvert spill
	*/

	public Texture[] textures; //Oppretter en liste som det kan legges til texturer i, via inspector
	public Renderer rend; //Lagrer en Render variabel som holder på teksturene
	private int i; //Lager en variabel som skal holde på den tilfeldige indexen
	private int arraylenght; //En variabel som skal holde på lengen av listen med texturer

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> (); //Henter Componentet Renderer i Objektet som har dette skriptet tilknyttet
		arraylenght = textures.Length; //Finner antall texturer som er i listen
		i = Random.Range (0, arraylenght); // Velger et tilfeldig til fra 0 til listen lengde
		i = Mathf.FloorToInt (i); //Siden det tilfeldige tallet er en float med desimaler, parser jeg dette om til en int som runder opp til nærmeste integer(heletall)
		rend.material.mainTexture = textures[i]; //Endrer texturen til fallskjermen til den tilfeldige texturen
	}
}
