using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PlayerObstacleAway : PlayerCollisionsController
	{
		protected override void OnSceneObjectHit(Collider collider)
		{
			if(collider.CompareTag(Tags.GameObstacle))
			{
				OnCollisionEventStart(Tags.GameObstacleAway);
			}
		}
	}
}
