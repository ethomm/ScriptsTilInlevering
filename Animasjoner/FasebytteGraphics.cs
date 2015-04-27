using UnityEngine;
using System.Collections;

public class FasebytteGraphics : MonoBehaviour {
	/// <summary>
	/// Dette skriptet skal skifte Lysetting på brettet fra dag til natt
	/// I Tilleg skal den skifte Skybox
	/// </summary>
	/// 
	/// 
	public float overgangsTid = 0.1f; //Tiden det tar for overgangen å bli ferdig
	private float verdien; //Variabel som holder veriden til blend
	private bool erDag; //Bool verdi som forteller om det er dag eller natt
	private bool bytterFase = false; // forteller om det er en transition mellom dag og natt på gang.

	void Start(){

		//Henter verdien til skyboxen for å avgjøre om det er dag eller natt når spillet starter
		verdien = RenderSettings.skybox.GetFloat ("_Blend");
		// 0 er lik dag og 1 er lik natt
		if (verdien <= 0) {
			erDag = true;
		} else {
			erDag = false;
		}
	}

	void Update(){
		//Sjekker om fasen er satt i gang
		if (bytterFase) {
			//Sjekker om det er dag. Dersom det er tilfelle, byttes det til natt
			if(erDag){
				verdien += overgangsTid*Time.deltaTime; //adderer opp tallet i verdien basert på overgangsTiden og time.deltatime, dette for å få en fin smooth overgang
				KampFase();

				//Og visa versa
			}else{
				verdien -= overgangsTid*Time.deltaTime; //Her gjør den det samme bare subtraherer
				Forberedelsesfase();

			}

		}
	}
	public void byttFase(){
		//Når  tiden har gått ut starter funksjonen, dette er en midlertidig trigger
			bytterFase = true; //Om bytte er fase er satt i gang kan resten av skriptet kjøres
			//Starter metoden i Skriptet Sollys, som setter igang bytte av fase for sola.

	}

	//Metoden som bytter grafikken til KampFase
	void KampFase(){
		RenderSettings.skybox.SetFloat ("_Blend",verdien);//Finner blend parameteret i skyboxen og endrer denne etter tallet i verdien
		if (verdien >= 1) {

			erDag = false;
			bytterFase = false;
		}			
	}
	//Metoden som bytter grafikken til Kampfase
	void Forberedelsesfase(){
		RenderSettings.skybox.SetFloat ("_Blend", verdien);//Finner blend parameteret i skyboxen og endrer denne etter tallet i verdien
		if(verdien <= 0){

			erDag = true;
			bytterFase = false;
		}
	}



//Getter and setters	
	public bool getBytterFase(){
		return bytterFase;
	}
	public bool getErDag(){
		return erDag;
	}


}
