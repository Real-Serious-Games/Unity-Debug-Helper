using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RSG
{
    /// <summary>
    /// Interface for debug rendering etc.
    /// </summary>
    public class UnityDebugHelper : IDebugHelper
    {
        /// <summary>
        /// List of currently debug shapes.
        /// </summary>
        private List<AbstractDebugShape> debugShapes = new List<AbstractDebugShape>();

        /// <summary>
        /// Cached debug material used for rendering.
        /// </summary>
        private Material debugMaterial;

        /// <summary>
        /// Create a debug line.
        /// </summary>
        public IDebugHelperShape Line(Vector3 p1, Vector3 p2)
        {
            var line = new LineDebugShape(p1, p2, this);
            debugShapes.Add(line);
            return line;
        }

        /// <summary>
        /// Create a debug cube.
        /// </summary>
        public IDebugHelperShape Cube(Vector3 pos)
        {
            var cube = new CubeDebugShape(pos, this);
            debugShapes.Add(cube);
            return cube;
        }

        /// <summary>
        /// Create a debug sphere.
        /// </summary>
        public IDebugHelperShape Sphere(Vector3 pos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a debug ray.
        /// </summary>
        public IDebugHelperShape Ray(Ray ray, float distance)
        {
            var rayDebugShape = new RayDebugShape(ray, distance, this);
            debugShapes.Add(rayDebugShape);
            return rayDebugShape;
        }

        /// <summary>
        /// Create a debug point.
        /// </summary>
        public IDebugHelperShape Point(Vector3 pos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a debug matrix.
        /// </summary>
        public IDebugHelperShape Matrix(Matrix4x4 matrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a debug text.
        /// </summary>
        public IDebugHelperShape Text(Vector3 pos, string text)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a debug text.
        /// </summary>
        public IDebugHelperShape Text(Vector2 pos, string text)
        {
            var shape = new TextDebugShape(pos, text, this);
            debugShapes.Add(shape);
            return shape;
        }

        /// <summary>
        /// Update debug shapes.
        /// </summary>
        public void Update(float timeDelta)
        {
            var i = 0;
            while (i < debugShapes.Count)
            {
                var debugShape = debugShapes[i];
                debugShape.Update(timeDelta);

                if (!debugShape.IsAlive)
                {
                    debugShapes.RemoveAt(i);

                    debugShape.NotifyCompleted();
                }
                else
                {
                    ++i;
                }
            }
        }

        /// <summary>
        /// Render debug shapes.
        /// </summary>
        public void Render()
        {
            foreach (var debugShape in debugShapes)
            {
                debugShape.Render();
            }
        }

        /// <summary>
        /// Get a debug material for rendering.
        /// </summary>
        public Material GetDebugMaterial()
        {
            if (debugMaterial == null)
            {
                debugMaterial = new Material("Shader \"Lines/Colored Blended\" {" +
                    "SubShader { Pass { " +
                    "    Blend SrcAlpha OneMinusSrcAlpha " +
                    "    ZWrite Off Cull Off Fog { Mode Off } " +
                    "    BindChannels {" +
                    "      Bind \"vertex\", vertex Bind \"color\", color }" +
                    "} } }");
            }

            return debugMaterial;
        }
    }
}
