using UnityEngine;
using System.Collections;
using System;


public class StillKlokka : MonoBehaviour {

	DateTime tidnaa; //Definerer data typen for å hente ut tidskoden i systemet
	//Lager to variabler som vil returnere en int
	private int TimeNaa; //En for Time
	private int MinuttNaa; //En for minutt
	private int TimeTallet; //Lagrer en variabel som gjør omregningen til grader i rotasjonen
	private int MinutTallet; //Det samme for minutter
	public GameObject Kortviser1; //Oppreter variabler som skal holde på Spillobjekter
	public GameObject Kortviser2; //Disse spillobjektene er viserene på de tre sidene av Kriken
	public GameObject Kortviser3; //en variabel for kortviser og en for langviser
	public GameObject Langviser1; 
	public GameObject Langviser2; 
	public GameObject Langviser3; 


	void Start(){
		InvokeRepeating ("Klokka", 0, 30); // Vi har ingen sekundviser, så vi trenger ikke å kalle opp tiden hvert sekund, men har satt den til hvert 30 for å være mest mulig nøyaktig.

	}
	
	void Klokka(){
		tidnaa = System.DateTime.Now; //Kaller inn DateTime.Now fra systembiblioteket
		TimeNaa = tidnaa.Hour; //fra denne kan jeg nå hente ut Timer
		MinuttNaa = tidnaa.Minute; // Og minutter
		StillKirkeKlokka ();
	}

	void StillKirkeKlokka(){

		TimeTallet = (-TimeNaa * -30)-90; // Regner ut fradene klokken * 12/360 og 60/360
		MinutTallet = (-MinuttNaa * -6)-90; //Korrigerer for gradfeil i klokkene


		// Siden De Tree klokkene er plassert på tre forskjellige sider av kirketårnet lager jeg seks forskjellige Quaternions
		// Disse retter opp klokkene slik at de viser riktig tid og går riktig vei
		Quaternion timen1 = Quaternion.Euler(new Vector3(0, 180, TimeTallet));
		Quaternion minuttet1 = Quaternion.Euler(new Vector3(0, 180, MinutTallet));

		Quaternion timen2 = Quaternion.Euler(new Vector3(0, 270 , TimeTallet));
		Quaternion minuttet2 = Quaternion.Euler(new Vector3(0, 270 ,MinutTallet));

		Quaternion timen3 = Quaternion.Euler(new Vector3(0,0, TimeTallet));
		Quaternion minuttet3 = Quaternion.Euler(new Vector3(0, 0, MinutTallet));


		//Endrer rotasjoenen på viserne for å representere klokka
		Kortviser1.transform.rotation = timen1;
		Langviser1.transform.rotation = minuttet1;

		Kortviser2.transform.rotation = timen2;
		Langviser2.transform.rotation = minuttet2;

		Kortviser3.transform.rotation = timen3;
		Langviser3.transform.rotation = minuttet3;

	}

}
