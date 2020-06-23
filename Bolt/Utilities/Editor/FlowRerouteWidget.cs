using Bolt;
using Ludiq;
using UnityEngine;

namespace Lasm.BoltExtensions
{
    [Widget(typeof(FlowReroute))]
    public sealed class FlowRerouteWidget : UnitWidget<FlowReroute>
    {
        public FlowRerouteWidget(FlowCanvas canvas, FlowReroute unit) : base(canvas, unit)
        {
        }

        public override void DrawForeground()
        {
            Ludiq.GraphGUI.Node(new Rect(position.x, position.y, _position.width, _position.height), NodeShape.Square, NodeColor.Gray, isSelected);
        }
        
        protected override bool showIcons => true;

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