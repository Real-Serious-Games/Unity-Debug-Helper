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
    public class TextDebugShape : AbstractDebugShape
    {
        private Vector2 pos;
        private string text;
        private GameObject textObject;
        private GUIText guiText;

        public TextDebugShape(Vector2 pos, string text, UnityDebugHelper debugHelper) :
            base(debugHelper)
        {
            this.pos = pos;
            this.text = text;
        }

        public override IDebugHelperShape Color(Color color)
        {
            if (guiText != null)
            {
                guiText.color = color;
            }
            return base.Color(color);
        }

        public override IDebugHelperShape Scale(float scale)
        {
            if (textObject != null)
            {
                textObject.transform.localScale = new Vector3(scale, scale, scale);
            }
            return base.Scale(scale);
        }

        public override IDebugHelperShape Show()
        {
            if (textObject == null)
            {
                textObject = new GameObject();
                textObject.name = "_debugHelperText";
                textObject.transform.position = new Vector3(0f, 1f, 0f);
                textObject.transform.localScale = new Vector3(scale, scale, scale);
                guiText = textObject.AddComponent<GUIText>();
                guiText.text = text;
                guiText.pixelOffset = new Vector3(pos.x, -pos.y);
                guiText.color = color;
            }

            textObject.SetActive(true);

            return base.Show();
        }

        public override IDebugHelperShape Hide()
        {
            if (textObject != null)
            {
                textObject.SetActive(false);
            }

            return base.Hide();
        }

        public override void Destroy()
        {
            if (textObject != null)
            {
                GameObject.Destroy(textObject);
                textObject = null;
                guiText = null;
            }
                
            base.Destroy();
        }

        public override void NotifyCompleted()
        {
            if (textObject != null)
            {
                GameObject.Destroy(textObject);
                textObject = null;
            }

            base.NotifyCompleted();
        }
    }
}
