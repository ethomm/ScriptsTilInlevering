using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Norsk : MonoBehaviour {

	
	public Dictionary <string, string> lang = new Dictionary<string, string>();
	public void RunLanguage(){
		//Gui items
		lang.Add("POINTS", "Peng:");
		lang.Add("GOLD" ,"Gull:");
		lang.Add("NIGHT_TIME_IN", "Natt om:");
		lang.Add("ROUND", "Runde:");
		lang.Add("PLAYER_NAME", "Spiller:");
		lang.Add("VIKINGS_TO_KILL", "Vikinger å drepe:");
		
		//MenuItems
		lang.Add("CONTINUE","Forstsett");
		lang.Add("NEWGAME", "Nytt Spill");
		lang.Add("SAVEGAME", "Lagre Spill");
		lang.Add("LOADGAME", "Last Inn Spill");
		lang.Add("SETTINGS", "Valg");
		lang.Add("EXITGAME", "Avslutt spill...");
		lang.Add("START", "Start!");
		lang.Add("CANCEL", "Gå Tilbake");
		lang.Add("QUITGAME", "Avslutt nå");
		
		
		//Meldinger
		lang.Add("WELCOME", "Velkommen");
		lang.Add("GAMEOVER", "Du Tapte");
		lang.Add("YOURSCORE", "Din Poengsum");
		lang.Add("NEWGAMETEXT", "Venlig skriv inn navne ditt, slik at du kan kreve din plass i toppscore lista...");
		lang.Add("COPYRIGHTS", "Dette spillet er laget som en del av en eksamen i spillprogrammering ved Høgskolen i Østfold");
		lang.Add("WRITEYOURNAME", "Skriv inn ditt navn...");
		lang.Add("NOGAMESTOLOAD", "Ingen spill er tilgjengelige for å bli lastet inn");
		lang.Add("NOSETTINGS", "Dete spillet har ingen valg..");
		lang.Add("QUITGAMETITLE","Hva!");
		lang.Add("QUITGAMETEXT", "Er du sikker på at du vet hva du driver med?");
		lang.Add("NOSAVE", "Det er ingen steder du kan lagre spillet før øyeblikket...");
		lang.Add ("SELECTLANG", "Velg språk du ønsker skal vises");
		
	}
}
