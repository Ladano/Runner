using UnityEngine;
using System.Collections;

namespace Com
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		public static T Instance
		{
			get
			{
				if(_instance==null)
				{
					GameObject go = new GameObject("~" + typeof(T).Name);
					_instance = go.AddComponent<T>();
				}
				return _instance;
			}
		}
		
		protected virtual void Awake()
		{
			if(_instance!=null && _instance!=this)
			{
				Destroy(gameObject);
				return;
			}
			_instance = this as T;
			DontDestroyOnLoad(gameObject);

			OnCreate();
		}

		private void OnDestroy ()
		{
			OnReleaseResource ();
		}

		protected virtual void OnCreate() {}
		
		protected virtual void OnReleaseResource() {}
	}
}
