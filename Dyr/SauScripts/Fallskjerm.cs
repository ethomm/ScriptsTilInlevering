using UnityEngine;
using System.Collections;

public class Fallskjerm : MonoBehaviour {
	/* Dette skripet tar for seg falskjerm funksjonen til sauen
	* og er basert på Unity tourtorialen om raycasting med noe modifikasjoner
	*/

	public GameObject fallskjerm; //Modellen av fallskjermen legges inn i Inspector
	public float fallskjermEffekt; //Hvor stor effekt fallskjermen skal ha (drag)
	public float utloserHoyde; //Hvilken høyde falskjermen skal utløses i
	public float underBrettet;	//finne ut om sauen er under brettet
	private bool deployed = true; //Setter deployed til true, fordi alle sauene starter på bakken, Dette hindrer da at Raycasten kjører konstant før det er nødvendig.
	private Rigidbody rb; //Lager en variabel for å hente ut og manipulerere komponenten rigidbody
 

	void Start(){

		rb = GetComponent<Rigidbody> (); //får tak i komponentet - Dette trenger vi bare å gjøre en gang, og er derfor plassert i Start()
	}

	void Update(){
		RaycastHit hit; //Lager en variabel som skal holde på informasjon fra raycasten
		//Lager en FailSafe (dykkeryuttrykk) Dersom vi har en sau som starter oppe i skyene kan den utløsefallskjerm på vei ned
		if (transform.position.y > 900) {
			deployed = false;

		}

		//Lager en ny Raycast
		Ray landingRay = new Ray (transform.position, Vector3.down);
		//Dersom fallskjermen ikke er utløst ber vi den skyte en ray ned og måle avstanden til bakken(Til en colider med taggen "Landskapsobjekter" Dette inkluderer alt, steiner vann, trær, bakke osv..
		if (!deployed) {

			//Dersom Raycasten vår "landingRay sin verdi (avstand til bakken) i hit tilsvarer utløserhøyden...
			if (Physics.Raycast (landingRay, out hit, utloserHoyde)) {
				//...Og denne høyden er målt utifra et landskapsobjekt...
				if (hit.collider.tag == "LandskapsObjekter") {
					//.. UtløsFallskjerm
					UtlosFallskjerm ();
				}
			}
		}

		//Gjør en spørring på om Sauen har falt over kanten og "fallskjermen må pakkes"..
		if (transform.position.y <= underBrettet) { 
			deployed = false;
		}

	}

	//Funskjon som utløser fallskjermen
	void UtlosFallskjerm(){
		deployed = true;//Setter deployed til True

		rb.drag = 1f; //Reduserer farten på fallet
		fallskjerm.SetActive(true); //Gjør fallskjermen synlig for spilleren
	}
	
	//Funksjon for å oppdage når man lander. Det gjøres ved at når Collider Meshen til sauen treffer en annen mesh(bakken ect) kjøres denne funksjonen
	void OnCollisionEnter(){
		rb.drag = 0.0001f; //setter Rigidbody dragen tilbake til 
		fallskjerm.SetActive(false); //Lukker fallskjermen (gjør den ikke lenger synlig for spilleren)


	}
}
