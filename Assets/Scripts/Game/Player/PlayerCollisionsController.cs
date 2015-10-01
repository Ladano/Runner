using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PlayerCollisionsController : AbstractGameController
	{
		public static event System.Action<string> OnObjectCollision;
		private Rigidbody _instanceRigidbody;

		protected override void Init()
		{
			_instanceRigidbody = rigidbody;
		}
		
		protected override void StartGame()
		{

		}
		
		protected override void EndGame()
		{

		}

		protected override void OnUpdate()
		{
			_instanceRigidbody.WakeUp();
		}

		private void OnTriggerEnter(Collider collider)
		{
			if(OnObjectCollision!=null)
			{
				OnObjectCollision(collider.tag);
			}
		}
	}
}
