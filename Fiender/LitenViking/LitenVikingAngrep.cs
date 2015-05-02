using UnityEngine;
using System.Collections;

public class LitenVikingAngrep : MonoBehaviour {

	private Transform target;
	public bool litenVikingAngriperBool = false; 
	
	// Update is called once per frame
	// Objektet snur seg mot den den ska angripe
	void Update () {
		if (target != null) {
			gameObject.transform.LookAt (target);
		}
	}

	//mottar infromasjon fra collideren
	public void Target(Transform t, bool angrep){
		target = t;
		litenVikingAngriperBool = angrep;

	}
}
