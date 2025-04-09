using UnityEngine;

public class Parallax : MonoBehaviour
{
   private MeshRenderer meshRenderer;
   public float animationSpeed = 0.1f;

    private void Awake()
    {
        meshRenderer= GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset +=new Vector2(animationSpeed*Time.deltaTime, 0);
    }
}
// using UnityEngine;

// public class Parallax : MonoBehaviour
// {
//     private SpriteRenderer spriteRenderer; // Use SpriteRenderer for 2D sprites
//     public float animationSpeed = 0.1f;

//     private void Awake()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
//     }

//     private void Update()
//     {
//         // Apply the parallax effect by modifying the texture offset of the material
//         spriteRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
//     }
// }
