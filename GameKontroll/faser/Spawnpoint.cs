using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour {
	/* Denne klassen holder på selve spawnpointet og de forskjellige funksjonen spawnpointet har
	 */

	//Har tre objekter, flamme , varsellys og spawnpoint
	public GameObject flamme;
	public GameObject varselLys;
	public GameObject spawnpoint;

	//Alle spawninger legges til et eget spillobjekt som holder på alle fiendene
	private GameObject fiendeHolder;

	void Awake(){
		fiendeHolder = GameObject.Find ("FiendeHolder");
	}
	//Slukker flamme
	public void stengAv(){
		flamme.SetActive(false);
		varselLys.SetActive(false);
	}
	//Tenner flamme
	public void tennLys(){
		flamme.SetActive(true);
		varselLys.SetActive(true);
	}
	//Spawner fienden som er mottatt fra spawnmanager
	public void SpawnFiende(GameObject fiende){
		//Lager et game objekt som skal instansieres
		GameObject fiendeInstance;
		
		// instantiater (spawner) fiende på plasseringen til spawnpoint fra listen med tilfeldige spawnpoints
		fiendeInstance = Instantiate(fiende, spawnpoint.transform.position, Quaternion.identity) as GameObject;
		
		// legger de i et annet gameobject (for orden i hierarkiet)
		fiendeInstance.transform.parent = fiendeHolder.transform;
	}
}
