using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RSG
{
    /// <summary>
    /// Debug shape that renders a cube.
    /// </summary>
    public class CubeDebugShape : AbstractDebugShape
    {
        private Vector3 pos;
        private GameObject cubeObject;

        public CubeDebugShape(Vector3 pos, UnityDebugHelper debugHelper) :
            base(debugHelper)
        {
            this.pos = pos;
        }

        public override IDebugHelperShape Color(Color color)
        {
            if (cubeObject != null)
            {
                cubeObject.renderer.material.color = color;
            }
            return base.Color(color);
        }

        public override IDebugHelperShape Scale(float scale)
        {
            if (cubeObject != null)
            {
                cubeObject.transform.localScale = new Vector3(scale, scale, scale);
            }
            return base.Scale(scale);
        }

        public override IDebugHelperShape Show()
        {
            if (cubeObject == null)
            {
                cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeObject.name = "_debugHelperCube";
                cubeObject.renderer.material.color = color;
                cubeObject.transform.localScale = new Vector3(scale, scale, scale);
            }

            cubeObject.SetActive(true);

            return base.Show();
        }

        public override IDebugHelperShape Hide()
        {
            if (cubeObject != null)
            {
                cubeObject.SetActive(false);
            }

            return base.Hide();
        }

        public override void Destroy()
        {
            if (cubeObject != null)
            {
                GameObject.Destroy(cubeObject);
                cubeObject = null;
            }
                
            base.Destroy();
        }

        public override void NotifyCompleted()
        {
            if (cubeObject != null)
            {
                GameObject.Destroy(cubeObject);
                cubeObject = null;
            }

            base.NotifyCompleted();
        }
    }
}
