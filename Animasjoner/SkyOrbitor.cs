using UnityEngine;
using System.Collections;

public class SkyOrbitor : MonoBehaviour {

	/// <summary>
	/// Denne funksjonen roterer et objekt på Y aksen til gitt fart
	/// Det gjør at objekter knyttet til dette objektet som child roterer i en omkrets tilsvarende (avstand til parent center * 2Pi)
	/// Altså jo lengere unna objektet fra senter jo større fart får det.
	/// Denne classen er brukt på skyene
	/// </summary>

	//minste farten på rotasjonen
	public float minFart = 0.2f;
	//Maks fart på rotasjonen
	public float maksFart = 600f;
	//Utgjevnings fart
	public float smoothTime = 0.3f;
	//Startpunkt for natt
	private float startNatt = 0.001f;
	//Startpunkt for dag
	private float StartDag = 0.999f;
	//Farten som det økes med
	private float yVelocity = 0.0f;
	//Halvveis i faseskiftet
	private float midten = 55f;
	public float rotSpeed; //Setter fart på rotering
	//Verdien hentet fra skyboxen som sier hvor langt i faseskiftet man er kommet og om det er satt igang
	private float faseSkifte;


	void Start (){
		rotSpeed = minFart;
	}

	void Update ()
	{
		//Sjekker om faseskiftet har startet dersom > eller < enn Start natt eller Start dag
		faseSkifte = RenderSettings.skybox.GetFloat ("_Blend");
			//Hvis den ligger faseskiftet er < 1 og > 0
			//Reduseres og økes farten etter hvor lang man har kommet.
			if (faseSkifte > startNatt && faseSkifte < StartDag) {
				if (faseSkifte < midten) {
					rotSpeed = Mathf.SmoothDamp (minFart, maksFart, ref yVelocity, smoothTime);
					transform.Rotate (0, rotSpeed * Time.deltaTime, 0);//Roter på Yaksen 
				} else if (faseSkifte > midten) {
					rotSpeed = Mathf.SmoothDamp (maksFart, minFart, ref yVelocity, smoothTime);
					transform.Rotate (0, rotSpeed * Time.deltaTime, 0);//Roter på Yaksen 

				}

			}
	}
}
