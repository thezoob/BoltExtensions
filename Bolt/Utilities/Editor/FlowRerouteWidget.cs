using Bolt;
using Ludiq;
using UnityEngine;
using UnityEditor;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(FlowReroute))]
    public sealed class FlowRerouteWidget : UnitWidget<FlowReroute>
    {
        private static FlowReroute addedUnit = null;
        private static bool keyPressed;

        public FlowRerouteWidget(FlowCanvas canvas, FlowReroute unit) : base(canvas, unit)
        {
        }

        public override void DrawForeground()
        {
            Ludiq.GraphGUI.Node(new Rect(position.x, position.y, _position.width, _position.height), NodeShape.Square, NodeColor.Gray, isSelected);
        }

        protected override bool showIcons => true;
        
        public override bool foregroundRequiresInput => true;
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

        public override void Update()
        {
            if (addedUnit == null && keyPressed && canvas.connectionSource != null && canvas.connectionSource == unit.output)
            {
                addedUnit = new FlowReroute();
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
    }
} 