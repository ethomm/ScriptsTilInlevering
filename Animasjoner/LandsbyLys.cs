using UnityEngine;
using System.Collections;

public class LandsbyLys : MonoBehaviour {

	public Color farge;
	public float lysstyrke = 5f;
	public bool  erFlamme;
	private bool erDag;
	private bool faseBytte = false;
	private GameObject kontroller;
	private Light lys;
	void Start(){
		kontroller = GameObject.Find ("FaseBytteKontroller");
		lys = GetComponent<Light> ();
		lys.color = farge;
	}
		void Update () {
		setFaseBool();
		if (faseBytte&&erDag) {
			float intensitet = lys.intensity;
				if(intensitet < lysstyrke){
				intensitet += Time.deltaTime;
				lys.intensity = intensitet;
			}
		}
		if (faseBytte&&!erDag){
			float intensitet = lys.intensity;
			intensitet -= Time.deltaTime;
			lys.intensity = intensitet;
		}
	}

	void setFaseBool(){
		erDag = kontroller.GetComponent<FasebytteGraphics> ().getErDag();
		faseBytte = kontroller.GetComponent<FasebytteGraphics> ().getBytterFase();

	}

}
