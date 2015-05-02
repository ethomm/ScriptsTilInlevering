using UnityEngine;
using System.Collections;

public class DetectionArea : MonoBehaviour {
	/* Denne classen oppdager om en fiende er kommet inn i området hvor
	* Forsvarselementer kan oppdage fienden
	*/

	//Lager en variabel som holder på fienden
	private Transform target;
	//Variabel som holder på referanse til sorvarlementAngrep skriptet
	private ForsvarselementAngrep forsvarangrepScript;
	// Use this for initialization

	//Finner skripet i hirarkiet
	void Awake (){
		//Legger til referansen i variabelen
		forsvarangrepScript = GetComponentInParent<ForsvarselementAngrep> ();
	}

	//Kommer fienden inn i detectionsonen settes targett til fiendenden som har kommet inn.
	//Fiender er alle som har taggen Enemy
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Fiende") {
			target = other.gameObject.transform;
			//Sender fienden/target til forsvarselementet
			forsvarangrepScript.Target(target);
		}
	}
	//Dersom fiendern forsvinner ut av detectionon sonen settes target til null
	void OnTriggerExit(Collider other){
		if (other.gameObject.transform == target) {
			target = null;
			forsvarangrepScript.Target(target);
		}
	}
	
}
