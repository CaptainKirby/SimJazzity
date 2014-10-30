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

	private AudioClip[] saxSounds;
	private AudioClip[] basSounds;
	private AudioClip[] diSounds;
	private AudioClip[] duSounds;
	private AudioClip[] highSounds;

	

	//	Dictionary<string[], float> sounds = new Dictionary<string, float>();
	void Awake()
	{
		sMangr = GameObject.FindObjectOfType<SoundManager>();

	}
	void Start () 
	{
		saxSounds =SoundManager.LoadAllFromGroup("Sax");
		basSounds =SoundManager.LoadAllFromGroup("Bas");
		diSounds =SoundManager.LoadAllFromGroup("Di");
		duSounds =SoundManager.LoadAllFromGroup("Du");
		highSounds =SoundManager.LoadAllFromGroup("High");

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
				sounds.Add(new JazzSound(counter, saxSounds[Random.Range(0, saxSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(saxSounds[Random.Range(0, saxSounds.Length)]);

			}
//			sounds.Add(new string[] {"Laser2", "played"},counter);
//			SoundManager.PlaySFX("Laser2");
		}
		if(Input.GetKeyDown("s"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, basSounds[Random.Range(0, basSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(basSounds[Random.Range(0, basSounds.Length)]);

			}
		}
		if(Input.GetKeyDown("d"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, duSounds[Random.Range(0, duSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(duSounds[Random.Range(0, duSounds.Length)]);
				
			}
		}
		if(Input.GetKeyDown("w"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, diSounds[Random.Range(0, diSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(diSounds[Random.Range(0, diSounds.Length)]);
				
			}
		}
		if(Input.GetKeyDown("q"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, highSounds[Random.Range(0, highSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(highSounds[Random.Range(0, highSounds.Length)]);
				
			}
		}
	}
}
