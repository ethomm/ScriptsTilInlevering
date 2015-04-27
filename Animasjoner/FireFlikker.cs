using UnityEngine;
using System.Collections;

public class FireFlikker : MonoBehaviour {
	private Light lys;
	private bool isDay;
	private bool fasebytte;
	private float lysstyrke;
	private FasebytteGraphics fasebytteGraphics;


	void Awake(){
		lys = gameObject.GetComponent<Light> ();
		fasebytteGraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics> ();
		lysstyrke = lys.intensity;
		isDay = fasebytteGraphics.getErDag ();
		if (!isDay) {
			lys.intensity = 0f;
		}

	}

	void Start(){

	}
	void Update() {
		isDay = fasebytteGraphics.getErDag ();
		fasebytte = fasebytteGraphics.getBytterFase ();

		if (isDay && fasebytte) {
			if(lys.intensity < lysstyrke){
				lys.intensity += 0.04f;
			}
		} else if (!isDay && fasebytte) {
			if(lys.intensity> 0){
				lys.intensity -= 0.04f;
			}
		}



	}
}