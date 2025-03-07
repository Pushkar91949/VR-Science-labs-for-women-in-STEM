using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandVisibilityController : MonoBehaviour
{
    private Renderer[] renderers; // Store all renderers of the hand

    private void Start()
    {
        // Get all Renderer components in the hand and its children
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void SetVisibility(bool isVisible)
    {
        // Enable or disable all renderers
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = isVisible;
        }
    }
}
