using UnityEngine;
using System.Collections;

public class DepthOfField : MonoBehaviour {
	/* Dette skriptet skaper en effekt av depth of field i kameraet.
	*  I dette skriptet har jeg brukt  tourtorialen til https://www.youtube.com/watch?v=d1GnMVKkinQ
	*/
	public Transform opprinnelig;//Hvor kameraet starter å fokusere
	public GameObject target;//Følger etter Rayen kameraet sender ut

	void Update () {
		Ray ray = new Ray(opprinnelig.transform.position, opprinnelig.transform.forward);//Starter på opprinnelses stedet
		RaycastHit hit = new RaycastHit ();// 

		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) { //Skyter rayencasten, med infinity menes at den kan gå så langt den bare vil.
			target.transform.position = hit.point;//Flytter det tomme gameobjektet til stedet kameraet peker og gjør dette til det nye punktet
		}
		//Nå gjenstår det bare å koble på effekten fra Standard Assets...
	}
}
