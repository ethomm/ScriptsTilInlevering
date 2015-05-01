using UnityEngine;
using System.Collections;

public class BaalFlamme : MonoBehaviour {
	/* Dette skriptet skal skifte fagen på lystyrken på vardene som markerer hvor fiendene kommer fra
	* Skriptet settes på pointlight elementet som skal lyse opp varden
	*/
	//Setter en  min og maks lysstyrke
	public float minLysstyrke = 0f;
	public float maxLysstyrke = 1f;

	//Siden lysest vil flikke lager vi en variabel for tid imellom hvert flikk
	public float duration = 4.0F;
	//henter variabel for referanse til lys komponentet
	public Light lt;
	void Start() {
		//Henter referansen til lyskomponentet som skriptet er koblet til
		lt = GetComponent<Light>();
	}
	void Update() {
		//For hver oppdatering beregnes det lys endring av lysets intensitet
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos(phi) * 3.5F + 3.5F;
		//og ny lysstyrke settes lik amplitude
		lt.intensity = amplitude;
	}
	
}
