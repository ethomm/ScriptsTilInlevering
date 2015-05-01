using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class English  : MonoBehaviour {


	public Dictionary <string, string> lang = new Dictionary<string, string>();
	public void RunLanguage(){
		//Gui items
		lang.Add("POINTS", "Points:");
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
		lang.Add("GAMEOVER", "Game Over");
		lang.Add("YOURSCORE", "Your Score");
		lang.Add("NEWGAMETEXT", "Please enter your name to claim your place in our top score...");
		lang.Add("COPYRIGHTS", "This game was made as part of an exame in game programming at Høgskolen in Østfold");
		lang.Add("WRITEYOURNAME", "Enter your name...");
		lang.Add("NOGAMESTOLOAD", "No games to load at this time");
		lang.Add("NOSETTINGS", "This game has no settings at this time, Come back later...");
		lang.Add("QUITGAMETITLE","What!");
		lang.Add("QUITGAMETEXT", "Are you sure yo know what you are doing...");
		lang.Add("NOSAVE", "No slots available at this time");
		lang.Add ("SELECTLANG", "Select language you want to be displayed");
 
	}
}
