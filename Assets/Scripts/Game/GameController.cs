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

		public static event Action<int> OnScoreValueChange;
		public static event Action<int> OnTimePlayedValueChange;

		private static int _score;
		public static int Score
		{
			get { return _score; }
			set
			{
				if(_score!=value)
				{
					_score = value;
					if(OnScoreValueChange!=null)
					{
						OnScoreValueChange(_score);
					}
				}
			}
		}

		private static float _realTimePlayed;
		private static int _timePlayed = 0;
		public static int TimePlayed
		{
			get { return _timePlayed; }
			set
			{
				if(_timePlayed!=value)
				{
					_timePlayed = value;
					if(OnTimePlayedValueChange!=null)
					{
						OnTimePlayedValueChange(_score);
					}
				}
			}
		}

		[SerializeField] private PlayerController _playerController;
		[SerializeField] private TerrainGenerator _terrainGenerator;

		private void OnEnable()
		{
			PlayerController.OnObjectCollision += OnPlayerCollision;
		}

		private void OnDisable()
		{
			PlayerController.OnObjectCollision -= OnPlayerCollision;
		}

		private void Start()
		{
			
		}

		#region Time
		private void Update()
		{
			_realTimePlayed += Time.deltaTime;
			_timePlayed = Mathf.CeilToInt(_realTimePlayed);
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
			//TODO player death
		}

		private static void OnPickUpBonus()
		{
			//TODO player pick up bonus
			Score += 10;
		}

		private static void OnSpawnTerrainTrigger()
		{
			//TODO spawn terrain trigger
		}
		#endregion
	}
}
