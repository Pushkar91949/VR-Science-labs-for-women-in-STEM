using UnityEngine;
using TMPro; // Required for TextMeshPro
using System.Collections;

public class FireTrigger : MonoBehaviour
{
    public GameObject fire;  // Assign Fire GameObject in Inspector
    public Renderer cylinderRenderer; // Assign Cylinder's Renderer
    public Color newColor = Color.red; // Set desired color in Inspector
    public TMP_Text fireMessage; // Assign TMP UI Text in Inspector
    public GameObject expl;
    public GameObject Cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube")) // Make sure the Cube has the "Cube" tag
        {
            StartCoroutine(ActivateFire());
        }
    }

    IEnumerator ActivateFire()
    {
        Cube.SetActive(false);
        fire.SetActive(true); // Activate fire
        fireMessage.text = "EWWWWW! Smells like rotten eggs. Mmm, These fumes must be Hydrogen Sulphide."; 
        cylinderRenderer.material.color = newColor; // Change cylinder color
        yield return new WaitForSeconds(10f);
        fire.SetActive(false); 
        fireMessage.text = ""; 
        expl.SetActive(true);
        yield return new WaitForSeconds(10f);
        expl.SetActive(false);
    }
}
