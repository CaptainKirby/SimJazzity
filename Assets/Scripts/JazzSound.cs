using UnityEngine;
using System.Collections;

public class JazzSound 
{

	public float timeToPlay;
	public string soundName;
	public bool played;

	public JazzSound(float newTimeToPlay, string newSoundName,bool  newPlayed)
	{
		timeToPlay =  newTimeToPlay;
		played = newPlayed;
		soundName = newSoundName;
//		name = newName;
//		power = newPower;
	}
}
