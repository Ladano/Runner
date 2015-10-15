using UnityEngine;
using System;
using System.Collections;

namespace Com.Game
{
	public class PlayerMovementController : AbstractGameController, IMovementContoller
	{
		[SerializeField] private PlayerController _playerController;
		[SerializeField] private GameObject _player;
		[SerializeField] private GameObject _playerPhysicBody;
		[SerializeField] private GameObject _playerGraphicBody;

		protected override void OnEnable()
		{
			base.OnEnable();

			_playerController.SetMovementController(this);
		}

		protected override void Init() { }
		
		protected override void StartGame()
		{
			_playerController.UnlockControl();
		}
		
		protected override void EndGame()
		{
			_player.SetActive(false);
		}

		#region Controls
		protected override void OnUpdate()
		{
			if(_isGameActive)
			{
				PlayerControlMethod();
			}
		}

		private void PlayerControlMethod()
		{
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				_playerController.Move(PlayerMoveSide.left);
			}
			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				_playerController.Move(PlayerMoveSide.rigth);
			}
			if(Input.GetKeyDown(KeyCode.Space))
			{
				_playerController.Jump();
			}
		}

		#region IMovementContoller implementation
		public void Move(float newPlayerXPos, float graphicBodyMoveTime, Action callback)
		{
			_playerPhysicBody.transform.localPosition = new Vector3(newPlayerXPos,
			                                                        _playerPhysicBody.transform.localPosition.y,
			                                                        _playerPhysicBody.transform.localPosition.z);
			LeanTween.move(_playerGraphicBody, _playerPhysicBody.transform.position, graphicBodyMoveTime)
				.setOnComplete(callback);
		}

		public void Jump(float jumpHeight, float jumpTime, Action callback)
		{
			LeanTween.moveLocalY(_player, _player.transform.localPosition.y + jumpHeight, jumpTime / 2)
				.setLoopCount(2)
				.setLoopType(LeanTweenType.pingPong)
				.setOnComplete(callback);
		}
		#endregion
		#endregion
	}
}
