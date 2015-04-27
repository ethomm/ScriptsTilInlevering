using UnityEngine;

public class Orbit : MonoBehaviour
{
	/// <summary>
	/// Denne funksjonen roterer et objekt på Y aksen til gitt fart
	/// Det gjør at objekter knyttet til dette objektet som child roterer i en omkrets tilsvarende (avstand til parent center * 2Pi)
	/// Altså jo lengere unna objektet fra senter jo større fart får det.
	/// </summary>

	public float rotSpeed = 0.2f; //Setter fart på rotering

	void Update ()
	{
		transform.Rotate(0, rotSpeed * Time.deltaTime, 0);//Roter på Yaksen 
	}


	public void SetRotSpeed(float speed){
		rotSpeed = rotSpeed* speed;
	}
}