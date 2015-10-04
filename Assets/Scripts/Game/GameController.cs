using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Com.Game
{
	public class GameController : MonoBehaviour
	{
		private static Dictionary<string, Action> _onPlayerCollisionActions = new Dictionary<string, Action>()
		{
			{ Tags.GameObstacle, OnObstacleHit },
			{ Tags.GameBonus, OnPickUpBonus },
			{ Tags.GameSpawnTerrain, OnSpawnTerrainTrigger }
		};

		public static event Action OnGameStart;
		public static event Action OnGameOver;
		public static event Action<int> OnScoreValueChange;
		public static event Action<int> OnTimePlayedValueChange;

		private static GameController _instance;

		private static int _bonusesScore = 0;
		private static float _timePlayed = 0;
		public static int TimeScore
		{
			get { return Mathf.CeilToInt(_timePlayed); }
		}
		public static int TotalScore
		{
			get { return _bonusesScore + TimeScore; }
		}
		[SerializeField] private PlayerController _playerController;
		[SerializeField] private TerrainGenerator _terrainGenerator;

		private void OnEnable()
		{
			PlayerCollisionsController.OnObjectCollision += OnPlayerCollision;
		}

		private void OnDisable()
		{
			PlayerCollisionsController.OnObjectCollision -= OnPlayerCollision;
		}

		private void Awake()
		{
			_instance = this;
		}

		private void Start()
		{
			if(OnGameStart!=null)
			{
				OnGameStart();
			}
		}

		#region Time
		private void Update()
		{
			_timePlayed += Time.deltaTime;
		}
		#endregion

		#region Player Collisions
		private void OnPlayerCollision(string objectTag)
		{
			Action onHitAction;
			if(_onPlayerCollisionActions.TryGetValue(objectTag, out onHitAction))
			{
				onHitAction();
			}
		}

		private static void OnObstacleHit()
		{
			if(OnGameOver!=null)
			{
				OnGameOver();
			}
			if(TotalScore>GlobalValues.BestScore)
			{
				GlobalValues.BestScore = TotalScore;
			}
		}

		private static void OnPickUpBonus()
		{
			_bonusesScore += 10;
		}

		private static void OnSpawnTerrainTrigger()
		{
			_instance._terrainGenerator.SpawnNewTerrain();
		}
		#endregion
	}
}
