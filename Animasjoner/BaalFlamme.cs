using UnityEngine;
using System.Collections;

public class BaalFlamme : MonoBehaviour {
	
	public float minLysstyrke = 0f;
	public float maxLysstyrke = 1f;

	public float duration = 4.0F;
	public Light lt;
	void Start() {
		lt = GetComponent<Light>();
	}
	void Update() {
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos(phi) * 3.5F + 3.5F;
		lt.intensity = amplitude;
	}
	
}
