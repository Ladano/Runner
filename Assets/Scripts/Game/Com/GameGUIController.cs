using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Com.Game
{
	public class GameGUIController : AbstractGameController
	{
		private const string TimeFormatString = "Time: {0}";
		private const string ScoreFormatString = "Score: {0}";

		[SerializeField] private Text _timeLabel;
		[SerializeField] private Text _scoreLabel;
		[SerializeField] private GameObject _pauseScreen;
		[SerializeField] private GameObject _gameOverScreen;
		private bool _isPaused = false;

		protected override void OnEnable()
		{
			base.OnEnable();
			PauseButton.OnPauseButtonAction += PauseButtonAction;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			PauseButton.OnPauseButtonAction -= PauseButtonAction;
		}

		protected override void Init() { }
		
		protected override void StartGame() { }
		
		protected override void EndGame()
		{
			_gameOverScreen.SetActive(true);
		}
		
		protected override void OnUpdate()
		{
			_timeLabel.text = string.Format(TimeFormatString, GameController.TimeScore.ToString());
			_scoreLabel.text = string.Format(ScoreFormatString, GameController.TotalScore.ToString());
		}

		private void PauseButtonAction()
		{
			_isPaused = !_isPaused;
			_pauseScreen.SetActive(_isPaused);
			Time.timeScale = (_isPaused) ? 0.0f : 1.0f;
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			if(!_isPaused)
			{
				PauseButtonAction();
			}
		}
	}
}
