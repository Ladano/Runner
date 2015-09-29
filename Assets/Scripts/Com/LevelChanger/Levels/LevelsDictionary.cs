using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Com
{
	public class LevelsDictionary
	{
		private static List<LevelData> _levels =  new List<LevelData>()
		{
			{ new LevelData(LevelId.MenuScene, "MenuScene") },
			{ new LevelData(LevelId.GameScene, "GameScene") }
		};
		
		public static LevelData GetLevelDataById(LevelId level)
		{
			LevelData result = _levels.FirstOrDefault( a => a.Level==level );
			if(result!=null)
			{
				return result;
			}
			else
			{
				Debug.LogException(new System.Exception("Not found level data for LevelId = " + level.ToString()));
				return null;
			}
		}
	}
}