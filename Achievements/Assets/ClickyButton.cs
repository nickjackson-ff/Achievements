using UnityEngine;

public class ClickyButton : MonoBehaviour
{
    public float Scale = 1.2f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void ScaleUp()
    {
        transform.localScale *= Scale;
    }

    public void ScaleDown()
    {
        transform.localScale = originalScale;
    }

    void OnMouseDown()
    {
        ScaleUp();
    }

    void OnMouseUp()
    {
        ScaleDown();
    }
}
