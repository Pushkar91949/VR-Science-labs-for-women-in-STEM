using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PopupController : MonoBehaviour
{
    public GameObject popupCanvas; // Assign the Canvas GameObject here
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false); // Ensure the Canvas is hidden initially
        }

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed!"); // Check if grab is detected
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(true); // Show the Canvas when grabbed
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Object released!"); // Check if release is detected
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false); // Hide the Canvas when released
        }
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
