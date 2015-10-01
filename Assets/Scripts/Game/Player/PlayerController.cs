using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PlayerController : AbstractGameController
	{
		private enum MoveSide { left =  -1, rigth = 1 }

		[SerializeField] private GameObject _player;
		[SerializeField] private GameObject _playerPhysicBody;
		[SerializeField] private GameObject _playerGraphicBody;
		[SerializeField] private float _lineOffset = 1.2f;
		[SerializeField] private float _moveSideTime = 0.2f;
		[SerializeField] private float _jumpTime = 1.0f;
		[SerializeField] private float _jumpHeight = 1.0f;
		private bool _isControlActive = false;
		private int _currentPos = 0; //может принимать значения (-1)слева, (0)по цетру, (1)справа

		protected override void Init()
		{

		}
		
		protected override void StartGame()
		{
			_isControlActive = true;	
		}
		
		protected override void EndGame()
		{
			_player.SetActive	(false);
		}

		#region Controls
		protected override void OnUpdate()
		{
			PlayerControlMethod();
		}

		private void PlayerControlMethod()
		{
			if(_isControlActive)
			{
				if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
				{
					Move(MoveSide.left);
				}
				if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
				{
					Move(MoveSide.rigth);
				}
				if(Input.GetKeyDown(KeyCode.Space))
				{
					Jump();
				}
			}
		}

		/// <summary>
		/// Move the specified direction.
		/// </summary>
		/// <param name="direction">Direction.</param>
		private void Move(MoveSide direction)
		{
			int newPos = Mathf.Clamp(_currentPos + (int)direction, -1, 1);
			if(newPos!=_currentPos)
			{
				_currentPos = newPos;
				_isControlActive = false;
				_playerPhysicBody.transform.localPosition = new Vector3(_lineOffset * _currentPos,
				                                                        _playerPhysicBody.transform.localPosition.y,
				                                                        _playerPhysicBody.transform.localPosition.z);
				LeanTween.move(_playerGraphicBody, _playerPhysicBody.transform.position, _moveSideTime)
					.setOnComplete(UnlockConrol);
			}
		}

		/// <summary>
		/// Jump player
		/// </summary>
		private void Jump()
		{
			_isControlActive = false;
			LeanTween.moveLocalY(_player, _player.transform.localPosition.y + _jumpHeight, _jumpTime / 2)
				.setLoopCount(2)
				.setLoopType(LeanTweenType.pingPong)
				.setOnComplete(UnlockConrol);
		}

		private void UnlockConrol()
		{
			_isControlActive = true;
		}
		#endregion
	}
}
