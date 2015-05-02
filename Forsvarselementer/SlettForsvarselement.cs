using UnityEngine;
using System.Collections;

public class SlettForsvarselement : MonoBehaviour
{
	/* Dette skriptet håndterer sletting/salg av forsvarselementer
	 * Basert på hvilken level forsvarelmentet har, også da hvor mye spilleren har brukt av
	 * gull på å oppgradere forsvarselmentet, får spilleren proposjonalt tilbake halvparten av pengene
	 */
    private int oppgraderingVerdi;
    private int level;

    // script referanser
    private Forsvarselement forsvarselement;

    void Start()
    {
        // cacher referanser
        forsvarselement = GetComponent<Forsvarselement>();
    }

    public void Selg()
    {
        // henter verdier
        level = forsvarselement.level;
        oppgraderingVerdi = forsvarselement.oppgraderingKostnad;


        if (level == 1)
        {
            GameManager.instance.penger.leggTilPenger(oppgraderingVerdi * 1 / 2);
        }
        else if (level == 2)
        {
            GameManager.instance.penger.leggTilPenger(oppgraderingVerdi * 1);
        }
        else if (level == 3)
        {
            GameManager.instance.penger.leggTilPenger(oppgraderingVerdi * 3 / 2);
        }

        // slett gameobjektet
        Destroy(this.gameObject);
    }
}
