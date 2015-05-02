using UnityEngine;
using System.Collections;

public class RandomMovingSau : MonoBehaviour {
	/* Dette skriptet tar seg av bevegelsen til sauen på brettet.
	* for å sørge for at hver sau beveger seg forskjellig er det brukt en del Random.Range
	* Både for å endre retning og tid imellom hver retingnsendring
	*/

	private float makslimit = 2510f; //Setter to bariabler for mak verdier og minimumsverdier. Disse refererer til maks og min koordinater på spillbrettet
	private float minlimit = -2510f;
	public float RotationSpeed = 2f; //Setter frarten som sauen roterer med
	private float retning; //Variabel som holder reningen
	private bool rotating = false; //Boolverdi som sier om sauen er ferdig med å roterer
	private bool paabrettet = true; //Boolverdi som forteller om sauen er på brettet eller ikke
	private float movespeed = 20f; //Farten sauen beveger seg på brettet
	public bool landet = false; //Boolverdi for om sauen har landet
	public bool starteAaGaa = false; //Om sauen kan starte å gå eller ikke
	public float maksOppRotasjon = 20.0f; //MaksRotasjon sauen kan ha oppover. (Dette for å rette opp i glitcher)
	private float randomTid; // variabel som holder på sauen tilfedige tid for retningsendring
	public AudioClip bah; //Holder på klibbet BÆÆÆÆ klippet til sauen som spilles når den har rotert
	public AudioSource source; //lyskilden


	void Awake(){
		//Henter lydkildekomponetet som er lagt på sauen
		source  = GetComponent<AudioSource> ();

	}

	void Start()
	{
		randomTid = Random.Range (5f, 60f); //velger en tilfeldig tid mellom 5 sekunder og 60 sekunder. Dette for at ikka alle sauene skal stoppe og finne ny retning samtidig
		InvokeRepeating("VilkaarligRetning", 0, randomTid); //Kjører en funksjon som kjører funksjonen Vilkaar... hver X senkund. Sauen endrer derfor retning 
		//Denne er lagt inn for at sauen ikke bare skal finne en retning og gå til den krasjer eller faller over kanten.
		//VilkaarligRetning er også funksjon som kjøres først i dette skriptet.
	
	}
	
	void Update()
	{
		SjekkRotasjonsFeil(); //Starter med å sjekke om sauen er ferdig med å rotere.
		if (starteAaGaa) { //Hvis sauen kan starte å gå (ikke hopper i fallskjerm) sjekker vi om sauen er på brettet
			SauensPosisjon ();

				//Dersom sauen forstsatt er på brettet
			if (paabrettet) {
				 //Og den har fått en retning å gå
				if (rotating) {
					//Lager vi en ny vektor 3 med retningen som vi legger i variabel "til"
					Vector3 til = new Vector3 (0, retning, 0);
					//For å spare litt tid og en del glitcher
					//Sier vi at dersom vinkelen til den vilkårlige retningen er mindre en 0.1f kan den hoppe til riktig retning
					//Dette fordi Vilkaarlig retning returnerer et tall med mange desimaler, sjangsen for at sauen har truffet riktig retning
					// er derfor lik null og sauen vil spinne og spinne i det uendelige.

					//Dersom avstanden til riktig retning er større en 0.1f fortsetter rotasjonen
					if (Vector3.Distance (transform.eulerAngles, til) > 0.1f) {
						transform.eulerAngles = Vector3.Lerp (transform.rotation.eulerAngles, til, Time.deltaTime);
					} 
					 //Dersom avstanden forsatt er mindre en 0.1f hopper den til riktig retning (Siden dette er såpass liten vikel ser ikke spilleren dette)
					else {
						transform.eulerAngles = til;
						rotating = false; //Rotasjonen er nå ferdig (sauen roterer ikke lenger og kan derfor gå)

					}
		
				} else {
					//denne kodelinjen har kaskje flest spørringer. Den kjører kundersom sauen ikke hopper i fallskjerm, er ferdig med å rotere, befinner seg på brettet osv..
					//Uansett, nå kan sauen gå fremover med angitt fart
					transform.Translate (Vector3.forward * movespeed * Time.deltaTime);
				}
			}
		} 
	}
	//Funksjon som sjekker om sauen befinner seg på brettet
	void SauensPosisjon (){
		//Vi sjekker her mot objektets posisjon og om det er innenform maks og min nivåene på X og Z aksene
		if (((transform.position.x > minlimit) && (transform.position.x < makslimit)) && ((transform.position.z > minlimit) && (transform.position.z < makslimit))) {
				paabrettet = true; //Dersom den oppfyller kravene til å være på brettet settes den til true.
		} else {
			//Om sauen ikke er på brettet kan den heller ikke gå i løse lufta
			paabrettet = false;
			starteAaGaa = false;
		}
	}

	//denne sjekker om om sauen har landet. Logikken er: den kan ikke gå om den ikke er på bakken.
	void OnCollisionEnter(){
		starteAaGaa = true;
	}
	 //Funksjonen velger en tilfeldig retning
	void VilkaarligRetning(){
		retning = Random.Range(0f, 360f); //Velger tilfeldig tall mellom 0 og 360
		rotating = true; //Nå som valgt retning er gjort kan sauen rotere
		source.PlayOneShot(bah);//Spiller av lyden etter sauen har rotert
	}
	//Denne funksjonen fikser en glitch med at sauene ender på rompa og snurrer rundt
	void SjekkRotasjonsFeil(){
		Vector3 eulerAngles = transform.rotation.eulerAngles; //Lager en variabel som kan holde på vector 3 rotasjons vinkler
		//gjør en spørring på om x rotasjonen altså opp rotasjonen er større en det som er tillat.
		if(eulerAngles.x> maksOppRotasjon){
			//Dersom dette er tilfellet, lager vi en ny Quaternion som setter x til 0
			Quaternion rotation = Quaternion.Euler(new Vector3(0, retning, 0)); //den nye rotasjonen som setter x til 0 bevarer den til en hvert tidspunkt tilfeldig valgte retningnen.
			transform.rotation = rotation; //Vi manipulerer så spill objektet til å ha den nye rotasjonen
		}
	}


	//Dersom Suaen krasjer med et annet fysiskt objekt av betydning eller nærmer seg vannet eller fjellet. Dette gjelder da ikke blomster o.l som er naturlig å gå igjennom.
	//Endrer sauen retning for å ungå å kollidere (Eller gå igjennom, som ser skikkelig teit ut)
	void OnTriggerEnter(Collider other){
		VilkaarligRetning();
	}



}
