using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class CNCMachine : MonoBehaviour
    {
        public GameObject MetalBoomerang;
        public GameObject MetalBox;
        public GameObject MetalMachine;
        public ParticleSystem SparksParticle;
        public MetalTouching metal;

        private bool isProcessing = false;
        private bool isMetalBoxInMachine = false;

        private void Start()
        {
            Debug.Log("CNCMachine Start");
            if (MetalBoomerang != null)
            {
                MetalBoomerang.SetActive(false);
            }
            if (SparksParticle != null)
            {
                SparksParticle.Stop();
                SparksParticle.gameObject.SetActive(false);
            }
        }

     

        public void OnButtonDown(Hand fromHand)
        {
            Debug.Log("Button pressed - checking conditions...");
            ColorSelf(Color.cyan);

            if (MetalBox != null && metal.isTouching && !isProcessing)
            {
                Debug.Log("Conditions met: starting ProcessMetalBox coroutine");
                StartCoroutine(ProcessMetalBox());
            }
            else
            {
                Debug.Log("Conditions not met: MetalBox present? " + (MetalBox != null) +
                          ", isMetalBoxInMachine? " + isMetalBoxInMachine + ", isProcessing? " + isProcessing);
            }
        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
        }

        private IEnumerator ProcessMetalBox()
        {
            Debug.Log("Processing MetalBox started");
            isProcessing = true;

            if (SparksParticle != null)
            {
                SparksParticle.gameObject.SetActive(true);
                SparksParticle.Play();
                Debug.Log("Sparks particle started");
            }
            else
            {
                Debug.LogWarning("SparksParticle reference is null");
            }

            yield return new WaitForSeconds(5f);

            if (SparksParticle != null)
            {
                SparksParticle.Stop();
                SparksParticle.gameObject.SetActive(false);
                Debug.Log("Sparks particle stopped");
            }

            if (MetalBox != null)
            {
                MetalBox.SetActive(false);
                Debug.Log("MetalBox hidden");
            }
            if (MetalBoomerang != null)
            {
                MetalBoomerang.SetActive(true);
                Debug.Log("MetalBoomerang shown");
            }

            isProcessing = false;
            Debug.Log("Processing MetalBox ended");
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
