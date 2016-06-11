using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PixelCrushers;
using PixelCrushers.DialogueSystem;
using AC;
//TODO: field encapsulation
//TODO: manage gui position for extreme camera shots
//TODO: delocallizare GUIManager da dialogue manager e gettare i componenti della gui

public class GUIManager : MonoBehaviour
{
    public List<string> ConversantNames;
    public RectTransform CanvasRect;
    public Image DialoguePanel;

    private List<GameObject> Conversants;
    private GameObject ActiveConversant;
    private GameObject PreviousConversant;
    private GameObject Rashid;
    private Vector2 OriginalUIPosition;
    private string CurrentConversantName;

    void Awake()
    {
        Conversants = new List<GameObject>();
        CurrentConversantName = "Not Set";
        OriginalUIPosition = DialoguePanel.rectTransform.anchoredPosition;
        ActiveConversant = new GameObject();
        PreviousConversant = new GameObject();
    }

    void Start()
    {
        PopulateConversant();
    }


    public void LateUpdate()
    {

        if (DialogueManager.IsConversationActive)
        {
            //The character speaking
            CurrentConversantName = DialogueManager.CurrentConversationState.subtitle.speakerInfo.Name;
            //Find the speaking character in the scene
            try
            {
                ActiveConversant = Conversants.Where(hC => hC.gameObject.tag == CurrentConversantName).FirstOrDefault();
            }
            catch (System.Exception)
            {

                throw new UnityException("Fix This pls!!!");
            }
            

            
            if(ActiveConversant != null && ActiveConversant != PreviousConversant)
            {
                //get custom offset for speaking character
                GUIOffsetBehaviour HeadOffset = ActiveConversant.GetComponent<GUIOffsetBehaviour>();
                Transform HeadPosition = HeadOffset.HeadPosition;
                
                Vector3 ScreenPos = KickStarter.mainCamera.attachedCamera._camera.WorldToScreenPoint(HeadPosition.position);
                Vector2 RectPos = new Vector2();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, ScreenPos, null, out RectPos);

                //set gui position
                DialoguePanel.rectTransform.anchoredPosition = RectPos;
                PreviousConversant = ActiveConversant;
            }
            else if (ActiveConversant == null)
            {
                DialoguePanel.rectTransform.anchoredPosition = OriginalUIPosition;
                PreviousConversant = null;
            }
        }
    }

    public void PopulateConversant()
    {
        Conversants.Clear();
        //Rashid needs to be acquired manually for his tag that cannot be changed
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rashid = player.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
        Conversants.Add(Rashid);
        foreach (string name in ConversantNames)
        {
            Conversants.Add(GameObject.FindGameObjectWithTag(name));
        }
    }
}
