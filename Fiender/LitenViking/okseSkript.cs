using UnityEngine;
using System.Collections;

public class okseSkript : MonoBehaviour {
	/* Dette skriptet er koblet på den lillevikingens øks
	 * den reigstrer treff og spiller av en lyd når den treffer et forsvarselement
	 */

	//Variabler som holder på referanser
	private int skade; //Skade som øksa kan ta
	private float tidmellomAngrep = 0; //tid mellom angrep hentes fra parent
	private Fiende fiende; //referanse til skript
	public AudioClip oks;//Lyd som skal spilles
	private AudioSource source; //Lydkilden som er på spillobjektet
	


	void Awake(){
		//Setter referansene
		fiende = GetComponentInParent<Fiende> ();
		skade = fiende.skade;
		tidmellomAngrep = fiende.tidMellomAngrip;
		source = GetComponent<AudioSource> ();
	}

	// kjører når øksa kolliderer med gameobject
	void OnTriggerEnter(Collider other)
	{

		if (tidmellomAngrep > 0) {
			tidmellomAngrep -= Time.time;
		} else {
		
			// hvis Øksa kolliderer med Landsby eller Forsvarselement
			if (other.gameObject.tag == "Forsvarselement") {		
				// kjører metode til gameobject for skade tatt
				other.GetComponentInParent<ForsvarselementHelse> ().taSkade (skade);
				source.PlayOneShot(oks);
				tidmellomAngrep = fiende.tidMellomAngrip;
			}else if (other.gameObject.tag == "Landsby") {		
				// kjører metode til gameobject for skade tatt
				other.GetComponentInParent<LandsbyHelse> ().taSkade (skade);
				source.PlayOneShot(oks);
				tidmellomAngrep = fiende.tidMellomAngrip;
				Debug.Log("Prover å ta liv");
			}
		}
	}
}
