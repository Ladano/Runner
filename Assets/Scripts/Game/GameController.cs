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

		[SerializeField] private PlayerController _playerController;
		[SerializeField] private TerrainGenerator _terrainGenerator;
		[SerializeField] private GUIText _time;
		[SerializeField] private GUIText _score;

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
		}

		private static void OnSpawnTerrainTrigger()
		{
			//TODO spawn terrain trigger
		}
		#endregion


	}
}
