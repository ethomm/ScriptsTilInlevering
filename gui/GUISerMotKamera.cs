using UnityEngine;
using System.Collections;

public class GUISerMotKamera : MonoBehaviour {
	/*Klasse som gjør at alle elementer som har dette skriptet knyttet til seg peker mot kamera til en hver tid
	 * Koden er hentet fra http://wiki.unity3d.com/index.php/LookAtCameraYonly
	 */

	//legger til hvilket kamera som elementet skal se mot
	private Camera cameraToLookAt;

	void Awake(){
		cameraToLookAt = Camera.main;
	}
	void Update() 
		
	{	
		Vector3 v = cameraToLookAt.transform.position - transform.position;
		
		v.x = v.z = 0.0f;
		
		transform.LookAt( cameraToLookAt.transform.position - v ); 
		
		transform.Rotate(0,180,0);	
	}
}
