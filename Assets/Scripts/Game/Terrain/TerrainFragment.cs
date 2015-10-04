using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Com.Game
{
	public class TerrainFragment : MonoBehaviour
	{
		[SerializeField] private Transform _nextTerrainWp;
		private List<InstanceSceneObjects> _sceneObjects = new List<InstanceSceneObjects> ();
		public int TerrainLength = 20;

		public void Filling()
		{
			SceneObjectsGenerator.Instance.TerrainFragmentFilling(this);
		}

		public Transform GetNextTerrainWp()
		{
			return _nextTerrainWp;
		}

		public void AddSceneObject(BaseSceneObject sceneObject, GenericPool<BaseSceneObject> pool)
		{
			_sceneObjects.Add(new InstanceSceneObjects(sceneObject, pool));
		}

		public void ReleaseAllObjects()
		{
			_sceneObjects.ForEach( a => a.Pool.ReleaseObject(a.SceneObject) );
			_sceneObjects.Clear();
		}
	}

	public	 class InstanceSceneObjects
	{
		public BaseSceneObject SceneObject;
		public GenericPool<BaseSceneObject> Pool;

		public InstanceSceneObjects(BaseSceneObject sceneObject, GenericPool<BaseSceneObject> pool)
		{
			SceneObject = sceneObject;
			Pool = pool;
		}
	}
}
