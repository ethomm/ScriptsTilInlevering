using UnityEngine;
using System.Collections;

public class MellomVikinAnimatorSetup{

	public float mellomVikingSpeed;
	
	private Animator anim;
	private HashIDs hash;
	private float speedDampTime = 0.1f;
	
	public MellomVikinAnimatorSetup(Animator animator, HashIDs hashIds){
		anim = animator;
		hash = hashIds;
	}
	
	public void Setup(float speed, bool angrep){
		anim.SetFloat (hash.mellomVikingSpeed, speed, speedDampTime, Time.deltaTime);
	
		anim.SetBool (hash.mellomVikingAngrepBool, angrep);
	}
}
