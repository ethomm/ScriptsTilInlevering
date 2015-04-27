using UnityEngine;
using System.Collections;

public class StorVikingAnimatorSetup {

	public float litenVikingSpeed;

	private Animator anim;
	private HashIDs hash;
	private float speedDampTime = 0.1f;
	
	public StorVikingAnimatorSetup(Animator animator, HashIDs hashIds){
		anim = animator;
		hash = hashIds;
	}
	
	public void Setup(float speed, bool angrep){
		anim.SetFloat (hash.storVikingSpeed, speed, speedDampTime, Time.deltaTime);
		anim.SetBool (hash.storVikingAngrepBool, angrep);
	}
}
