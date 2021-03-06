using System.Collections;
using UnityEngine;

public class Kampfase : MonoBehaviour
{
	/* Dette skriptet håndterer kampfasen
	 */
    public int antallFienderPerWave;
    public int antallWave;
    public int antallFiender;
    public int spawnedeFiender;

    public float ventMedGruppe;
    public float ventMedFiende;

	private bool erIgangMedSpawning = false;

    // gameobject referanser
    public Transform fiendeHolder;

    // gui referanser
    private FaseSkifte faseSkifte;
    private FaseGUI faseGUI;
    //private Forberedelsesfase forberedelsesfase;
	private int antallVikingerAaDrepe;


	//Skript referanser
	private SpawnpointManager spawnpointManager;

	void Start()
    {
        // cacher referanser
        faseSkifte = GetComponent<FaseSkifte>();
        faseGUI = GetComponent<FaseGUI>();
        //forberedelsesfase = GetComponent<Forberedelsesfase>();
		spawnpointManager = GameObject.Find ("Spawnpoints").GetComponent<SpawnpointManager> ();

        // setter verdier
        spawnedeFiender = fiendeHolder.transform.childCount;
   
		antallFienderPerWave = 3;
        antallWave = 1;
        antallFiender = 0;

        ventMedGruppe = 2f;
        ventMedFiende = 3f;

    }

    void Update()
    {
		// setter gui teskt på hvor mange fiender som skal drepes
		faseGUI.fienderIgjen.text = antallVikingerAaDrepe.ToString();
		//Antall fiender sette fra spawnmanager
		antallFiender = spawnpointManager.antallfiender;
		//Antall fiender som er igjen på brettet hentes fra FiendeHolder.child count
        spawnedeFiender = fiendeHolder.transform.childCount;
        // dersom det ikke er forbereldesfase
        if (!GameManager.instance.erForberedelsesFase)
        {
            // TEST-metode som lar spilleren avslutte kampfase med "U"
            avsluttKampfase();

            // metode som sjekker om kampfasen skal avsluttes
            sjekkOmAlleFienderErDrept();
        }
    }

    public void startKampfase()
    {
		antallVikingerAaDrepe = (antallFienderPerWave * GameManager.instance.runde);
        // disabler gameobject som viser GUI for funksjonalitet som ikke kan gjøres i kampfase
        faseGUI.slotContainer.SetActive(false);
		faseGUI.faseTimer.SetActive (false);
		faseGUI.fiendeTeller.SetActive (true);

        // sier at det er første wave av fiender i denne runden
		spawnpointManager.ErForsteFase (true);

        // starter metoden som spawner fiender
        // den skal bare starte om det ikke er igang med spawning 
        // (ikke sikkert om sjekken trengs, men lar den stå)
        if (!erIgangMedSpawning) spawnpointManager.StartCoroutine("spawnFiender");
    }

    // midlertidig måte å finne ut om alle fiendene er drept
    public void sjekkOmAlleFienderErDrept()
    {
        // henter antallet fiender som finnes i spillverden
        // hvis antall fiender å drepe og antall fiender i spillverden er 0, 
        if (antallVikingerAaDrepe == 0 && spawnedeFiender == 0)
        {
            // reset antall fiender
            antallFiender = 0;

            // sett forberedelsfase
            GameManager.instance.erForberedelsesFase = true;
            faseSkifte.SkiftFase(GameManager.instance.erForberedelsesFase);
        }
    }

    // FOR TESTING: midlertidig måte å avslutte kampfase uten å ha drept alle fiender
    public void avsluttKampfase()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            slettAlleFiender();
            GameManager.instance.erForberedelsesFase = true;
            faseSkifte.SkiftFase(GameManager.instance.erForberedelsesFase);
        }
    }

    public void slettAlleFiender()
    {
        // henter antall fiender i fiendeholderen
        int childs = fiendeHolder.childCount;

        // sletter fiendene
        for (int i = 0; i < childs; i++)
        {
            GameObject.Destroy(fiendeHolder.GetChild(i).gameObject);
        }
    }
	
    //En stter for er i gang smed spawning
	public void ErIgangMedSpwaning(bool b){
		erIgangMedSpawning = b;
	}

    //Getter og settere
	public int AntallFienderPerWave{ get; set;}
	public int AntallWave{ get; set;}
	public int AntallFiender{ get; set;}
	
	public float VentMedGruppe {get; set;}
	public float VentMedFiende {get; set;}

    //Antall fiender counter
	public void SettAntallFiender(){
		antallFiender ++;
	}
    //Fiender å drepegcounter
	public void DreptFiende(){
		antallVikingerAaDrepe--;
	}

}
