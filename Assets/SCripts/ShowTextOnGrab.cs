using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class ShowTextOnGrab : MonoBehaviour
{
    public GameObject textObject; // Assign TMP Text GameObject in Inspector
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        textObject.SetActive(false); // Hide text at start

        // Subscribe to grab and release events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnDrop);
    }

    private void OnGrab(SelectEnterEventArgs args) // Correct parameter type
    {
        textObject.SetActive(true); // Show text on grab
    }

    private void OnDrop(SelectExitEventArgs args) // Correct parameter type
    {
        textObject.SetActive(false); // Hide text on release
    }
}
