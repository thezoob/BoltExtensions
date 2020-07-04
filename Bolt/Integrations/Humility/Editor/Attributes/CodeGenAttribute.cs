using System;

namespace Lasm.BoltExtensions.Humility
{
    public sealed class CodeGenAttribute : DecoratorAttribute
    {
        public CodeGenAttribute(Type type) : base(type)
        {
        }
    }
}