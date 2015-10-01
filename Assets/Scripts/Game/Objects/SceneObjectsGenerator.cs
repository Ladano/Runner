using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class SceneObjectsGenerator : AbstractGameController
	{
		[SerializeField] private GameObject _singleObstaclePrefab;
		[SerializeField] private GameObject _doubleObstaclePrefab;
		[SerializeField] private GameObject _tripleObstaclePrefab;
		[SerializeField] private GameObject _bonusPrefab;

		private GenericPool<BaseSceneObject> _singleObstaclesPool;
		private GenericPool<BaseSceneObject> _doubleObstaclesPool;
		private GenericPool<BaseSceneObject> _tripleObstaclesPool;
		private GenericPool<BonusSceneObject> _bonusesPool;

		protected override void Init()
		{
			_singleObstaclesPool = new GenericPool<BaseSceneObject>(_singleObstaclePrefab, 10);
			_doubleObstaclesPool = new GenericPool<BaseSceneObject>(_doubleObstaclePrefab, 10);
			_tripleObstaclesPool = new GenericPool<BaseSceneObject>(_tripleObstaclePrefab, 10);
			_bonusesPool = new GenericPool<BonusSceneObject>(_bonusPrefab, 10);
		}
		
		protected override void StartGame()
		{

		}
		
		protected override void EndGame()
		{

		}

		public void GetObstacle()
		{

		}

		public void GetBonus()
		{

		}
	}
}
