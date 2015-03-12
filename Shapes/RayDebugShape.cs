using RSG.Utils;
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
    public class RayDebugShape : AbstractDebugShape
    {
        private Ray ray;
        private float distance;

        public RayDebugShape(Ray ray, float distance, UnityDebugHelper debugHelper) :
            base(debugHelper)
        {
            Argument.NotNull(() => ray);
            Argument.NotNull(() => distance);

            this.ray = ray;
            this.distance = distance;
        }

        /// <summary>
        /// Render the shape.
        /// </summary>
        protected override void RenderOverride()
        {
            var startPoint = ray.origin;
            ray.direction.Normalize();
            var endPoint = (ray.origin + (ray.direction * distance));

            var material = debugHelper.GetDebugMaterial();
            material.SetPass(0);

            GL.Begin(GL.LINES);
            GL.Color(color);

            GL.Vertex(startPoint);
            GL.Vertex(endPoint);

            GL.End();
        }
    }
}
