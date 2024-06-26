using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ProcessScreen : MenuScreen
{
    
    const string PS_BUTTON = "PS_Button";
    const string PS_BUTTON_BACK = "PS_Button_Back";
    const string PS_ONBUTTON = "PS_OnButton";
    const string PS_POPUP_BUTTON = "PS_Popup_Button";
    const string GROUP_PART = "Group_Part";
    const string SCRIM_TOUCH = "Scrim_Touch";
    const string PS_POPUP = "PS_Popup";
    const string PS_POPUP_WINDOW = "PS_Popup_Window";
    const string PS_POPUP_WINDOW2 = "PS_Popup_Window2";
    const string PS_BUTTON_X = "PS_Button_X";
    const string PS_BUTTON_X2 = "PS_Button_X2";


    public Sprite[] PS_PopContents;

    List<Button> m_PS_Buttons = new List<Button>();
    List<Button> m_PS_OnButtons = new List<Button>();
    List<Button> m_PS_Popup_Buttons = new List<Button>();
    List<VisualElement> m_Group_Parts = new List<VisualElement>();

    
    VisualElement m_PS_Popup;
    VisualElement m_PS_Popup_Window;
    VisualElement m_PS_Popup_Window2;

    Button m_PS_Button_X;
    Button m_PS_Button_X2;
    Button m_PS_Button_Back;


    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        for (int i = 0; i < 7; i++)
        {
            m_PS_Buttons.Add(m_Root.Q<Button>(PS_BUTTON + $"{i}"));
        }
        for (int i = 1; i < 7; i++)
        {
            m_PS_OnButtons.Add(m_Root.Q<Button>(PS_ONBUTTON + $"{i}"));
        }
        for (int i = 0; i < 6; i++)
        {
            m_Group_Parts.Add(m_Root.Q<VisualElement>(GROUP_PART + $"{i}"));
        }
        for (int i = 0; i < 14; i++)
        {
            m_PS_Popup_Buttons.Add(m_Root.Q<Button>(PS_POPUP_BUTTON + $"{i}"));
        }
                      
        m_PS_Popup = m_Root.Q<VisualElement>(PS_POPUP);
        m_PS_Popup_Window = m_Root.Q<VisualElement>(PS_POPUP_WINDOW);
        m_PS_Popup_Window2 = m_Root.Q<VisualElement>(PS_POPUP_WINDOW2);
        m_PS_Button_X = m_Root.Q<Button>(PS_BUTTON_X);
        m_PS_Button_X2 = m_Root.Q<Button>(PS_BUTTON_X2);
        m_PS_Button_Back = m_Root.Q<Button>(PS_BUTTON_BACK);
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

        m_PS_Button_Back.RegisterCallback<ClickEvent>(OffPopupSelection);

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
        m_PS_Button_X2.RegisterCallback<ClickEvent>(OffPopupWindow);

    }
    private void OnBackBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_MainMenuUIManager.ShowMainScreen();
    }

    private void OnPopupSelection(int v)
    {
        AudioManager.PlayDefaultButtonSound();
        m_Group_Parts[v].style.display = DisplayStyle.Flex;
        //m_Group_Parts[v].AddToClassList("group--fadein");
        //m_PS_Buttons[v + 1].AddToClassList("animButton--big");
        m_PS_Buttons[v + 1].RemoveFromClassList("animButton--on");
        m_PS_OnButtons[v].style.display = DisplayStyle.Flex;
        m_PS_Button_Back.style.display = DisplayStyle.Flex;

        for (int i = 0; i < 6; i++)
        {
            if (i == v)
            {
                continue;
            }
            else
            {
                m_PS_Buttons[i + 1].AddToClassList("animButton--on");
                if (m_Group_Parts[i].style.display == DisplayStyle.Flex)
                {
                    //m_PS_Buttons[i + 1].RemoveFromClassList("animButton--big");
                    
                    m_Group_Parts[i].style.display = DisplayStyle.None;
                    //m_Group_Parts[i].RemoveFromClassList("group--fadein");
                    m_PS_OnButtons[i].style.display = DisplayStyle.None;
                }
            }
        }

    }

    private void OffPopupSelection(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_PS_Button_Back.style.display = DisplayStyle.None;

        for (int i = 0; i < 6; i++)
        {
            if (m_Group_Parts[i].style.display == DisplayStyle.Flex)
            {
                m_Group_Parts[i].style.display = DisplayStyle.None;
            }
            m_PS_OnButtons[i].style.display = DisplayStyle.None;
        }
        for (int i = 1; i < 7; i++)
        {
            m_PS_Buttons[i].RemoveFromClassList("animButton--on");
            //m_PS_Buttons[i].RemoveFromClassList("animButton--big");
        }
    }

    private void OnPopupWindow(int v)
    {
        AudioManager.PlayDefaultButtonSound();

        m_PS_Popup.style.display = DisplayStyle.Flex;

        if (v == 12)
        {
            m_PS_Popup_Window2.style.display = DisplayStyle.Flex;
            m_PS_Popup_Window.style.display = DisplayStyle.None;
        }
        else
        {
            if (m_PS_Popup_Window2.style.display == DisplayStyle.Flex)
            {
                m_PS_Popup_Window2.style.display = DisplayStyle.None;
                m_PS_Popup_Window.style.display = DisplayStyle.Flex;
            }
            m_PS_Popup_Window.style.backgroundImage = PS_PopContents[v].texture;
        }

        //애니메이션
        m_PS_Popup.AddToClassList("popup--fadein");
    }

    private void OffPopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound(); 

        m_PS_Popup.style.display = DisplayStyle.None;

        //애니메이션
        m_PS_Popup.RemoveFromClassList("popup--fadein");


    }

    public void InitProcessScreen()
    {
        m_PS_Button_Back.style.display = DisplayStyle.None;

        for (int i = 0; i < 6; i++)
        {
            m_Group_Parts[i].style.display = DisplayStyle.None;         
            m_PS_OnButtons[i].style.display = DisplayStyle.None;
            m_PS_Buttons[i + 1].RemoveFromClassList("animButton--on");
        }

        m_PS_Popup.style.display = DisplayStyle.None;
        m_PS_Popup.RemoveFromClassList("popup--fadein");

    }
}
