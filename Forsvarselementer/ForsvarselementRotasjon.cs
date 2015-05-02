using UnityEngine;
using System.Collections;

public class ForsvarselementRotasjon : MonoBehaviour{
	/* Dette skripetet håndterer rotering av forsvarelmenter
	 * Forutsetter at forsvarelmentet er valgt
	 */
	// Lager rotasongraden ved å dele en full sirkel på antall roteringssegmenter
    int rotasjonGrad = 360 / 16;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GetComponent<SelectedForsvarselement>().erValgt)
        {
            // roter gameobject med klokken
            transform.Rotate(0, rotasjonGrad, 0);
        }

        if (Input.GetKeyDown(KeyCode.F) && GetComponent<SelectedForsvarselement>().erValgt)
        {
            // roter gameobject med klokken
            transform.Rotate(0, -rotasjonGrad, 0);
        }
    }
}
