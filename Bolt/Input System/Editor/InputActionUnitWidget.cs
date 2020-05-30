#if ENABLE_INPUT_SYSTEM
using Bolt;
using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(OnInputActionUnit))]
    public class InputActionUnitWidget : UnitWidget<OnInputActionUnit>
    {
        public InputActionUnitWidget(FlowCanvas canvas, OnInputActionUnit unit) : base(canvas, unit)
        {
        }

        protected override NodeColorMix baseColor => NodeColor.Green;

        protected override bool showHeaderAddon => true;

        protected override void DrawHeaderAddon()
        {
            base.DrawHeaderAddon();
            if (unit.asset != null)
            {
                var actionRect = new Rect(position.x + 43, position.y + 79, position.width - 48, 18);
                var maps = unit.asset.actionMaps;
                var currentAction = unit.action;
                var actionText = "( None Selected )";

                if (unit.action != null && unit.map != null) { actionText = unit.map.name + " : " + currentAction.name; }

                if (GUI.Button(actionRect, actionText))
                {
                    var menu = new GenericMenu();

                    for (int mapIndex = 0; mapIndex < maps.Count; mapIndex++)
                    {
                        menu.AddSeparator(string.Empty);
                        menu.AddDisabledItem(new GUIContent(maps[mapIndex].name));
                        menu.AddSeparator(string.Empty);
                        for (int actionIndex = 0; actionIndex < maps[mapIndex].actions.Count; actionIndex++)
                        {
                            var i = mapIndex; 
                            var j = actionIndex; 
                            menu.AddItem(new GUIContent(maps[mapIndex].actions[actionIndex].name), false, () =>
                            {
                                unit.map = maps[i];
                                unit.action = maps[i].actions[j];
                                unit.Define();
                            });
                        }
                    }

                    menu.ShowAsContext();
                }
            }
        }

        protected override float GetHeaderAddonHeight(float width)
        {
            return base.GetHeaderAddonHeight(width) + (unit.asset == null ? 0 : 18);
        }
    }
}
#endif