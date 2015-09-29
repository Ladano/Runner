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

		private AsyncOperation _asyncOperation;

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

			_asyncOperation = Application.LoadLevelAsync(LevelsDictionary.GetLevelDataById(level).LevelName);
			_asyncOperation.allowSceneActivation = false;

			AllowSceneActivation();
		}

		private void AllowSceneActivation()
		{
			if(_asyncOperation!=null)
			{
				_asyncOperation.allowSceneActivation = true;
			}
		}
	}
}
