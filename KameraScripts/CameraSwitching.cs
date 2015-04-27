using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour {
	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera3;
	public GameObject camera4;
	public GameObject camera5;
	public GameObject camera6;
	private float timer = 0;

	private MenuGui guimenu;
	private GameManager gameManager;


	void Awake (){
		gameManager = gameObject.GetComponentInParent<GameManager> ();
		guimenu = gameObject.GetComponentInParent<MenuGui> ();

	}

	void Update(){
		bool erigang = gameManager.gameHasStarted;
		bool pause = guimenu.pause;

		if (!pause && !erigang) {
			if (timer > 0) {
				timer -=Time.deltaTime;
			} else {
				velgKamera ();
				timer = 20;
			}
		
		} else {
			Deactivate();
		}
	}

	void velgKamera(){
		int camera = Mathf.FloorToInt(Random.Range(1,6));
		switch (camera) {
		case 1: Deactivate();
			camera1.SetActive(true);
			break;
		case 2: Deactivate();
			camera2.SetActive(true);
			break;
		case 3: Deactivate();
			camera3.SetActive(true);
			break;
		case 4: Deactivate();
			camera4.SetActive(true);
			break;
		case 5: Deactivate();
			camera5.SetActive(true);
			break;
		case 6: Deactivate();
			camera6.SetActive(true);
			break;
		default: Deactivate();
			break;
		}
	}

	public void Deactivate(){
		camera1.SetActive (false);
		camera2.SetActive (false);
		camera3.SetActive (false);
		camera4.SetActive (false);
		camera5.SetActive (false);
		camera6.SetActive (false);	
	}

	

}
