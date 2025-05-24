//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{
    public class plasticinfo : MonoBehaviour
    {
        // References to the text objects
        public GameObject metal;
        public GameObject wood;
        public GameObject plastic;
        public GameObject intro;

        // This method is called when the button is pressed down
        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            EnableTextWood(); // Enable the corresponding text based on the button's name
            // fromHand.TriggerHapticPulse(1000);
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
        private void Start()
        {
            metal.SetActive(false);
            wood.SetActive(false);
            plastic.SetActive(false);
            intro.SetActive(false);

        }
        private void EnableTextWood()
        {
            // Disable all texts first
            metal.SetActive(false);
            wood.SetActive(false);
            plastic.SetActive(true);
            intro.SetActive(false);


        }
    }
}
