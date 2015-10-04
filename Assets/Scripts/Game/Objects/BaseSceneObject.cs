using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class BaseSceneObject : MonoBehaviour
	{
		public virtual void OnPlayerCollision() { }

		private void Init()
		{

		}

		public void ReleaseObject()
		{
			gameObject.SetActive(false);
		}
	}
}
