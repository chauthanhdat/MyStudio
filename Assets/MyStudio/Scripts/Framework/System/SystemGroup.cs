using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyStudio.Framework.GameSystem
{
    public class SystemGroup
    {
        private Dictionary<Type, InGameSystem> _typeToSytem;

        public SystemGroup()
        {
            _typeToSytem = new();
        }

        public void RegisterSystem<T>(T system) where T : InGameSystem
        {
            var type = typeof(T);
            if (_typeToSytem.ContainsKey(type))
            {
                Debug.LogError($"System already registed: {type}");
            }
            else
            {
                _typeToSytem.Add(type, system);
                system.Init();
            }
        }

        public void UnregisterSystem<T>() where T : InGameSystem
        {
            var type = typeof(T);
        }

        public T GetSystem<T>() where T : InGameSystem 
        {
            return _typeToSytem[typeof(T)] as T;
        }
    }
}
