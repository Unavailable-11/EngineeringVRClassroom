//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class toggle_CompareScreen_left : MonoBehaviour
    {
        public MeshRenderer meshRenderer;
        public Material boomerang_info, screen_border;

        public void OnButtonDown(Hand fromHand)
        {

            Material[] materials = new Material[meshRenderer.sharedMaterials.Length];

            materials[0] = boomerang_info;
            materials[1] = screen_border;

            meshRenderer.sharedMaterials = materials;

        }

        public void OnButtonUp(Hand fromHand)
        {

        }


    }
}