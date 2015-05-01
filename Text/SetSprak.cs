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
	private Norsk no;
	private English en;
	private TextBoxRefrence tb;
	// Lager en ordliste
	public Dictionary <string, string> lang = new Dictionary <string, string>();


	void Awake(){
		//Skaffer referanse punket til tekstelementene
		en = GetComponent<English>();
		no = GetComponent<Norsk> ();
		en.RunLanguage ();
		no.RunLanguage ();
		tb = GetComponent<TextBoxRefrence> ();

		lang = en.lang;
		SettSprak ();
	}

	public void ByttSprak (string sprak){
		if (sprak == "eng") {
			lang= en.lang;
			SettSprak ();
		} else if (sprak == "nor") {
			lang = no.lang;
			SettSprak();
		}

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
		tb.settingVelgSprak.text = (string)lang ["SELECTLANG"];
		
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
		tb.gameOverTitel.text = (string)lang["GAMEOVER"];
		tb.gameOverYourScore.text = (string)lang["YOURSCORE"];
		tb.gameoverNewGame.text = (string)lang["NEWGAME"];
		tb.gameOverExit.text = (string)lang["EXITGAME"];
	
	}

}
