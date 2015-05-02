using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LandsbyHealtBar : MonoBehaviour {
	/* Det skriptet håndterer landsbyens healtbar og er ganske lig forsvarselementers healtbar og fiendenes healtbar
	 * til forskjell har denne klassen en ekstra logikk som legger til røykog flammer i landsbyen basert på landsbyens helse
	*/
	public Slider heltbar;
	private float health;
	private Landsby landsby;
	private float starthealth;
	public Image healthimage;
	public Sprite godHelse;
	public Sprite daarligHelse;
	public GameObject healthbar;
	//Spillobjekter som legger på røyk og flammer
	public GameObject littDod;
	public GameObject veldignaredod;
	
	void Awake(){
		landsby= gameObject.GetComponentInParent<Landsby> ();
	}
	
	void Update (){
		//Setter healtbar value for landsbyehelsen i ragne 1 til 100.
		float healtbarvalue = (landsby.helse/ landsby.reparerTilHelse)*100;
		heltbar.value = healtbarvalue;
		//om landsbyen har tapt liv vises healthbaren
		if (healtbarvalue >= 100) {
			healthbar.SetActive (false);
		} else {
			healthbar.SetActive(true);
		}

		//setter verdien på healthbaren
		heltbar.value = healtbarvalue;
		//Dersom verdien er under 40 blir den rød
		if (healtbarvalue < 40) {
			healthimage.sprite = daarligHelse;
		} else {
			healthimage.sprite = godHelse;
		}

		//Logikk for å legge til flammer og røyk
		if (healtbarvalue > 60) {
			littDod.SetActive(false);
			veldignaredod.SetActive(false);
		}
		else if (healtbarvalue < 60) {
			littDod.SetActive (true);
			if (healtbarvalue < 30) {
				veldignaredod.SetActive(true);
			}
		} 
	}
}
