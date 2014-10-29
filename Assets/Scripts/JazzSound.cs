using UnityEngine;
using System.Collections;

public class JazzSound 
{

	public float timeToPlay;
	public string soundName;
	public bool played;
	public bool placed;

	public JazzSound(float newTimeToPlay, string newSoundName,bool  newPlayed, bool newPlaced)
	{
		timeToPlay =  newTimeToPlay;
		played = newPlayed;
		soundName = newSoundName;
		placed = newPlaced;
//		name = newName;
//		power = newPower;
	}
}
