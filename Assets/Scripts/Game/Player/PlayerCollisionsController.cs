using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PlayerCollisionsController : MonoBehaviour
	{
		public static event System.Action<string> OnObjectCollision;

		private void OnTriggerEnter(Collider collider)
		{
			if(OnObjectCollision!=null)
			{
				OnObjectCollision(collider.tag);
			}
		}
	}
}
