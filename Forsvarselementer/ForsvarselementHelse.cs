using UnityEngine;
using System.Collections;

public class ForsvarselementHelse : MonoBehaviour
{	/* Dette skriptet håndterer forsvarelmentets helse og inneholder metoder som forteller om forsvarelmentet er død eller ikke
	* samt metode for om forsvarelmentet mottar skade fra fiender
	 */

    // script referanser
    private Forsvarselement forsvarselement;


    void Start()
    {
        // cache
        forsvarselement = GetComponentInParent<Forsvarselement>();

    }

    public void taSkade(int skadeInn)
    {
        // trekker skaden fra HP
        forsvarselement.helse -= skadeInn;
        // sjekker om HP er lik eller større enn 0
        if (forsvarselement.helse <= 0)
        {
			StartCoroutine("Die");
        }
    }

	/* Her kommer det en liten bugfix
	 * For at fienden skal oppfatte exit trigger flyttes objektet bort fra trigger og der etter
	 * blir destroyed
	 */

	public IEnumerator Die()
    {
		transform.Translate (Vector3.up * 10000);
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
     }
}
