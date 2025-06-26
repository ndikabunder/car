using UnityEngine;

public class HoverColorChange : MonoBehaviour
{
    private Renderer objRenderer;
    public Color hoverColor = Color.yellow;
    private Color originalColor;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
    }

    void OnMouseEnter()
    {
        objRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        objRenderer.material.color = originalColor;
    }

}
