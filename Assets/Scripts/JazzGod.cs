using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JazzGod : MonoBehaviour {
	public SoundManager sMangr;
	public static float counter;
	public float lengthOfTrack = 8;
	private bool improv = false;

	public List<JazzSound> sounds = new List<JazzSound>();
//	Dictionary<string[], float> sounds = new Dictionary<string, float>();
	void Awake()
	{
		sMangr = GameObject.FindObjectOfType<SoundManager>();
	}
	void Start () 
	{
	
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

		for(int i = 0; i < sounds.Count; i++)
		{
			if(!sounds[i].played && sounds[i].timeToPlay <=counter)
			{
				sounds[i].played = true;
				SoundManager.PlaySFX(sounds[i].soundName);
			}
//			Debug.Log (sounds[i].soundName);
		}
		
		if(Input.GetKeyDown("a"))
		{
			sounds.Add(new JazzSound(counter, "Laser2", false));
//			sounds.Add(new string[] {"Laser2", "played"},counter);
//			SoundManager.PlaySFX("Laser2");
		}
		if(Input.GetKeyDown("s"))
		{
			sounds.Add(new JazzSound(counter, "Flashbang1", false));
		}
	}
}
