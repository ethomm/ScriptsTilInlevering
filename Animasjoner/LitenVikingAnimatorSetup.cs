using UnityEngine;
using System.Collections;

public class LitenVikingAnimatorSetup  {

	public float litenVikingSpeed;
	public float litenVikingHealth;

	private Animator anim;
	private HashIDs hash;
	private float speedDampTime = 0.1f;

	public LitenVikingAnimatorSetup(Animator animator, HashIDs hashIds){
		anim = animator;
		hash = hashIds;
	}

	public void Setup(float speed, float health, bool angrep){
		anim.SetFloat (hash.litenVikingSpeed, speed, speedDampTime, Time.deltaTime);
		anim.SetFloat (hash.litenVikingHealt, health);
		anim.SetBool (hash.litenVikingAngrepBool, angrep);
	}

}
