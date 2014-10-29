using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JazzGod : MonoBehaviour {
	public SoundManager sMangr;
	public static float counter;
	public float lengthOfTrack = 8;
	public bool improv = false;

	public Transform counterBar;
	public GameObject soundBit;
	public List<JazzSound> sounds = new List<JazzSound>();
//	Dictionary<string[], float> sounds = new Dictionary<string, float>();
	void Awake()
	{
		sMangr = GameObject.FindObjectOfType<SoundManager>();

	}
	void Start () 
	{
		counterBar = GameObject.FindObjectOfType<CounterBar>().transform;
	}
	

	void Update ()
	{
		counter =counter + Time.deltaTime;
		if(counter >= lengthOfTrack)
		{
			for(int i = 0; i < sounds.Count; i++)
			{
				if(sounds[i].played)
				{
					sounds[i].played = false;
				}
			}
			counter = 0;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(!improv)
			{
				improv = true;
			}
			else
			{
				improv = false;
			}
		}
		for(int i = 0; i < sounds.Count; i++)
		{
			if(!sounds[i].played && sounds[i].timeToPlay <=counter)
			{
				sounds[i].played = true;
				if(!sounds[i].placed)
				{
				Instantiate(soundBit, new Vector3(counterBar.transform.position.x, counterBar.transform.position.y, counterBar.transform.position.z + 0.01f), Quaternion.identity); 
					sounds[i].placed =true;
				}
				SoundManager.PlaySFX(sounds[i].soundName);
			}
//			Debug.Log (sounds[i].soundName);
		}
		
		if(Input.GetKeyDown("a"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, "Laser2", false, false));
			}
			else
			{
				SoundManager.PlaySFX("Laser2");
			}
//			sounds.Add(new string[] {"Laser2", "played"},counter);
//			SoundManager.PlaySFX("Laser2");
		}
		if(Input.GetKeyDown("s"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, "Flashbang1", false, false));
			}
			else
			{
				SoundManager.PlaySFX("Flashbang1");
			}
		}
	}
}
