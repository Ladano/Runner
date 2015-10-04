using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Game
{
	[System.Serializable]
	public class SceneObjectsData
	{
		[SerializeField] private GameObject SceneObjectPrefab;
		public List<Transform> PossibleLineSpawn = new List<Transform>();
		public int SpawnChance = 0;
		[HideInInspector] public GenericPool<BaseSceneObject> SceneObjectPool;

		public void InitPool()
		{
			SceneObjectPool = new GenericPool<BaseSceneObject>(SceneObjectPrefab, 5);
		}
	}
}