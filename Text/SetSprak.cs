using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class SetSprak : MonoBehaviour {

/*Dette skriptet setter språket i spillet. 
* når et det kun et språk men kan enkel tendres ved å legge til flere dictionarys og sette en if spørrring på valgt språk
*
* Hver tekstfelt i spillet om ikke inneholder dynamiske tall har en egen Nøkkel. Nøkkelen er  kan så brykes til å lenke til valgt språk.
*
* For eksempel ("NØKKEL", "Språktekst")
*/
	// Henter referanse til tekstelementer
	private TextBoxRefrence tb;
	// Lager en ordliste
	public Dictionary <string, string> lang = new Dictionary <string, string>();

	void Awake(){
		//Skaffer referanse punket til tekstelementene
		tb = GetComponent<TextBoxRefrence> ();
		
		//Legger til ord
		//Gui items
		lang.Add("POINTS", "Pints:");
		lang.Add("GOLD" ,"Gold:");
		lang.Add("NIGHT_TIME_IN", "Night time In:");
		lang.Add("ROUND", "Round:");
		lang.Add("PLAYER_NAME", "Player:");
		lang.Add("VIKINGS_TO_KILL", "Vikings to Kill:");
		
		//MenuItems
		lang.Add("CONTINUE","Continue");
		lang.Add("NEWGAME", "New Game");
		lang.Add("SAVEGAME", "Save Game");
		lang.Add("LOADGAME", "Load Game");
		lang.Add("SETTINGS", "Settings");
		lang.Add("EXITGAME", "Exit game...");
		lang.Add("START", "Start!");
		lang.Add("CANCEL", "Go Back..");
		lang.Add("QUITGAME", "Exit now");
		
		
		//Meldinger
		lang.Add("WELCOME", "Welcome!");
		lang.Add ("GAMEOVER", "Game Over");
		lang.Add ("YOURSCORE", "Your Score");
		lang.Add("NEWGAMETEXT", "Please enter your name to claim your place in our top score...");
		lang.Add("COPYRIGHTS", "This game was made as part of an exame in gamprograming at Høgskolen i Østfold");
		lang.Add("WRITEYOURNAME", "Enter your name...");
		lang.Add("NOGAMESTOLOAD", "No games to load at this time");
		lang.Add("NOSETTINGS", "This game has no settings at this time, Come back later...");
		lang.Add("QUITGAMETITLE","What!");
		lang.Add("QUITGAMETEXT", "Are you sure yo know what you are doing...");
		lang.Add("NOSAVE", "No slots avablie at this time");
		SettSprak ();
	}
	

	private void SettSprak(){
		//Setter språket på de forskjellige tekstelementene
		//GameGui
		tb.points.text = (string)lang["POINTS"];
		tb.gold.text = (string)lang["GOLD"];
		tb.nightTimein.text = (string)lang["NIGHT_TIME_IN"];
		tb.runde.text = (string)lang["ROUND"];
		tb.vikingsToKill.text = (string)lang["VIKINGS_TO_KILL"];
		tb.namePlayer.text = (string)lang["PLAYER_NAME"];

		//Aapningsmeny Items
		tb.continueMenu.text = (string)lang["CONTINUE"];
		tb.newGameMenu.text = (string)lang["NEWGAME"];
		tb.settingMenu.text = (string)lang["SETTINGS"];
		tb.loadGameMenu.text = (string)lang["LOADGAME"];
		tb.exitGameMenu.text = (string)lang["EXITGAME"];
		tb.copyRights.text = (string)lang["COPYRIGHTS"];	
		
		//New Game Menu
		tb.newGameWelcome.text = (string)lang["WELCOME"];
		tb.newGameWelcomText.text = (string)lang["NEWGAMETEXT"];
		tb.newGamePlaceholderText.text = (string)lang["WRITEYOURNAME"];
		tb.newGameStart.text = (string)lang["START"];
		tb.newGameGoBack.text = (string)lang["CANCEL"];
		
		//Load Game Menu
		tb.loadGameMenuText.text = (string)lang["LOADGAME"];
		tb.loadGameMenuNoGame.text = (string)lang["NOGAMESTOLOAD"];
		tb.loadGameMenuGoBack.text = (string)lang["CANCEL"];
		
		//Setting Menu
		tb.settingMenuTitel.text = (string)lang["SETTINGS"];
		tb.settingMenuNosetting.text = (string)lang["NOSETTINGS"];
		tb.settingMenuGoBack.text = (string)lang["CANCEL"];
		
		//Exit Game Menu
		tb.exitGameTitel.text = (string)lang["QUITGAMETITLE"];
		tb.exitGameText.text = (string)lang["QUITGAMETEXT"];
		tb.exitGameConfirm.text = (string)lang["QUITGAME"];
		tb.exitGameGoBack.text = (string)lang["CANCEL"];
		
		//Pause Game Menu
		tb.pauseMenuContinue.text = (string)lang["CONTINUE"];
		tb.pauseMenuSaveGame.text = (string)lang["SAVEGAME"];
		tb.pauseMenuNewGame.text = (string)lang["NEWGAME"];
		tb.pauseMenuLoadGame.text = (string)lang["LOADGAME"];
		tb.pauseMenuSetting.text = (string)lang["SETTINGS"];
		tb.pauseMenuExitGame.text = (string)lang["EXITGAME"];
		tb.pauseMenuCopyright.text = (string)lang["COPYRIGHTS"];
		
		//Save Game Menu
		tb.saveGameTitel.text = (string)lang["SAVEGAME"];
		tb.saveGameText.text = (string)lang["NOSAVE"];
		tb.saveGameCancel.text = (string)lang["CANCEL"];

		//Game Over Menu
		tb.gameOverTitel.text = (string)lang["EXITGAME"];
		tb.gameOverYourScore.text = (string)lang["EXITGAME"];
		tb.gameoverNewGame.text = (string)lang["NEWGAME"];
		tb.gameOverExit.text = (string)lang["EXITGAME"];
	
	}

}
