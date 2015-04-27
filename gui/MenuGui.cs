using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuGui : MonoBehaviour {

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

	private GameManager gameManager;
	public bool pause = false;
	private string typedPlayerName;

	void Awake(){
		gameManager = gameObject.GetComponent<GameManager> ();
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

	public void NewGameMenU(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		gameover.SetActive (false);
		newGameMenu.SetActive (true);
	}

	public void SettingMenu(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		setting.SetActive (true);
	}

	public void LoadGame(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		loadMeny.SetActive (true);
	}

	public void SaveGameMenu(){
		pauseMenu.SetActive (false);
		saveGameMenu.SetActive (true);
	}

	public void PlayerName(){
		typedPlayerName = playerName.text;
	}

	public void LeaveGame(){
		pauseMenu.SetActive (false);
		apningsmeny.SetActive (false);
		gameover.SetActive (false);
		exitMenu.SetActive (true);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void GameOver(){
		gameover.SetActive (true);
		gameGui.SetActive (false);
	}

	public void StartGame(){

		mainCamera = Camera.main;
		GameManager.instance.StartNewGame (typedPlayerName);
		playerName.text = "";
		playerName.DeactivateInputField();
		newGameMenu.SetActive (false);
		gameGui.SetActive (true);
	}

	//Pause game
	//Blir kalt på av RTSCameraScriptet
	public void PauseGame(){

		if (!pause){
			pauseMenu.SetActive (true);
			Time.timeScale = 0.000001f; 
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
