using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// this scripts controls and sets UI dialogue panel based on character screen position
/// </summary>

public class DialogueSystemGUIPositioner : MonoBehaviour
{

    public RectTransform CanvasRect;
    public RectTransform DialoguePanelTransform;


    public float PaddingX;
    public float PaddingY;

    private Vector2 OriginalUIPosition;
    private Vector2 Offset;
    private Vector2 lastScreenPos;
    

    void Awake()
    {
        OriginalUIPosition = DialoguePanelTransform.anchoredPosition;
        Offset = new Vector2(PaddingX, PaddingY);
        lastScreenPos = new Vector2();
        OriginalUIPosition = new Vector2();
    }


    public void SetConversantGUI(Vector2 ScreenPos)
    {
        lastScreenPos = ScreenPos;

        Vector2 RectPos = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, ScreenPos, null, out RectPos);




        if (RectPos.x + DialoguePanelTransform.rect.width / 2 + Offset.x > CanvasRect.rect.xMax)
            RectPos.x = CanvasRect.rect.xMax - DialoguePanelTransform.rect.width / 2 - Offset.x;
        else if (RectPos.x - DialoguePanelTransform.rect.width / 2 - Offset.x < CanvasRect.rect.xMin)
            RectPos.x = CanvasRect.rect.xMin + DialoguePanelTransform.rect.width / 2 + Offset.x;
        if (RectPos.y + DialoguePanelTransform.rect.height + Offset.y > CanvasRect.rect.yMax)
            RectPos.y = CanvasRect.rect.yMax - DialoguePanelTransform.rect.height - Offset.y;
        else if (RectPos.y < CanvasRect.rect.yMin)
            RectPos.y = CanvasRect.rect.yMin + Offset.y;
        DialoguePanelTransform.anchoredPosition = RectPos;
    }

    public void ResetGUI()
    {
        DialoguePanelTransform.anchoredPosition = OriginalUIPosition;
    }
    public void ForceGUIPosition()
    {
        SetConversantGUI(lastScreenPos);
    }
}
