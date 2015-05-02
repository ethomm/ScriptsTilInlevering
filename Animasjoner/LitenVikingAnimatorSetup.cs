using UnityEngine;
using System.Collections;

public class LitenVikingAnimatorSetup  {
 /* Denne classen setter opp funksjonen og contruktøren for å sende informasjon til
  * Animator Controlleren til den lille vikingen.
 */

	//Referanser til komponenter
	private Animator anim;
	private HashIDs hash;
	//En dampTIme som gjør at bevegelsene blir mer naturlige og ikke overdrevet
	private float speedDampTime = 0.1f;

	//Lager kontruktæren som tar imot en animator og HashID referanse.
	public LitenVikingAnimatorSetup(Animator animator, HashIDs hashIds){
		anim = animator;
		hash = hashIds;
	}

	//En setup metode for å sende informasjonen til animatoren
	public void Setup(float speed, float health, bool angrep){
		anim.SetFloat (hash.litenVikingSpeed, speed, speedDampTime, Time.deltaTime);
		anim.SetFloat (hash.litenVikingHealt, health);
		anim.SetBool (hash.litenVikingAngrepBool, angrep);
	}

}
