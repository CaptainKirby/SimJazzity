using UnityEngine;
using System.Collections;

public class CounterBar : MonoBehaviour {

	public float startPos = -10;
	public float endPos = 10;
	private JazzGod jGod;
	// Use this for initialization
	void Start () {
		jGod = GameObject.FindObjectOfType<JazzGod>().GetComponent<JazzGod>();
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(Mathf.Lerp(startPos, endPos, JazzGod.counter / jGod.lengthOfTrack), transform.position.y,transform.position.z);
	}
}
