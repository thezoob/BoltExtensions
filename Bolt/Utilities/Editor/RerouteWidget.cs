using Bolt;
using Ludiq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(Reroute))]
    public class RerouteWidget : UnitWidget<Reroute>
    {
        public RerouteWidget(FlowCanvas canvas, Reroute unit) : base(canvas, unit)
        {
        }

        public override void DrawForeground()
        {
            Ludiq.GraphGUI.Node(new Rect(position.x, position.y, _position.width, _position.height), NodeShape.Square, NodeColor.Gray, isSelected);
        }

        private Type lastType;

        protected override bool showIcons => true;

        public override void Update()
        {
            base.Update();

            if (unit.input != null && unit.input.connection != null && unit.input.connection.sourceExists)
            {
                if (unit.portType != unit.input.connection.source.type)
                {
                    unit.portType = unit.input.connection.source.type;
                    lastType = null;
                }
            }
            else
            {
                unit.portType = typeof(object);
                if (lastType != typeof(object)) lastType = null;
            }


            if (lastType != unit.portType)
            {
                lastType = unit.portType;
                unit.Define();
            }
        }
        
        public override void CachePosition()
        {
            _position.x = unit.position.x;
            _position.y = unit.position.y;
            _position.width = 26;
            _position.height = 26;

            inputs[0].y = _position.y + 5;
            outputs[0].y = _position.y + 5;
        }
    }
} 