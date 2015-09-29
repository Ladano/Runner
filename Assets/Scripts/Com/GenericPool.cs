using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericPool<T> where T : Component {

	private Stack<T> _freePool;
	private List<T> _inUsePool;
	private GameObject _prefab;
	private Transform _poolParent;

	#region constructors

	public GenericPool(GameObject prefab):this(prefab,0)
	{
	}

	public GenericPool(GameObject prefab, uint initCapacity)
	{
		_freePool = new Stack<T>((int)initCapacity);
		_inUsePool = new List<T>();
		_prefab = prefab;
		_poolParent = new GameObject(prefab.name+"Pool").transform;
		if(initCapacity>0)
		{
			for(int i = 0; i < initCapacity; i++)
			{
				_freePool.Push(CreatedObjectFromPrefab());
			}
		}
	}
	#endregion

	/// <summary>
	/// Получить объект из пула
	/// </summary>
	public T GetObjectFromPool()
	{
		return GetObjectFromPool(true);
	}

	public T GetObjectFromPool(bool active)
	{
		T result;
		if(_freePool.Count>0)
		{
			result = _freePool.Pop();
			result.gameObject.SetActive(active);
			_inUsePool.Add(result);
			return result;
		}
		else
		{
			//create new object
			result = CreatedObjectFromPrefab(active);
			_inUsePool.Add(result);
			return result;
		}
	}

	private T CreatedObjectFromPrefab(bool activeState = false)
	{
		var createdObj = GameObject.Instantiate(_prefab) as GameObject;
		createdObj.transform.SetParent(_poolParent);
		createdObj.name = createdObj.name.Substring(0,createdObj.name.Length-7);//remove (Clone) from name
		createdObj.SetActive(activeState);
		var result = createdObj.GetComponent<T>();
		return result;
	}

	/// <summary>
	/// Get the first active object.
	/// </summary>
	/// <returns>The first active object.</returns>
	public T GetFirstActiveObject()
	{
		return _inUsePool[0];
	}

	public List<T> GetRangeActiveObjects(int count)
	{
		var result = _inUsePool.GetRange(0,count);
		return result;
	}

	public List<T> GetAllActiveObjects()
	{
		return _inUsePool;
	}

	#region release block
	/// <summary>
	/// Освободить объект из пула
	/// </summary>
	/// <param name="obj">Object.</param>
	public void ReleaseObject(T obj)
	{
		_inUsePool.Remove(obj);
		_freePool.Push(obj);
		obj.gameObject.SetActive(false);
	}

	/// <summary>
	/// Объект существует в пуле
	/// </summary>
	/// <returns><c>true</c>, if exist in pool <c>false</c> otherwise.</returns>
	public bool IsObjectExistInPool(T obj)
	{
		var result = false;
		if(_inUsePool.Exists(a=>a == obj))
			result = true;
		return result;
	}

	/// <summary>
	/// Освободить все объекты
	/// </summary>
	public void ReleaseAllObjects()
	{
		if(ActiveObjectsCount()>0)
		{
			foreach(T obj in _inUsePool)
			{
				_inUsePool.Remove(obj);
				_freePool.Push(obj);
				obj.gameObject.SetActive(false);
			}
		}
	}
	#endregion

	#region info and helpers

	/// <summary>
	/// Возвращает важные параметры для информации
	/// </summary>
	/// <returns>The info.</returns>
	public string GetInfo()
	{
		string result = "";
		result+="Prefab: ";
		if(_prefab!=null)
		{
			result+=_prefab.name + ";";
			if(_inUsePool!=null)
			{
				result += string.Format(" inUsePool: {0};",ActiveObjectsCount());
			}
			else
				result += " inusePool is null";
			if(_freePool!=null)
			{
				result += string.Format(" freePool: {0};",FreeToUseObjectsCount());
			}
			else
				result += " freePool is null";
			}
		else
			result+="null";
		return result;
	}

	/// <summary>
	/// Количество используемых объектов
	/// </summary>
	public int ActiveObjectsCount()
	{
		return _inUsePool.Count;
	}
	
	/// <summary>
	/// Количество свободных к использованию объектов в пуле
	/// </summary>
	public int FreeToUseObjectsCount()
	{
		return _freePool.Count;
	}

	public GameObject GetContainedPrefab()
	{
		return _prefab;
	}
	#endregion
}