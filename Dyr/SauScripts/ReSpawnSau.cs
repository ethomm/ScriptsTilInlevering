using UnityEngine;
using System.Collections;

public class ReSpawnSau : MonoBehaviour {
	/* Denne Classen flytter sauen fra der den har falt av brettet til et 
	* tilfeldig sted over kartet igjen
	*/

	public float maksFallAvstand = -1000f;//Setter avstanden for hvor langt en sau kan falle
	private float Akse1; //Lager en variabel som holder på en en tilfeldig gitt variabel
	private float Akse2; //Lagen en variabel hver for X og Z aksen.

	void Update () {
		//Dersom Sauen har falt lengere en maks avstanden kjøres Respawn() funksjonen
		if ((transform.position.y < maksFallAvstand)||(transform.position.z < maksFallAvstand)) {
			ReSpawn();
		}
	}
	void ReSpawn(){
		Akse1 = Random.Range (- 1000, 1018); //Finner et tilfeldig tall, Tallene denne kan velge imellom sørger for at sauen spawner på brettet.
		Akse2 = Random.Range (-1000, 1018);
		Vector3 newPos = new Vector3 (Akse1, 3000, Akse2); //Lager en ny vektor posisjon for Sauen
		transform.position = Vector3.MoveTowards (transform.position, newPos, 10000000* Time.deltaTime); //Flytter Sauen til ny posisjon med lysets hastighet
	}

}

