using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyStudio.Framework.GameSystem
{
    public abstract class InGameSystem
    {
        public abstract void Init();
        public abstract void Destroy();
    }
}
