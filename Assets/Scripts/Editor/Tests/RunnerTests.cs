using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using Com.Game;


namespace UnityTest
{
	[TestFixture]
	[Category("Runner Tests")]
	internal class RunnerTests
	{
		#region Player tests
		[Test]
		[Category("Player Tests")]
		public void PlayerMoveOnSidePos()
		{
			IMovementContoller movementContoller = GetMovementMock();
			PlayerController controller = GetPlayerControllerMock (movementContoller);

			controller.IsControlActive = true;
			controller.CurrentPos = -1;
			controller.Move(PlayerMoveSide.left);

			movementContoller.DidNotReceive().Move(0.0f, 0.0f, () => {} );
		}

		[Test]
		[Category("Player Tests")]
		public void PlayerMoveOnCenterPos()
		{
			IMovementContoller movementContoller = GetMovementMock();
			PlayerController controller = GetPlayerControllerMock (movementContoller);
			
			controller.IsControlActive = true;
			controller.CurrentPos = 0;
			controller.Move(PlayerMoveSide.rigth);
			
			movementContoller.DidNotReceive().Move(0.0f, 0.0f, () => {} );
		}

		[Test]
		[Category("Player Tests")]
		public void PlayerMoveWhenNotControl()
		{
			IMovementContoller movementContoller = GetMovementMock();
			PlayerController controller = GetPlayerControllerMock (movementContoller);
			
			controller.IsControlActive = false;
			controller.CurrentPos = 0;
			controller.Move(PlayerMoveSide.rigth);
			
			movementContoller.DidNotReceive().Move(0.0f, 0.0f, () => {} );
		}

		[Test]
		[Category("Player Tests")]
		public void PlayerJump()
		{
			IMovementContoller movementContoller = GetMovementMock();
			PlayerController controller = GetPlayerControllerMock (movementContoller);
			
			controller.IsControlActive = true;
			controller.Jump();
			
			movementContoller.DidNotReceive().Jump(0.0f, 0.0f, () => {} );
		}

		[Test]
		[Category("Player Tests")]
		public void PlayerJumpNotControl()
		{
			IMovementContoller movementContoller = GetMovementMock();
			PlayerController controller = GetPlayerControllerMock (movementContoller);
			
			controller.IsControlActive = false;
			controller.Jump();
			
			movementContoller.DidNotReceive().Jump(0.0f, 0.0f, () => {} );
		}

		private IMovementContoller GetMovementMock()
		{
			return Substitute.For<IMovementContoller>();
		}

		private PlayerController GetPlayerControllerMock(IMovementContoller movementContoller)
		{
			PlayerController controller = Substitute.For<PlayerController>();
			controller.SetMovementController(movementContoller);
			return controller;
		}
		#endregion Player tests
	}
}
