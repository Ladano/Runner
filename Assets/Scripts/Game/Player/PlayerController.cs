using UnityEngine;
using System.Collections;

namespace Com.Game
{
	[System.Serializable]
	public class PlayerController
	{
		private IMovementContoller _movementContoller;

		[SerializeField] private float _lineOffset = 1.2f;
		[SerializeField] private float _moveSideTime = 0.1f;
		[SerializeField] private float _jumpTime = 1.0f;
		[SerializeField] private float _jumpHeight = 1.0f;

		private bool _isControlActive = true;
		public bool IsControlActive
		{
			get { return _isControlActive; }
			set { _isControlActive = value; }
		}
		private int _currentPos = 0; //может принимать значения (-1)слева, (0)по цетру, (1)справа
		public int CurrentPos
		{
			get { return _currentPos; }
			set { _currentPos = value; }
		}

		public void Move(PlayerMoveSide direction)
		{
			if(_isControlActive)
			{
				int newPos = Mathf.Clamp(_currentPos + (int)direction, -1, 1);
				if(newPos!=_currentPos)
				{
					_currentPos = newPos;
					_isControlActive = false;
				}
				_movementContoller.Move(_lineOffset * _currentPos, _moveSideTime, UnlockControl);
			}
		}
		
		public void Jump()
		{
			if(_isControlActive)
			{
				_isControlActive = false;
				_movementContoller.Jump(_jumpHeight, _jumpTime, UnlockControl);
			}
		}

		public void UnlockControl()
		{
			_isControlActive = true;
		}

		public void SetMovementController(IMovementContoller movementContoller)
		{
			this._movementContoller = movementContoller;
		}


	}
}
