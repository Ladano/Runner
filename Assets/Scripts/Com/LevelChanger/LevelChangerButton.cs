using UnityEngine;
using System.Collections;

namespace Com.Scenes
{
	public class LevelChangerButton : AbstractButton
	{
		[SerializeField] protected LevelId _levelId;

		protected override void ButtonAction()
		{
			StartLoadLevel();
		}

		protected virtual void StartLoadLevel()
		{
			LevelChanger.StartLoadLevel(_levelId);
		}
	}
}