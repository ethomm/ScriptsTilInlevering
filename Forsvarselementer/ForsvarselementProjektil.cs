using UnityEngine;
using System.Collections;

public class ForsvarselementProjektil : MonoBehaviour
{	/* Dette skriptet jåndterer hva som skjer når et prosjektil treffer et annet objekt i spillverdenen
	 */
    public float skade;

    // kjører når projektilen kolliderer med gameobject
    void OnTriggerEnter(Collider col)
    {
        // hvis projektilen kolliderer med Landsby eller Forsvarselement
        if (col.transform.gameObject.tag == "Fiende")
        {
            // kjører metode til gameobject for skade tatt
            
			col.GetComponentInParent<FiendeHelse>().taSkade(skade);
			//col.gameObject.transform.parent.gameObject.SendMessage("taSkade", skade);

            // sletter projektilen
            Destroy(gameObject);

        }
        // hvis den treffer spill-flaten eller andre statiske objekter
        if (col.transform.gameObject.tag == "LandskapsObjekter")
        {
            // sletter projektilen
            Destroy(gameObject);
        }
    }
}
