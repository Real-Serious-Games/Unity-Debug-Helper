using RSG.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RSG
{
    /// <summary>
    /// Base-class for debug shapes.
    /// </summary>
    public abstract class AbstractDebugShape : IDebugHelperShape
    {
        protected AbstractDebugShape(UnityDebugHelper debugHelper)
        {
            Argument.NotNull(() => debugHelper);

            this.curState = State.NotStarted;
            this.debugHelper = debugHelper;
        }

        protected UnityDebugHelper debugHelper { get; private set; }

        /// <summary>
        /// Scale of the shape.
        /// </summary>
        protected float scale { get; private set; }

        /// <summary>
        /// Color of the shape.
        /// </summary>
        protected Color color { get; private set; }

        /// <summary>
        /// The time of the shape.
        /// </summary>
        protected float time { get; private set; }

        /// <summary>
        /// Amount of time the debug shape should last for.
        /// </summary>
        protected float timeOut { get; private set; }

        /// <summary>
        /// State of the debug shape.
        /// </summary>
        protected enum State
        {
            NotStarted,
            Shown,
            Hidden,
            Destroyed
        }

        /// <summary>
        /// State of the debug shape.
        /// </summary>
        protected State curState { get; private set; }

        /// <summary>
        /// Set the scale of the debug shape.
        /// </summary>
        public virtual IDebugHelperShape Scale(float scale)
        {
            this.scale = scale;
            return this;
        }

        /// <summary>
        /// Set the color of the debug shape.
        /// </summary>
        public virtual IDebugHelperShape Color(Color color)
        {
            this.color = color;
            return this;
        }

        /// <summary>
        /// Show the debug shape.
        /// </summary>
        public virtual IDebugHelperShape Show()
        {
            curState = State.Shown;
            time = 0;
            return this;
        }

        /// <summary>
        /// Hide the debug shape.
        /// </summary>
        public virtual IDebugHelperShape Hide()
        {
            curState = State.Hidden;
            return this;
        }

        /// <summary>
        /// Destroy the debug shape.
        /// </summary>
        public virtual void Destroy()
        {
            curState = State.Destroyed;
        }

        /// <summary>
        /// Destroy the debug shape after specified time interval.
        /// </summary>
        public virtual IDebugHelperShape TimeOut(float seconds)
        {
            timeOut = seconds;
            return this;
        }

        /// <summary>
        /// Returns true if the debug shape is still alive.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (curState == State.Destroyed)
                {
                    return false;
                }

                if (timeOut > 0 && time > timeOut)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Update the shape.
        /// </summary>
        public void Update(float timeDelta)
        {
            if (curState != State.Shown)
            {
                return;
            }

            time += timeDelta;

            UpdateOverride(timeDelta);
        }

        /// <summary>
        /// Override for derived classes.
        /// </summary>
        protected virtual void UpdateOverride(float timeDelta)
        {
        }

        /// <summary>
        /// Render the shape.
        /// </summary>
        public void Render()
        {
            if (curState != State.Shown)
            {
                return;
            }

            RenderOverride();
        }

        /// <summary>
        /// Override for derived classes.
        /// </summary>
        protected virtual void RenderOverride()
        {
        }

        /// <summary>
        /// Callback for when the debug shape has been wound up.
        /// </summary>
        public virtual void NotifyCompleted()
        {
        }
    }
}
