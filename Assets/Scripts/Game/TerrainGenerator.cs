using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class TerrainGenerator : AbstractGameController
	{
		[SerializeField] private GameObject _terrainPrefab;
		[SerializeField] private int _startTerrainCount = 3;
		[SerializeField] private Transform _startTerrainPos;
		[SerializeField] private Transform _rootTerrain;
		[SerializeField] private float _speed = 1.0f;
		private GenericPool<TerrainFragment> _terrainPool;

		protected override void Init()
		{
			_terrainPool = new GenericPool<TerrainFragment>(_terrainPrefab, (uint)_startTerrainCount);
			for(int i=1; i<=_startTerrainCount; i++)
			{
				GenerateTerrain();
			}
		}

		protected override void StartGame()
		{

		}

		protected override void EndGame()
		{

		}

		private void GenerateTerrain()
		{
			TerrainFragment terrain = _terrainPool.GetObjectFromPool();
			terrain.transform.parent = _rootTerrain;
			terrain.transform.position = _startTerrainPos.position;
			_startTerrainPos = terrain.GetNextTerrainWp();
		}

		private void ReleaseTerrain(TerrainFragment terrain)
		{
			_terrainPool.ReleaseObject(terrain);
		}

		public void SpawnNewTerrain()
		{
			TerrainFragment terrain = _terrainPool.GetFirstActiveObject();
			terrain.ReleaseAllObjects();
			ReleaseTerrain(terrain);
			GenerateTerrain();
		}

		private void Update()
		{
			if(_isGameActive)
			{
				_rootTerrain.Translate(Vector3.back * Time.deltaTime * _speed);
			}
		}
	}
}
