using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JazzGod : MonoBehaviour {
	public SoundManager sMangr;
	public static float counter;
	public float lengthOfTrack = 8;
	public int bpm = 75;
	public bool improv = false;

	public GameObject bpmBar;
	public Transform counterBar;
	public GameObject soundBit;
	public List<JazzSound> sounds = new List<JazzSound>();

	private AudioClip[] saxSounds;
	private AudioClip[] basSounds;
	private AudioClip[] diSounds;
	private AudioClip[] duSounds;
	private AudioClip[] highSounds;

	private List<GameObject> soundNodes = new List<GameObject>();
	private int clipCount;
	private AudioClip clip;
	//	Dictionary<string[], float> sounds = new Dictionary<string, float>();
	void Awake()
	{
		sMangr = GameObject.FindObjectOfType<SoundManager>();

	}
	void Start () 
	{
		int beatsInLength = Mathf.RoundToInt(((lengthOfTrack/60 * 100)/100*bpm)/100 * bpm);
		float interval = beatsInLength/lengthOfTrack;
		CounterBar cBar = GameObject.FindObjectOfType<CounterBar>();
		float intervalOnBar = Mathf.Abs(cBar.startPos -  cBar.endPos)/(beatsInLength-2);
		Debug.Log(beatsInLength);
		for(int i= 0; i < beatsInLength; i++)
		{
			Instantiate(bpmBar, new Vector3((cBar.beginPos.x - intervalOnBar) + i*intervalOnBar, cBar.beginPos.y, cBar.beginPos.z), bpmBar.transform.rotation);
		}
		SoundManager.SetVolumeMusic(5f);
		SoundManager.SetVolumeSFX(5f);

		Screen.orientation = ScreenOrientation.LandscapeLeft;
		saxSounds =SoundManager.LoadAllFromGroup("Sax");
		basSounds =SoundManager.LoadAllFromGroup("Bas");
		diSounds =SoundManager.LoadAllFromGroup("Di");
		duSounds =SoundManager.LoadAllFromGroup("Du");
		highSounds =SoundManager.LoadAllFromGroup("High");

		counterBar = GameObject.FindObjectOfType<CounterBar>().transform;
	}
	

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

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

//		if(Input.GetKeyDown(KeyCode.Space))
//		{
//			if(!improv)
//			{
//				improv = true;
//			}
//			else
//			{
//				improv = false;
//			}
//		}
		for(int i = 0; i < sounds.Count; i++)
		{
			if(!sounds[i].played && sounds[i].timeToPlay <=counter)
			{
				sounds[i].played = true;
				if(!sounds[i].placed)
				{
					GameObject node = Instantiate(soundBit, new Vector3(counterBar.transform.position.x, counterBar.transform.position.y, counterBar.transform.position.z + 0.01f), Quaternion.identity) as GameObject; 
					soundNodes.Add(node);
					sounds[i].placed =true;

				}
				SoundManager.PlaySFX(sounds[i].soundName, false, 0, 5, 1, Camera.main.transform.position);
			}
//			Debug.Log (sounds[i].soundName);
		}
		
//		if(Input.GetKeyDown("a"))
//		{
//			if(!improv)
//			{
//				sounds.Add(new JazzSound(counter, saxSounds[Random.Range(0, saxSounds.Length)].name, false, false));
//			}
//			else
//			{
//				SoundManager.PlaySFX(saxSounds[Random.Range(0, saxSounds.Length)]);
//
//			}
////			sounds.Add(new string[] {"Laser2", "played"},counter);
////			SoundManager.PlaySFX("Laser2");
//		}
//		if(Input.GetKeyDown("s"))
//		{
//			if(!improv)
//			{
//				sounds.Add(new JazzSound(counter, basSounds[Random.Range(0, basSounds.Length)].name, false, false));
//			}
//			else
//			{
//				SoundManager.PlaySFX(basSounds[Random.Range(0, basSounds.Length)]);
//
//			}
//		}
//		if(Input.GetKeyDown("d"))
//		{
//			if(!improv)
//			{
//				sounds.Add(new JazzSound(counter, duSounds[Random.Range(0, duSounds.Length)].name, false, false));
//			}
//			else
//			{
//				SoundManager.PlaySFX(duSounds[Random.Range(0, duSounds.Length)]);
//				
//			}
//		}
//		if(Input.GetKeyDown("w"))
//		{
//			if(!improv)
//			{
//				sounds.Add(new JazzSound(counter, diSounds[Random.Range(0, diSounds.Length)].name, false, false));
//			}
//			else
//			{
//				SoundManager.PlaySFX(diSounds[Random.Range(0, diSounds.Length)]);
//				
//			}
//		}
//		if(Input.GetKeyDown("q"))
//		{
//			if(!improv)
//			{
//				sounds.Add(new JazzSound(counter, highSounds[Random.Range(0, highSounds.Length)].name, false, false));
//			}
//			else
//			{
//				SoundManager.PlaySFX(highSounds[Random.Range(0, highSounds.Length)]);
//				
//			}
//		}
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(50, 70, 150, 130), "Sax"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, saxSounds[Random.Range(0, saxSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(saxSounds[Random.Range(0, saxSounds.Length)], false, 0, 5, 1, Camera.main.transform.position); 

			}
		}
		if (GUI.Button(new Rect(220, 70, 150, 130), "Bas"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, basSounds[Random.Range(0, basSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(basSounds[Random.Range(0, basSounds.Length)], false, 0, 5, 1, Camera.main.transform.position);

			}
		}
		if (GUI.Button(new Rect(420, 70, 150, 130), "High-hat"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, highSounds[Random.Range(0, highSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(highSounds[Random.Range(0, highSounds.Length)], false, 0, 5, 1, Camera.main.transform.position);
				
			}
		}
		if (GUI.Button(new Rect(620, 70, 150, 130), "Dudu"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, duSounds[Random.Range(0, duSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(duSounds[Random.Range(0, duSounds.Length)], false, 0, 5, 1, Camera.main.transform.position);
				
			}
		}
		if (GUI.Button(new Rect(820, 70, 150, 130), "Didi"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, diSounds[Random.Range(0, diSounds.Length)].name, false, false));
			}
			else
			{
				SoundManager.PlaySFX(diSounds[Random.Range(0, diSounds.Length)], false, 0, 5, 1, Camera.main.transform.position);
				
			}
		}

		if (GUI.Button(new Rect(50, 250, 150, 130), "Improv"))
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

		if (GUI.Button(new Rect(50, 450, 150, 130), "Reset"))
		{
			sounds.Clear();
//			SoundManager.DeleteSFX("Microphone1","Microphone");
			for(int i = 1; i < clipCount; i++)
			{

				clipCount --;
			}
//			clipCount = 0;
			foreach(GameObject gO in soundNodes)
			{
				Destroy(gO);
			}
		}

		if (GUI.Button(new Rect(550, 450, 150, 130), "Record/Stop Record"))
		{
			if(!Microphone.IsRecording("Built-in Microphone"))
			{

				clipCount ++;
				clip = Microphone.Start("Built-in Microphone", false, 10, 44100);
			}
			else
			{
				Microphone.End("Built-in Microphone");
//				SoundManager.PlaySFX(clip);
				clip.name = "Microphone" + clipCount.ToString();

				SoundManager.SaveSFX(clip);
				SoundManager.MoveToSFXGroup(clip.ToString()+clipCount.ToString(), "Microphone");
			}

		}
		if (GUI.Button(new Rect(750, 450, 150, 130), "Voice Play"))
		{
			if(!improv)
			{
				sounds.Add(new JazzSound(counter, "Microphone"+clipCount.ToString(), false, false));
//				Debug.Log (clip.ToString());

				
			}
			else
			{
				SoundManager.PlaySFX(clip, false, 0, 5, 1, Camera.main.transform.position);
				
			}
		}


	}
}
