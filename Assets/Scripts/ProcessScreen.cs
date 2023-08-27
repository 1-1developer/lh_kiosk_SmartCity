using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ProcessScreen : MenuScreen
{
    const string PS_BUTTON = "PS_Button";
    const string PS_POPUP_BUTTON = "PS_Popup_Button";
    const string GROUP_PART = "Group_Part";
    const string SCRIM_TOUCH = "Scrim_Touch";
    const string PS_POPUP = "PS_Popup";
    const string PS_POPUP_WINDOW = "PS_Popup_Window";
    const string PS_BUTTON_X = "PS_Button_X";

    public Sprite[] PS_PopContents;

    List<Button> m_PS_Buttons = new List<Button>();
    List<Button> m_PS_Popup_Buttons = new List<Button>();
    List<VisualElement> m_Group_Parts = new List<VisualElement>();

    VisualElement m_PS_Popup;
    VisualElement m_PS_Popup_Window;

    Button m_Scrim_Touch;
    Button m_PS_Button_X;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        for (int i = 0; i < 7; i++)
        {
            m_PS_Buttons.Add(m_Root.Q<Button>(PS_BUTTON + $"{i}"));
        }

        for (int i = 0; i < 14; i++)
        {
            m_PS_Popup_Buttons.Add(m_Root.Q<Button>(PS_POPUP_BUTTON + $"{i}"));
        }

        for (int i = 0; i < 6; i++)
        {
            m_Group_Parts.Add(m_Root.Q<VisualElement>(GROUP_PART + $"{i}"));
        }

        m_PS_Popup = m_Root.Q<VisualElement>(PS_POPUP);
        m_PS_Popup_Window = m_Root.Q<VisualElement>(PS_POPUP_WINDOW);
        m_Scrim_Touch = m_Root.Q<Button>(SCRIM_TOUCH);
        m_PS_Button_X = m_Root.Q<Button>(PS_BUTTON_X);
        

    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        m_PS_Buttons[0].RegisterCallback<ClickEvent>(OnBackBt);

        m_PS_Buttons[1].RegisterCallback<ClickEvent>(evt => OnPopupSelection(0));
        m_PS_Buttons[2].RegisterCallback<ClickEvent>(evt => OnPopupSelection(1));
        m_PS_Buttons[3].RegisterCallback<ClickEvent>(evt => OnPopupSelection(2));
        m_PS_Buttons[4].RegisterCallback<ClickEvent>(evt => OnPopupSelection(3));
        m_PS_Buttons[5].RegisterCallback<ClickEvent>(evt => OnPopupSelection(4));
        m_PS_Buttons[6].RegisterCallback<ClickEvent>(evt => OnPopupSelection(5));

        m_Scrim_Touch.RegisterCallback<ClickEvent>(OffPopupSelection);

        m_PS_Popup_Buttons[0].RegisterCallback<ClickEvent>(evt => OnPopupWindow(0));
        m_PS_Popup_Buttons[1].RegisterCallback<ClickEvent>(evt => OnPopupWindow(1));
        m_PS_Popup_Buttons[2].RegisterCallback<ClickEvent>(evt => OnPopupWindow(2));
        m_PS_Popup_Buttons[3].RegisterCallback<ClickEvent>(evt => OnPopupWindow(3));
        m_PS_Popup_Buttons[4].RegisterCallback<ClickEvent>(evt => OnPopupWindow(4));
        m_PS_Popup_Buttons[5].RegisterCallback<ClickEvent>(evt => OnPopupWindow(5));
        m_PS_Popup_Buttons[6].RegisterCallback<ClickEvent>(evt => OnPopupWindow(6));
        m_PS_Popup_Buttons[7].RegisterCallback<ClickEvent>(evt => OnPopupWindow(7));
        m_PS_Popup_Buttons[8].RegisterCallback<ClickEvent>(evt => OnPopupWindow(8));
        m_PS_Popup_Buttons[9].RegisterCallback<ClickEvent>(evt => OnPopupWindow(9));
        m_PS_Popup_Buttons[10].RegisterCallback<ClickEvent>(evt => OnPopupWindow(10));
        m_PS_Popup_Buttons[11].RegisterCallback<ClickEvent>(evt => OnPopupWindow(11));
        m_PS_Popup_Buttons[12].RegisterCallback<ClickEvent>(evt => OnPopupWindow(12));
        m_PS_Popup_Buttons[13].RegisterCallback<ClickEvent>(evt => OnPopupWindow(13));

        m_PS_Button_X.RegisterCallback<ClickEvent>(OffPopupWindow);

    }
    private void OnBackBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowMainScreen();
        //Debug.Log("asahd");
    }

    private void OnPopupSelection(int v)
    {
        AudioManager.PlayDefaultButtonSound();
        m_Group_Parts[v].style.display = DisplayStyle.Flex;
        m_Scrim_Touch.style.display = DisplayStyle.Flex;
    }

    private void OffPopupSelection(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_Scrim_Touch.style.display = DisplayStyle.None;

        for (int i = 0; i < 6; i++)
        {
            if (m_Group_Parts[i].style.display == DisplayStyle.Flex)
            {
                m_Group_Parts[i].style.display = DisplayStyle.None;
            }
        }
    }

    private void OnPopupWindow(int v)
    {
        AudioManager.PlayDefaultButtonSound();
        m_PS_Popup_Window.style.backgroundImage = PS_PopContents[v].texture;
        m_PS_Popup.style.display = DisplayStyle.Flex;
    }

    private void OffPopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_PS_Popup.style.display = DisplayStyle.None;
    }
}
