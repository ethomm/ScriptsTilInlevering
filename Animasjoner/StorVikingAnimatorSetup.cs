using UnityEngine;
using System.Collections;

public class StorVikingAnimatorSetup {
 /* Denne classen setter opp funksjonen og contruktøren for å sende informasjon til
  * Animator Controlleren til den mellomste vikingen.
 */

	private Animator anim;
	private HashIDs hash;
	private float speedDampTime = 0.1f;
	
	//Lager kontruktæren som tar imot en animator og HashID referanse.
	public StorVikingAnimatorSetup(Animator animator, HashIDs hashIds){
		anim = animator;
		hash = hashIds;
	}
	//En setup metode for å sende informasjonen til animatoren
	public void Setup(float speed, bool angrep){
		anim.SetFloat (hash.storVikingSpeed, speed, speedDampTime, Time.deltaTime);
		anim.SetBool (hash.storVikingAngrepBool, angrep);
	}
}
