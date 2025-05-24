//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ControlScreenText : MonoBehaviour
    {
        public GameObject[] screenTexts; // Array to hold floating text GameObjects of any number

        private int currentIndex = 0; // Index of the currently active text

        void Start()
        {
            if (screenTexts == null || screenTexts.Length == 0)
            {
                Debug.LogError("Please assign at least one floating text GameObject to the ButtonEffect script.");
                enabled = false;
                return;
            }

            UpdateTextVisibility();
        }

        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            CycleToNextText(); // Cycle to the next text when button is pressed
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

        /// <summary>
        /// Cycle to the next floating text and update visibility.
        /// Stops cycling once it reaches the last text.
        /// </summary>
        private void CycleToNextText()
        {
            if (currentIndex >= screenTexts.Length - 1)
            {
                // Already at last text, do not cycle further
                return;
            }

            // Hide current text
            screenTexts[currentIndex].SetActive(false);

            // Move to the next index
            currentIndex++;

            // Show the new current text
            UpdateTextVisibility();
        }

        /// <summary>
        /// Update visibility of the floating texts based on the current index.
        /// </summary>
        private void UpdateTextVisibility()
        {
            for (int i = 0; i < screenTexts.Length; i++)
            {
                screenTexts[i].SetActive(i == currentIndex);
            }
        }
    }
}
