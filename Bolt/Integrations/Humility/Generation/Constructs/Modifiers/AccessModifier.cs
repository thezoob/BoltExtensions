using System;

namespace Lasm.BoltExtensions.Humility
{ 
    /// <summary>
    /// The scope of a C# construct. Excludes root constructs, such as a class declaration. Use RootAccessModifier for those.
    /// </summary>
    public enum AccessModifier
    {
        Public,
        Private,
        Protected,
        Internal,
        ProtectedInternal,
        PrivateProtected
    }
}