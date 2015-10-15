using UnityEngine;
using System;
using System.Collections;

namespace Com.Game
{
	public interface IMovementContoller
	{
		/// <summary>
		/// Move the specified direction.
		/// </summary>
		/// <param name="direction">Direction.</param>
		void Move(float newPlayerXPos, float graphicBodyMoveTime, Action callback);
		
		/// <summary>
		/// Jump player
		/// </summary>
		void Jump(float jumpHeight, float jumpTime, Action callback);
	}
}
