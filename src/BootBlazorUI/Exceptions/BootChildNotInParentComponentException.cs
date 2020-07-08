using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI
{
    internal class BootChildNotInParentComponentException : Exception
    {
        public BootChildNotInParentComponentException(Type paremt,Type child)
            : base($"子组件'{child.Name}'只能放在父组件'{paremt.Name}'中")
        {
        }
    }

    internal class BootChildNotInParentComponentException<TParent,TChild> : BootChildNotInParentComponentException
    {
        public BootChildNotInParentComponentException()
            : base(typeof(TParent),typeof(TChild))
        {
        }
    }
}
