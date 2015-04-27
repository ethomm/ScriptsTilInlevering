using UnityEngine;
using System.Collections;

public class SkyOrbitor : MonoBehaviour {

	/// <summary>
	/// Denne funksjonen roterer et objekt på Y aksen til gitt fart
	/// Det gjør at objekter knyttet til dette objektet som child roterer i en omkrets tilsvarende (avstand til parent center * 2Pi)
	/// Altså jo lengere unna objektet fra senter jo større fart får det.
	/// </summary>

	public float minFart = 0.2f;
	public float rotSpeed; //Setter fart på rotering
	public float maksFart = 600f;
	public float smoothTime = 0.3f;
	private float startNatt = 0.001f;
	private float StartDag = 0.999f;
	private float yVelocity = 0.0f;
	private float midten = 55f;

	private float faseSkifte;


	void Start (){
		rotSpeed = minFart;
	}

	void Update ()
	{
		faseSkifte = RenderSettings.skybox.GetFloat ("_Blend");
	
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
