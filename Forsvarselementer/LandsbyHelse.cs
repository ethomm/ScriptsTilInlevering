using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LandsbyHelse : MonoBehaviour {
	/* Dette skriptet håndterer heldsen til landsbyen
	 * I motsetning til forsvarselmenetene vil ikke landbyen fjernes dersom helsen går til 0
	 * men spillet vil være tapt og spillet er game over. Logikk for Game Over blir derfor også kjørt.
	 */
    // script referanser
    private Landsby landsby;
	public bool isGameOver;
	public Text finalscore;
	private MenuGui menugui;
	private FaseGUI fasegui;


	void Awake(){
		menugui = GameObject.Find ("ScriptHolder").GetComponent<MenuGui> ();
		fasegui = GameObject.Find ("ScriptHolder").GetComponent<FaseGUI> ();
		isGameOver = false;
	}
    void Start()
    {
        // cacher referanser
        landsby = GetComponent<Landsby>();
    }

    public void taSkade(int skadeInn)
    {
        // trekker skaden fra HP
        landsby.helse -= skadeInn;

        // sjekker om HP er mer enn null
        if (landsby.helse <= 0)
        {
            Die();
        }
    }

    public void Die()
	    {
		//Kjører game over logikk
		if (!isGameOver) {
			finalscore.text = GameManager.instance.antallPoeng.ToString();
			menugui.GameOver ();
			fasegui.slotContainer.SetActive (false);
			fasegui.fiendeTeller.SetActive (false);
			isGameOver = true;
		}
    }
}
