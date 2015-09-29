using UnityEngine;
using System.Collections;

namespace Com
{
	public class LevelData
	{
		public LevelId Level;
		public string LevelName;		//название сцены
		
		public LevelData(LevelId level, string levelName)
		{
			Level = level;
			LevelName = levelName;
		}
	}
}