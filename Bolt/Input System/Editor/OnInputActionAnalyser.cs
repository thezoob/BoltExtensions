using Bolt;
using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Lasm.BoltExtensions
{
    [Analyser(typeof(OnInputActionUnit))]
    public class OnInputActionAnalyser : UnitAnalyser<OnInputActionUnit>
    {
        public OnInputActionAnalyser(GraphReference reference, OnInputActionUnit target) : base(reference, target)
        {
        }

        protected override IEnumerable<Warning> Warnings()
        {
            var warnings = base.Warnings();
#if !ENABLE_INPUT_SYSTEM
            var warningsList = warnings.ToListPooled();
            warningsList.Add(new Warning(WarningLevel.Error, "The Input System is not currently activated. Install the Input System module in the package manager to use this unit."));
            warnings = warningsList.ConvertTo<IEnumerable<Warning>>();
#endif
            return warnings;
        }
    }
}