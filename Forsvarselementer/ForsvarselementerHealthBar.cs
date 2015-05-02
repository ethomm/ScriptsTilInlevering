using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ForsvarselementerHealthBar : MonoBehaviour {
	/* Dette skriptet håndterer informasjon om helsetilstanden til et forsvarselement
	 * og overfører denne informasjonen til en grafisk fremvisning
	 * Alle public variabler i dette skriptet må legges inn manuelt i prefabene
	 * Elementene skal være child av prefaben, men legges til manuelt i editoren for å redusere antall linjer kode
	 */

	//Henter inn elementene som er knyttet til spillobjektet
	public Slider heltbar;
	public Image healthimage;
	public Sprite godHelse; //Henter fra Gui Texture
	public Sprite daarligHelse; //Henter fra GUI Texture
	public GameObject healthbar;

	//Variabler som holder på informasjon om helsetilstanden
	//variabel som holder på helsa til forsvarlementet
	private float health;
	//Variabel som holder på forsvarelement skriptet
	private Forsvarselement forsvarselement;
	//Holder på starthelsen til objektet
	private float starthealth;
	
	void Awake(){
		//Fyller variablene med referanse
		forsvarselement = gameObject.GetComponentInParent<Forsvarselement> ();
		starthealth = forsvarselement.helse;
	}
	
	void Update (){
		//For hver oppdatering hentes helsen til objektet
		health = forsvarselement.helse;
		//Gjør helsen om til prosent
		float healtbarvalue = (health / starthealth)*100;

		//Hvis helsen er over eller lik 100 vises ikke healthbaren
		if (healtbarvalue >= 100) {
			healthbar.SetActive (false);
		} else {
			//Hvis den er under 100 vises den
			healthbar.SetActive(true);
		}

		//Setter slideren lik healthbarvalue
		heltbar.value = healtbarvalue;

		//Dersom verien er lavere enn 40 vises rød farge på healtbaren
		if (healtbarvalue < 40) {
			healthimage.sprite = daarligHelse;
		} else {
			//Så lenge den holder seg over er den grønn
			healthimage.sprite = godHelse;
		}
	}

}
