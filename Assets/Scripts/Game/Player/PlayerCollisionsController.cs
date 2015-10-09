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
			_instanceRigidbody = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			_instanceRigidbody.WakeUp();
		}

		private void OnTriggerEnter(Collider collider)
		{
			OnSceneObjectHit(collider);
		}

		protected virtual void OnSceneObjectHit(Collider collider)
		{
			OnCollisionEventStart(collider.tag);
			BaseSceneObject obj = collider.GetComponent<BaseSceneObject>();
			if(obj!=null)
			{
				obj.OnPlayerCollision();
			}
		}

		protected void OnCollisionEventStart(string tag)
		{
			if(OnObjectCollision!=null)
			{
				OnObjectCollision(tag);
			}
		}
	}
}
