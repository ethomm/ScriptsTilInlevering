using UnityEngine;
using System.Collections;

public class RTSCamera : MonoBehaviour {
	/* Dette skriptet håndterer bevegelsen til kamera
	 * Skriptet er løst basert på http://forum.unity3d.com/threads/rts-camera-script.72045/
	 * Men er blitt endret en del siden den ble kopiert inn
	 */
	
	public float ScrollSpeed = 15;
	
	public float ScrollEdge = 0.1f;
	
	public float PanSpeed = 10;
	
	public Vector2 zoomRange = new Vector2( -10, 100 );
	
	public float CurrentZoom = 0;
	
	public float ZoomZpeed = 1;
	
	public float ZoomRotation = 1;
	
	public Vector2 zoomAngleRange = new Vector2( 20, 70 );
	
	public float rotateSpeed = 10;
	
	private Vector3 initialPosition;
	
	private Vector3 initialRotation;
	private float horizontal;
	private float vertical;
	private float rotate;
	private float cancel;
	//private GameManager gameManager;
	private MenuGui menuGui;

	void Awake(){
		//gameManager = GameObject.Find ("ScriptHolder").GetComponent<GameManager> ();
		menuGui = GameObject.Find ("ScriptHolder").GetComponent<MenuGui> ();
	}
	
	
	void Start () {
		initialPosition = transform.position;      
		initialRotation = transform.eulerAngles;
	}
	
	
	void Update () {

			horizontal = Input.GetAxis ("Horizontal"); 
			vertical = Input.GetAxis ("Vertical");
			rotate = Input.GetAxis ("RotateCamera");

			if(Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape)){
				menuGui.PauseGame();
			}

			if (horizontal > 0) {             
				transform.Translate (Vector3.right * Time.deltaTime * PanSpeed, Space.Self);   
			} else if (horizontal < 0) {            
				transform.Translate (Vector3.right * Time.deltaTime * -PanSpeed, Space.Self);              
			}
			
			if (vertical > 0) {            
				transform.Translate (Vector3.forward * Time.deltaTime * PanSpeed, Space.Self);             
			} else if (vertical < 0) {         
				transform.Translate (Vector3.forward * Time.deltaTime * -PanSpeed, Space.Self);            
			}  
			
			if (rotate > 0) {
				transform.Rotate (Vector3.up * Time.deltaTime * -rotateSpeed, Space.World);
			} else if (rotate < 0) {
				transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
			}

			// zoom in/out
			CurrentZoom -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;
		
			CurrentZoom = Mathf.Clamp (CurrentZoom, zoomRange.x, zoomRange.y);
		
			transform.position = new Vector3 (transform.position.x, transform.position.y - (transform.position.y - (initialPosition.y + CurrentZoom)) * 0.1f, transform.position.z);
		
			float x = transform.eulerAngles.x - (transform.eulerAngles.x - (initialRotation.x + CurrentZoom * ZoomRotation)) * 0.1f;
			x = Mathf.Clamp (x, zoomAngleRange.x, zoomAngleRange.y);
		
			transform.eulerAngles = new Vector3 (x, transform.eulerAngles.y, transform.eulerAngles.z);

	}
}
