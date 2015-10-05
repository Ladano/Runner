using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Game
{
	public class SceneObjectsGenerator : AbstractGameController
	{
		private const float sceneObjectsYPos = 0.55f;

		public static SceneObjectsGenerator Instance;

		[SerializeField] private SceneObjectsType _obstacles;
		[SerializeField] private SceneObjectsType _bonuses;

		private GenericPool<BonusSceneObject> _bonusesPool;

		protected override void Init()
		{
			Instance = this;
			_obstacles.SceneObjects.ForEach( a => a.InitPool() );
			_bonuses.SceneObjects.ForEach( a => a.InitPool() );
		}

		public void TerrainFragmentFilling(TerrainFragment terrainFragment)
		{
			for(int i=1; i<=terrainFragment.TerrainLength; i++)
			{
				if(!TryToSpawn(_obstacles, terrainFragment, i))
				{
					TryToSpawn(_bonuses, terrainFragment, i);
				}
			}
		}

		private bool TryToSpawn(SceneObjectsType _objects, TerrainFragment terrainFragment, int zPos)
		{
			SceneObjectsData _objectToSpawn = _objects.NeedToSpawn();
			if(_objectToSpawn!=null)
			{
				_objects.CooldownCounter += _objects.Cooldown;
				BaseSceneObject sceneObject = _objectToSpawn.SceneObjectPool.GetObjectFromPool();
				sceneObject.transform.parent = terrainFragment.transform;
				sceneObject.transform.localPosition = new Vector3(_objectToSpawn.PossibleLineSpawn.GetRandomItem().localPosition.x,
				                                                  sceneObjectsYPos,
				                                                  zPos);
				terrainFragment.AddSceneObject(sceneObject, _objectToSpawn.SceneObjectPool);
				return true;
			}
			return false;
		}
	}
}
