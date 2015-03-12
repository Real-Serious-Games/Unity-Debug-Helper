using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RSG
{
    /// <summary>
    /// Debug shape that renders a line.
    /// </summary>
    public class LineDebugShape : AbstractDebugShape
    {
        private Vector3 p1;
        private Vector3 p2;

        public LineDebugShape(Vector3 p1, Vector3 p2, UnityDebugHelper debugHelper) :
            base(debugHelper)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        /// <summary>
        /// Render the shape.
        /// </summary>
        protected override void RenderOverride()
        {
            var material = debugHelper.GetDebugMaterial();
            material.SetPass(0);

            GL.Begin(GL.LINES);
            GL.Color(color);

            GL.Vertex(p1);
            GL.Vertex(p2);

            GL.End();
        }
    }
}
