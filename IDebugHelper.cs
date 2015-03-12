using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RSG
{
    /// <summary>
    /// A renderable shape created by the debug helper.
    /// </summary>
    public interface IDebugHelperShape
    {
        /// <summary>
        /// Set the scale of the debug shape.
        /// </summary>
        IDebugHelperShape Scale(float scale);

        /// <summary>
        /// Set the color of the debug shape.
        /// </summary>
        IDebugHelperShape Color(Color color);

        /// <summary>
        /// Show the debug shape.
        /// </summary>
        IDebugHelperShape Show();

        /// <summary>
        /// Hide the debug shape.
        /// </summary>
        IDebugHelperShape Hide();

        /// <summary>
        /// Destroy the debug shape.
        /// </summary>
        void Destroy();

        /// <summary>
        /// Destroy the debug shape after specified time interval.
        /// </summary>
        IDebugHelperShape TimeOut(float seconds);
    }

    /// <summary>
    /// Interface for debug rendering etc.
    /// </summary>
    public interface IDebugHelper
    {
        /// <summary>
        /// Create a debug line.
        /// </summary>
        IDebugHelperShape Line(Vector3 p1, Vector3 p2);

        /// <summary>
        /// Create a debug cube.
        /// </summary>
        IDebugHelperShape Cube(Vector3 pos);

        /// <summary>
        /// Create a debug sphere.
        /// </summary>
        IDebugHelperShape Sphere(Vector3 pos);

        /// <summary>
        /// Create a debug ray.
        /// </summary>
        IDebugHelperShape Ray(Ray ray, float distance);

        /// <summary>
        /// Create a debug point.
        /// </summary>
        IDebugHelperShape Point(Vector3 pos);

        /// <summary>
        /// Create a debug matrix.
        /// </summary>
        IDebugHelperShape Matrix(Matrix4x4 matrix);

        /// <summary>
        /// Create a debug text.
        /// </summary>
        IDebugHelperShape Text(Vector3 pos, string text);

        /// <summary>
        /// Create a debug text.
        /// </summary>
        IDebugHelperShape Text(Vector2 pos, string text);
    }
}
