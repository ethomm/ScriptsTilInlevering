using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuGui : MonoBehaviour {
	/* Klasse som håndterer menyene i spillet
	 */

	//Legger inn alle menuyene og menyelementer
	public GameObject apningsmeny;
	public GameObject loadMeny;
	public GameObject setting;
	public GameObject newGameMenu;
	public GameObject exitMenu;
	public GameObject pauseMenu;
	public GameObject saveGameMenu;
	public GameObject gameGui;
	public GameObject gameover;
	public InputField playerName;
	public Camera mainCamera;
	public GameObject norskErValgt;
	public GameObject engelskErValgt;

	private GameManager gameManager;
	public bool pause = false;
	private string typedPlayerName;
	private SetSprak setSprak;

	void Awake(){
		gameManager = gameObject.GetComponent<GameManager> ();
		setSprak = GameObject.Find ("LanguageManager").GetComponent<SetSprak> ();
		GoBack ();
	}

	void Update(){
		playerName.ActivateInputField ();
	}

	//Setter alle Aktive guiVinduer bortsett fra Åpningsvinduet
	public void GoBack (){

		loadMeny.SetActive(false);
		setting.SetActive(false);
		newGameMenu.SetActive(false);
		exitMenu.SetActive (false);
		pauseMenu.SetActive (false);
		saveGameMenu.SetActive (false);
		gameover.SetActive (false);

		if (gameManager.gameHasStarted) {
			pauseMenu.SetActive (true);
			apningsmeny.SetActive (false);
		} else {
			pauseMenu.SetActive(false);
			apningsmeny.SetActive(true);
		}
	}
	//Metode for new game meny
	public void NewGameMenU(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		gameover.SetActive (false);
		newGameMenu.SetActive (true);
	}

	// Metode for å vise settingsmeny
	public void SettingMenu(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		setting.SetActive (true);
	}
	//Metode for å vise loadgame meny
	public void LoadGame(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		loadMeny.SetActive (true);
	}
	//Metode for å vise save game menu
	public void SaveGameMenu(){
		pauseMenu.SetActive (false);
		saveGameMenu.SetActive (true);
	}

	//Metode for å hente spillernavn
	public void PlayerName(){
		typedPlayerName = playerName.text;
	}
	//metode for å forlate spillet
	public void LeaveGame(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		gameover.SetActive (false);
		exitMenu.SetActive (true);
	}
	//Metode for å avslutte spillet
	public void QuitGame(){
		Application.Quit();
	}
	//game over metode
	public void GameOver(){
		gameover.SetActive (true);
		gameGui.SetActive (false);
	}
	//Starte spill metode
	public void StartGame(){

		mainCamera = Camera.main;
		GameManager.instance.StartNewGame (typedPlayerName);
		playerName.text = "";
		playerName.DeactivateInputField();
		newGameMenu.SetActive (false);
		gameGui.SetActive (true);
	}
	//Metode for å sette språk til engelsk 
	public void setEngelsk(){
		setSprak.ByttSprak ("eng");
		norskErValgt.SetActive (false);
		engelskErValgt.SetActive (true);
	}
	//Metode for å sette språk til norsk
	public void setNorsk(){
		setSprak.ByttSprak ("nor");
		norskErValgt.SetActive (true);
		engelskErValgt.SetActive (false);
	}

	//Pause game
	//Blir kalt på av RTSCameraScriptet
	public void PauseGame(){

		if (!pause){
			pauseMenu.SetActive (true);
			Time.timeScale = 0f; 
			pause = true;
		}
		else{
			pauseMenu.SetActive (false);
			Time.timeScale = 1.0f;  
			pause = false;
		}
	//Torturial
	

	}


}
