using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public abstract class AbstractGameController : MonoBehaviour
	{
		protected bool _isGameActive = false;

		private void OnEnable()
		{
			GameController.OnGameStart += StartGameEvent;
			GameController.OnGameOver += EndGameEvent;
		}

		private void OnDisable()
		{
			GameController.OnGameStart -= StartGameEvent;
			GameController.OnGameOver -= EndGameEvent;
		}

		private void Awake()
		{
			Init();
		}

		private void StartGameEvent()
		{
			_isGameActive = true;
			StartGame();
		}

		private void EndGameEvent()
		{
			_isGameActive = false;
			EndGame();
		}

		private void Update()
		{
			OnUpdate();
		}

		protected abstract void Init();

		protected abstract void StartGame();

		protected abstract void EndGame();

		protected virtual void OnUpdate() { }
	}
}
