using UnityEngine;

public class SaveGameOnClick : MonoBehaviour
{
    public TextMesh ButtonLabel;

    private MeshRenderer myMeshRenderer;
    private Color originalBackgroundColor;
    private string originalButtonLabelText;

    private bool isDimmed;

    void Awake()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        originalBackgroundColor = myMeshRenderer.material.color;
        originalButtonLabelText = ButtonLabel.text;
    }

    void OnMouseDown()
    {
        if (isDimmed) return;

        AchievementsController.instance.SaveGame();

        SetSavedButtonLabelText();
        Invoke("SetOriginalButtonLabelText", 2f);
    }

    void SetSavedButtonLabelText()
    {
        isDimmed = true;
        myMeshRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 0.75f);
        ButtonLabel.text = "SAVED";
    }

    void SetOriginalButtonLabelText()
    {
        isDimmed = false;
        myMeshRenderer.material.color = originalBackgroundColor;
        ButtonLabel.text = originalButtonLabelText;
    }
}
