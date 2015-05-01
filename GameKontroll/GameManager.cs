using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // verdier som blir brukt og forandret i flere script
    // verdier 
    public int runde;
    public float nedteller;
    public float resetNedteller;
    public bool erForberedelsesFase = false;
    public int antallPenger = 1000;
    public int antallPoeng = 0;
	public int startpenger = 1000;
	public string playerName;
	public Text player;
	public Text pengeTekst;

    // lister

    // prefabs
    public GameObject fiende;
	public GameObject fiende2;
	public GameObject fiende3;

    // referanser
    public Penger penger;
    public Poeng poeng;

	//Til lagrin
	public Transform fiendeholder;
	public Transform forsvarelementholder;

	//Har startetspillet
	public bool gameHasStarted = false;

	//For å resette spillet
	private Kampfase kampfase;
	private FasebytteGraphics fasebyttegraphics;
	private FaseGUI faseGUI;
	//private CameraSwitching cameraSwitch;
	private MenuGui menuGui;
	public GameObject village;
	private GameOver gameOver;


    void Awake()
    {	
		antallPenger = startpenger;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        runde =0;
        nedteller = 40f;
        resetNedteller = 40f;

		fasebyttegraphics = GameObject.Find ("gameController").GetComponent<FasebytteGraphics>();
		kampfase = GetComponent<Kampfase> ();
		//cameraSwitch = GetComponent<CameraSwitching> ();
		menuGui = GetComponent<MenuGui> ();
		gameOver = GetComponent<GameOver>();
		faseGUI = GetComponent<FaseGUI> ();
    }

    void Start()
    {
        penger = GetComponent<Penger>();
        poeng = GetComponent<Poeng>();
    }


	public void StartNewGame(string player){

		erForberedelsesFase = true;
		gameHasStarted = true;
		playerName = player;
		ResetSpill ();
	}

	public void ResetSpill(){
		if (fasebyttegraphics.getErDag()) {
		}else{
			fasebyttegraphics.byttFase();
		}
		kampfase.slettAlleFiender();
		fjernForsvarsElementer ();
		antallPoeng = 0;
		runde = 1;
		faseGUI.rundeText.text = "# " + runde.ToString()+" ";
		antallPenger = startpenger;
		penger.pengeTekst.text = antallPenger.ToString () + " ";
		player.text = playerName;
		nedteller = resetNedteller;

		if (menuGui.pause) {
			menuGui.PauseGame();
		}
		village.GetComponent<Landsby> ().Awake ();
		gameOver.erGameOver = false;
		village.GetComponent<LandsbyHelse> ().isGameOver = false;
		faseGUI.slotContainer.SetActive (true);
	}

	public void fjernForsvarsElementer(){
		// henter antall fiender i fiendeholderen
		int childs = forsvarelementholder.childCount;
		
		// sletter fiendene
		for (int i = 0; i < childs; i++)
		{
			GameObject.Destroy(forsvarelementholder.GetChild(i).gameObject);
		}
	}


}
