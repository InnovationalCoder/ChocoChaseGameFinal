using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public string NLevel;
	public void loadLevel()
	{
		//Load the level from LevelToLoad
		SceneManager.LoadScene(NLevel);
	}

}
