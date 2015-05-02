using UnityEngine;
using System.Collections;

public class MellomVikinAnimatorSetup{
 /* Denne classen setter opp funksjonen og contruktøren for å sende informasjon til
  * Animator Controlleren til den mellomste vikingen.
 */

	//Referanse til Komponenter
	private Animator anim;
	private HashIDs hash;
	//En dampTIme som gjør at bevegelsene blir mer naturlige 
	private float speedDampTime = 0.1f;

	//Lager kontruktæren som tar imot en animator og HashID referanse.
	public MellomVikinAnimatorSetup(Animator animator, HashIDs hashIds){
		anim = animator;
		hash = hashIds;
	}
	
	//En setup metode for å sende informasjonen til animatoren
	public void Setup(float speed, bool angrep){
		anim.SetFloat (hash.mellomVikingSpeed, speed, speedDampTime, Time.deltaTime);
		anim.SetBool (hash.mellomVikingAngrepBool, angrep);
	}
}
