using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMAnimation
    {
        public static partial class Data
        {
            public struct Create
            {
                public Animator animator;

                public Create(Animator animator)
                {
                    this.animator = animator;
                }
            }
        }
    }
}