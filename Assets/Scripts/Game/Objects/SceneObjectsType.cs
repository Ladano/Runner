using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Com.Game
{
	[System.Serializable]
	public class SceneObjectsType
	{
		public List<SceneObjectsData> SceneObjects = new List<SceneObjectsData>();
		public int Cooldown = 5;
		[HideInInspector] public int CooldownCounter = 0;

		public SceneObjectsData NeedToSpawn()
		{
			if(CooldownCounter==0)
			{
				int chance = Random.Range(1, 101);
				List<SceneObjectsData> _possibleToSpawn = SceneObjects.Where( a => chance<=a.SpawnChance ).ToList();
				return _possibleToSpawn.GetRandomItem();
			}
			else
			{
				CooldownCounter--;
				return null;
			}

		}
	}
}
