using System;
using System.Collections.Generic;
using Ludiq;

namespace Lasm.BoltExtensions.IO
{
    /// <summary>
    /// An AOTDictuonary replacement that can be serialized and saved.
    /// </summary>
    [Serializable][Inspectable]
    public class ObjectList : List<object> { }
}

