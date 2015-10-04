using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Com
{
	public class LevelChanger : SingletonMonoBehaviour<LevelChanger>
	{
		public static event Action OnStartLoad;

		public static void StartLoadLevel(LevelId level)
		{
			Instance.LoadLevel(level);
		}

		private void LoadLevel(LevelId level)
		{
			if(OnStartLoad!=null)
			{
				OnStartLoad();
			}

			Application.LoadLevel(LevelsDictionary.GetLevelDataById(level).LevelName);
		}

		private void OnLevelWasLoaded(int id)
		{
			Time.timeScale = 1.0f;
		}
	}
}
