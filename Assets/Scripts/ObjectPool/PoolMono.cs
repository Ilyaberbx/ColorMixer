
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ColorMixer.ObjectPool
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        public List<T> ActivePool => _activePool;
        private T _prefab;

        private bool _autoExpand;

        private Transform _parent;

        private List<T> _pool = new List<T>();
        private List<T> _activePool = new List<T>();

        public PoolMono(T prefab,int capacity,bool autoExpand,Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;
            CreatePool(capacity);
        }
        public T GetFreeElement()
        {
            if(HasFreeElement(out T element))
            {
                _activePool.Add(element);
                return element;
            }
            if(_autoExpand)
            {
               var obj = CreateObject();
                _pool.Add(obj);
                _activePool.Add(obj);
                return obj;
            }
            throw new Exception("No free elements");
        }
        private void CreatePool(int capacity)
        {
            _pool = new List<T>();

            for (int i = 0; i < capacity; i++)
            {
                _pool.Add(CreateObject());
            }
        }
        private T CreateObject(bool isActiveByDefault = false)
        {
            var obj = UnityEngine.Object.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(isActiveByDefault);
            return obj;
        }
        public void Clear()
        {
            foreach (var item in _pool)
            {
                item.gameObject.SetActive(false);
            }
        }
        private bool HasFreeElement(out T element)
        {
            foreach (var poolElement in _pool)
            {
                if (!poolElement.gameObject.activeInHierarchy)
                {
                    element = poolElement;
                
                    return true;
                }               
            }
            element = null;
            return false;
        }
    }
}
