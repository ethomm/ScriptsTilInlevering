using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{

	public int dagbool;
	public int fasebool;
	public int soloppgang;
	public int solnedgang;
	public int frittFallbool;
	public int parachuteDeployedBool;
	public int rotatingBool;
	public int gaarBool;
	public int landetBool;
	//Liten viking
	public int litenVikingAngrepBool;
	public int litenVikingHealt;
	public int litenVikingSpeed;

	//Mellom Viking
	public int mellomVikingAngrepBool;
	public int mellomVikingSpeed;

	//Stor Viking
	public int storVikingAngrepBool;
	public int storVikingSpeed;



	void Awake(){

		//Stor Viking animasjoner
		storVikingAngrepBool = Animator.StringToHash ("StorVikingAngriper");
		storVikingSpeed = Animator.StringToHash ("StorVikingSpeed");

		//Mellom Viking animasjoner
		mellomVikingAngrepBool = Animator.StringToHash ("MellomVikingAngriper");
		mellomVikingSpeed = Animator.StringToHash ("MellomVikingSpeed");

		//Liten Viking animasjoner
		litenVikingAngrepBool = Animator.StringToHash ("LitenVikingAngrep");
		litenVikingHealt = Animator.StringToHash ("LitenVikingHealth");
		litenVikingSpeed = Animator.StringToHash ("LitenVikingSpeed");


		dagbool = Animator.StringToHash ("IsDay");
		fasebool = Animator.StringToHash ("Fasebytte");
		solnedgang = Animator.StringToHash ("solnedgang");
		soloppgang = Animator.StringToHash ("soloppgang");
		frittFallbool = Animator.StringToHash ("frittFall");
		parachuteDeployedBool = Animator.StringToHash ("prarachuteDeployed");
		rotatingBool = Animator.StringToHash ("roating");
		gaarBool = Animator.StringToHash ("gaar");
		landetBool = Animator.StringToHash ("landet");


	}
	
}
