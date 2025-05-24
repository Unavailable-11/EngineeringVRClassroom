using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample

{
    public class Button : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()   
        {

        }
        int num = 0;
        public void OnButtonDown(Hand fromHand)

        {
            ColorSelf(Color.cyan);

            num++;

            Debug.Log("Button smashed " + num + " times!");


        }

        public void OnButtonUp(Hand fromHand)

        {

            ColorSelf(Color.white);

        }
        private void ColorSelf(Color newColor)

        {

            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();

            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)

            {

                renderers[rendererIndex].material.color = newColor;

            }

        }
    }
}
