using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystemGUIPositioner : MonoBehaviour
{

    public RectTransform CanvasRect;
    public Image DialoguePanel;

    private Vector2 OriginalUIPosition;

    void Awake()
    {
        OriginalUIPosition = DialoguePanel.rectTransform.anchoredPosition;
    }

    public void SetConversantGUI(Vector2 ScreenPos)
    {
        Vector2 RectPos = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, ScreenPos, null, out RectPos);
        DialoguePanel.rectTransform.anchoredPosition = RectPos;
    }

    public void ResetGUI()
    {
        DialoguePanel.rectTransform.anchoredPosition = OriginalUIPosition;
    }
}
