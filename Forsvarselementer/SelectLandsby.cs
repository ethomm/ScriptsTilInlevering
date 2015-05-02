using UnityEngine;
using System.Collections;

public class SelectLandsby : MonoBehaviour {
	/* Dette skriptet håndterer valg av Landsbyen
	 */

	public bool erValgt;
	private float buttonOffset = 20f;
	private float buttonWidth = 80f;
	
	// script referanser
	//private GameObject scriptHolder;
	private ForsvarselementPlacement forsvarselementPlacementScript;


	void Start()
	{
		// cacher referansr
		//scriptHolder = GameObject.Find("ScriptHolder");
	}
	
	public void settSomValgt(bool v)
	{
		if (v) {
			erValgt = v;
	
		} else {
			erValgt = v;	
		}
		
		
	}
	//Gammel Gui kode
	
	void OnGUI()
	{
		if (erValgt && GameManager.instance.erForberedelsesFase)
		{
			Vector2 targetPos;
			targetPos = Camera.main.WorldToScreenPoint(transform.position);
			
			if (GUI.Button(new Rect(targetPos.x + buttonOffset + (buttonWidth * 1), Screen.height - targetPos.y + buttonOffset, buttonWidth, 30), "Oppgrader"))
			{
				GetComponent<OppgraderForsvarselement>().oppgrader();	
			}
		} 
	}
}
