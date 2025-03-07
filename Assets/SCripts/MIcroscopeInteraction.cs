using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MicroscopeInteraction : MonoBehaviour
{
    public GameObject useMicroscopeButton;  // "Use Microscope" button
    public GameObject microscopeOptionsPanel; // Panel containing 4 buttons
    public Image displayImage; // UI Image to show selected content
    public Transform xrCamera; // XR Camera (Headset)

    public Sprite pondWaterSprite, skinSprite, bacteriaSprite, virusSprite; // Images for buttons

    [SerializeField] private float activationDistance = 2.0f; // Distance threshold
    private bool isButtonVisible = false; // Track UI state

    private void Update()
    {
        // Calculate distance between XR Camera and Microscope
        float distance = Vector3.Distance(xrCamera.position, transform.position);

        // Show "Use Microscope" button when near
        if (distance < activationDistance && !isButtonVisible)
        {
            useMicroscopeButton.SetActive(true);
            isButtonVisible = true;
        }
        else if (distance >= activationDistance && isButtonVisible)
        {
            useMicroscopeButton.SetActive(false);
            microscopeOptionsPanel.SetActive(false);
            displayImage.gameObject.SetActive(false); // Hide image if moving away
            isButtonVisible = false;
        }
    }

    // Called when "Use Microscope" button is clicked
    public void OpenMicroscopeOptions()
    {
        microscopeOptionsPanel.SetActive(true);
    }

    // Functions for each button to show an image for 5 seconds
    public void ShowPondWater() { StartCoroutine(DisplayImageForSeconds(pondWaterSprite)); }
    public void ShowSkin() { StartCoroutine(DisplayImageForSeconds(skinSprite)); }
    public void ShowBacteria() { StartCoroutine(DisplayImageForSeconds(bacteriaSprite)); }
    public void ShowVirus() { StartCoroutine(DisplayImageForSeconds(virusSprite)); }

    // Coroutine to show image for 5 seconds
    private IEnumerator DisplayImageForSeconds(Sprite selectedSprite)
    {
        displayImage.sprite = selectedSprite;
        displayImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        displayImage.gameObject.SetActive(false);
    }
}
