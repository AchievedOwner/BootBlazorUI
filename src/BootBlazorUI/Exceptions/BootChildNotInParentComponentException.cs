using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI
{
    internal class BootChildNotInParentComponentException<TParent,TChild> : Exception
    {
        public BootChildNotInParentComponentException()
            : base($"子组件'{typeof(TChild).Name}'只能放在父组件'{typeof(TParent).Name}'中")
        {
        }
    }
}
