using UnityEngine;
using System.Collections;

public class LandsbyLys : MonoBehaviour {
	 /* Dette skriptet slokker og tenner lysene i landsbyen
	 * Er koblet på de pointlightene som tilhører landsbyen
	*/
	//Variabel for farge lyet skal ha
	public Color farge;
	//Variabel for makslysstyrke
	public float lysstyrke = 5f;
	//Om det er dag (lys av)
	private bool erDag;
	// om det er fasebytte (at lyset skal skru seg på)
	private bool faseBytte = false;
	//Henter kontrolleren til fasebytteBytteKontroller
	private GameObject kontroller;
	// variabel som holder på lys komponentet til spillobjektet
	private Light lys;
	void Start(){
		//Henter referansen til fasebyttekontroller
		kontroller = GameObject.Find ("FaseBytteKontroller");
		//Henter komponetet lys i spillobjektet og legger til i variabelen
		lys = GetComponent<Light> ();
		//Henter ut fargen i som er oppgitt
		lys.color = farge;
	}
		void Update () {
		//Kjører en sjekk for å se om det er endringer i boolene
		setFaseBool();
		//Dersom det er fasebytte og det er  dag skal de bli natt og lysene skal  på
		if (faseBytte&&erDag) {
			//Henter intensiteten per nå
			float intensitet = lys.intensity;
			//Hvis den er mindre en maks lysstyrke
				if(intensitet < lysstyrke){
				//øk intensiteten med time.deltatime.
				intensitet += Time.deltaTime;
				//Setter ny intensitet
				lys.intensity = intensitet;
			}
		}
		//Dersom det er fasebytte og det ikke er dag skal de bli dag og lysene slukkes.
		if (faseBytte&&!erDag){
			//Henter intensiteten per nå
			float intensitet = lys.intensity;
			//Senkter intensiteten med time.deltatime
			intensitet -= Time.deltaTime;
			//Setter ny intensistet
			lys.intensity = intensitet;
		}
	}

	void setFaseBool(){
		//Henter bool verdiene fra FasebytteGraphics
		erDag = kontroller.GetComponent<FasebytteGraphics> ().getErDag();
		faseBytte = kontroller.GetComponent<FasebytteGraphics> ().getBytterFase();

	}

}
