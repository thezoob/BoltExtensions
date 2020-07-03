using Bolt;
using Ludiq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(ValueReroute))]
    public sealed class ValueRerouteWidget : UnitWidget<ValueReroute>
    {
        private static ValueReroute addedUnit = null;
        private static bool keyPressed;

        public ValueRerouteWidget(FlowCanvas canvas, ValueReroute unit) : base(canvas, unit)
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

            if (addedUnit == null && keyPressed && canvas.connectionSource != null && canvas.connectionSource == unit.output)
            {
                addedUnit = new ValueReroute();
                addedUnit.position = canvas.mousePosition - new Vector2(14, 14);
                ((FlowGraph)graph).units.Add(addedUnit);
                unit.output.ValidlyConnectTo(addedUnit.input);
                canvas.connectionSource = addedUnit.output;
            }

            if (addedUnit != null) canvas.connectionSource = addedUnit.output;

            if (!keyPressed)
            {
                addedUnit = null;
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

        public override void HandleCapture()
        {
            base.HandleCapture();
            keyPressed = e.keyCode == KeyCode.Space;
        }
    }
} 