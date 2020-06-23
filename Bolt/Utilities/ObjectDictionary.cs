using System;
using System.Collections.Generic;
using Ludiq;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// An AOTDictuonary replacement that can be serialized and saved.
    /// </summary>
    [Serializable][Inspectable]
    [IncludeInSettings(true)]
    [RenamedFrom("Lasm.BoltExtensions.IO.ObjectDictionary")]
    public sealed class ObjectDictionary : Dictionary<object, object> { }
}

