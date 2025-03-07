using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add listeners for grab and release events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Get the hand GameObject from the interactor
        GameObject hand = args.interactorObject.transform.gameObject;

        // Find the HandVisibilityController on the hand and hide it
        HandVisibilityController handVisibility = hand.GetComponent<HandVisibilityController>();
        if (handVisibility != null)
        {
            handVisibility.SetVisibility(false);
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Get the hand GameObject from the interactor
        GameObject hand = args.interactorObject.transform.gameObject;

        // Find the HandVisibilityController on the hand and show it
        HandVisibilityController handVisibility = hand.GetComponent<HandVisibilityController>();
        if (handVisibility != null)
        {
            handVisibility.SetVisibility(true);
        }
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
