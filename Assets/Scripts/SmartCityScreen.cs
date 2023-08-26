using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SmartCityScreen : MenuScreen
{
    const string SCS_BUTTON = "SCS_Button";
    const string SCS_BUTTON_BACK = "SCS_Button_Back";
    const string SCS_GROUP_POPUP = "SCS_Group_Popup";

    
    VisualElement m_SCS_Group_Popup;
    Button m_SCS_Button_Back;
    List<Button> m_SCS_Buttons = new List<Button>();

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        for (int i = 0; i < 11; i++)
        {
            m_SCS_Buttons.Add(m_Root.Q<Button>(SCS_BUTTON + $"{i}"));
        }

        m_SCS_Group_Popup = m_Root.Q<VisualElement>(SCS_GROUP_POPUP);
        m_SCS_Button_Back = m_Root.Q<Button>(SCS_BUTTON_BACK);


        m_SCS_Group_Popup.style.display = DisplayStyle.None;

    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        m_SCS_Buttons[0].RegisterCallback<ClickEvent>(OnBackBt);

        m_SCS_Buttons[1].RegisterCallback<ClickEvent>(evt => OnPopupWindow(1));
        m_SCS_Buttons[2].RegisterCallback<ClickEvent>(evt => OnPopupWindow(2));
        m_SCS_Buttons[3].RegisterCallback<ClickEvent>(evt => OnPopupWindow(3));
        m_SCS_Buttons[4].RegisterCallback<ClickEvent>(evt => OnPopupWindow(4));
        m_SCS_Buttons[5].RegisterCallback<ClickEvent>(evt => OnPopupWindow(5));
        m_SCS_Buttons[6].RegisterCallback<ClickEvent>(evt => OnPopupWindow(6));
        m_SCS_Buttons[7].RegisterCallback<ClickEvent>(evt => OnPopupWindow(7));
        m_SCS_Buttons[8].RegisterCallback<ClickEvent>(evt => OnPopupWindow(8));
        m_SCS_Buttons[9].RegisterCallback<ClickEvent>(evt => OnPopupWindow(9));

        m_SCS_Buttons[10].RegisterCallback<ClickEvent>(OnEntirePopupWindow);
        m_SCS_Button_Back.RegisterCallback<ClickEvent>(OffEntirePopupWindow);

    }
    private void OnBackBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        
        // 메인 화면으로
        m_MainMenuUIManager.ShowMainScreen();
    }

    private void OnPopupWindow(int v)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Group_Popup.style.display = DisplayStyle.Flex;

        //애니메이션
        m_SCS_Group_Popup.AddToClassList("scrim--fadein");
    }
    private void OffPopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Group_Popup.style.display = DisplayStyle.None;

        //애니메이션
        m_SCS_Group_Popup.AddToClassList("scrim--fadein");
    }

    private void OnEntirePopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Group_Popup.style.display = DisplayStyle.Flex;

        //애니메이션
        m_SCS_Group_Popup.AddToClassList("scrim--fadein");
    }

    private void OffEntirePopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Group_Popup.style.display = DisplayStyle.None;

        //애니메이션
        m_SCS_Group_Popup.AddToClassList("scrim--fadein");
    }
}
