using UnityEngine;
using System.Collections;

public class SolLys: MonoBehaviour {
	/// <summary>
	/// Endre Lyset slik at det skifter mellom dag og natt
	/// </summary>


	public float fart = 500f;
	public Transform dag;
	public Transform natt;
	public Transform fraNatt;
	
	private bool bytterFase = false;
	public bool erDag;
	private Light Sola;

	// Use this for initialization
	void Start () {
		Sola = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bytterFase&erDag) {
			transform.position = Vector3.MoveTowards (transform.position, natt.position, fart * Time.deltaTime);
			//Reduserer lysets intensitet
			float intensitet = Sola.intensity;
			intensitet -= Time.deltaTime/fart*150;
			Sola.intensity = intensitet;
			/*
			float LBintesitet = LandsbyLys.intensity;
			LBintesitet += Time.deltaTime/fart*150;
			LandsbyLys.intensity = LBintesitet;*/

		}
		if (bytterFase && !erDag) {
			transform.position = Vector3.MoveTowards (transform.position, dag.position, fart*Time.deltaTime);
			float intensitet = Sola.intensity;
			intensitet += Time.deltaTime/fart*330;
			Sola.intensity = intensitet;
		}
			
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "LysTrefferNatt") {
			erDag = false;
			bytterFase = false;
			Sola.transform.position = new Vector3(6812, 2477, -1);
			}
		if (other.tag == "LysTrefferDag") {
			erDag = true;
			bytterFase = false;
			Sola.intensity = 4.1f;
		}
	}

	public void ByttFase(){
		bytterFase = true;
	}

}
