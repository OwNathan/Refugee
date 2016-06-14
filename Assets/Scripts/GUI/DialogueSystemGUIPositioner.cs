using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystemGUIPositioner : MonoBehaviour
{

    public RectTransform CanvasRect;
    public RectTransform DialoguePanelTransform;
    public Image DialoguePanel;
    public float PaddingX;
    public float PaddingY;

    private Vector2 OriginalUIPosition;
    private Vector2 Offset;
    

    void Awake()
    {
        OriginalUIPosition = DialoguePanel.rectTransform.anchoredPosition;
        Offset = new Vector2(PaddingX, PaddingY);
    }

    //void Start()
    //{
    //    Debug.Log( CanvasRect.rect.xMax);

    //}
    


    public void SetConversantGUI(Vector2 ScreenPos)
    {
        Vector2 RectPos = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, ScreenPos, null, out RectPos);

        Bounds DialoguePanelBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(DialoguePanelTransform);
        //Rect rect = CanvasRect.rect;
        //DialoguePanelTransform.anchoredPosition.x + DialoguePanelBounds.extents.x > CanvasRect.rect.max.x
        if (RectPos.x + DialoguePanelBounds.extents.x + Offset.x > CanvasRect.rect.xMax)
            RectPos.x = CanvasRect.rect.xMax - DialoguePanelBounds.extents.x - Offset.x;
        else if (RectPos.x - DialoguePanelBounds.extents.x - Offset.x < CanvasRect.rect.xMin)
            RectPos.x = CanvasRect.rect.xMin + DialoguePanelBounds.extents.x + Offset.x;
        DialoguePanel.rectTransform.anchoredPosition = RectPos;
    }

    public void ResetGUI()
    {
        DialoguePanel.rectTransform.anchoredPosition = OriginalUIPosition;
    }
}
