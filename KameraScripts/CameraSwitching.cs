using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour {
	/* Denne Classen brukes som åpningen under hovedmenyen
	* Etter at timeren har gått til null byttes kamera og dermed skaper en effekt av
	* flerkameraproduksjon
	*/
	//Legger til de forskjellige kameraene som spillobjekter
	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera3;
	public GameObject camera4;
	public GameObject camera5;
	public GameObject camera6;
	//Lager en variabel som holder på tiden vært kamera skal vises
	private float timer = 0;

	//Variabler som holder referanser til skripts
	private MenuGui guimenu;
	private GameManager gameManager;


	void Awake (){
		//Fyller skripvariablene med tilhørende skripts
		gameManager = gameObject.GetComponentInParent<GameManager> ();
		guimenu = gameObject.GetComponentInParent<MenuGui> ();

	}

	void Update(){
		//Finner ut om spillet er startet eller ikke
		bool erigang = gameManager.gameHasStarted;
		//Finner ikke ut om spillet er satt på pause.
		bool pause = guimenu.pause;

		//Logikk for om kamera skal byttes eller ikke
		if (!pause && !erigang) {
			if (timer > 0) {
				timer -=Time.deltaTime;
			} else {
				velgKamera ();
				timer = 20;
			}
		//Dersom spillet er i gang, deaktiveres kameraene som holdes av dette skriptet
		} else {
			Deactivate();
		}
	}
	//Metode for valg av kamera
	void velgKamera(){
		//Velger et tilfeldig tall mellom 1 og 6
		int camera = Mathf.FloorToInt(Random.Range(1,6));
		//Detaktiverer alle og aktiver kameraet som skal brukes
		//Dektiverer fordi dersom kameraet som var aktivt ligger under i det nye aktiverte kameraet
		//i hirarkiet vil ikke endringen av kamera synes
		switch (camera) {
		case 1: Deactivate();
			camera1.SetActive(true);
			break;
		case 2: Deactivate();
			camera2.SetActive(true);
			break;
		case 3: Deactivate();
			camera3.SetActive(true);
			break;
		case 4: Deactivate();
			camera4.SetActive(true);
			break;
		case 5: Deactivate();
			camera5.SetActive(true);
			break;
		case 6: Deactivate();
			camera6.SetActive(true);
			break;
		default: Deactivate();
			break;
		}
	}
	//Deaktiver alle kameraer
	public void Deactivate(){
		camera1.SetActive (false);
		camera2.SetActive (false);
		camera3.SetActive (false);
		camera4.SetActive (false);
		camera5.SetActive (false);
		camera6.SetActive (false);	
	}

	

}
