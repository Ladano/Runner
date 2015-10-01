using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class BonusSceneObject : BaseSceneObject
	{
		public override void OnPlayerCollision()
		{
			ReleaseObject();
		}
	}
}
