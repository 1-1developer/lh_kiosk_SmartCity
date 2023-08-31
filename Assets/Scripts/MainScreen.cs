using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainScreen : MenuScreen
{
    const string MS_POPUP = "MS_Popup";
    const string MS_POPUP_IMAGE1 = "MS_Popup_Image1";
    const string MS_POPUP_IMAGE2 = "MS_Popup_Image2";
    const string MS_STATE0 = "MS_State0";
    const string MS_STATE1 = "MS_State1";
    const string MS_BUTTON1 = "MS_Button1";
    const string MS_BUTTON2 = "MS_Button2";

    const string PS_BACKGROUND = "PS_Background";
    const string SCS_BACKGROUND = "SCS_Background";

    [SerializeField]
    VideoManager videoManager;

    [SerializeField]
    TimeManager Timer;

    VisualElement m_MS_Popup;
    VisualElement m_MS_Popup_Image1;
    VisualElement m_MS_Popup_Image2;
    VisualElement m_MS_State0;
    VisualElement m_MS_State1;
    Button m_MS_Button1;
    Button m_MS_Button2;

    VisualElement m_PS_Background;
    VisualElement m_SCS_Background;

    int spotms = 5000;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_MS_Popup = m_Root.Q<VisualElement>(MS_POPUP);
        m_MS_Popup_Image1 = m_Root.Q<VisualElement>(MS_POPUP_IMAGE1);
        m_MS_Popup_Image2 = m_Root.Q<VisualElement>(MS_POPUP_IMAGE2);
        m_MS_State0 = m_Root.Q<VisualElement>(MS_STATE0);
        m_MS_State1 = m_Root.Q<VisualElement>(MS_STATE1);
        m_MS_Button1 = m_Root.Q<Button>(MS_BUTTON1);
        m_MS_Button2 = m_Root.Q<Button>(MS_BUTTON2);

        m_PS_Background = m_Root.Q(PS_BACKGROUND);
        m_SCS_Background = m_Root.Q(SCS_BACKGROUND);

        

    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        m_MS_Button1.RegisterCallback<ClickEvent>(evt => OnMainBt(0));
        m_MS_Button2.RegisterCallback<ClickEvent>(evt => OnMainBt(1));
        m_MS_State0.schedule.Execute(ac => PopupAnim()).Every(spotms);
    }
    void PopupAnim()
    {
        AnimatePopup();
        AnimateState();
    }

    private void AnimatePopup()
    {
        m_MS_Popup_Image1.ToggleInClassList("popup1--off");
        m_MS_Popup_Image1.RegisterCallback<TransitionEndEvent>(evt => m_MS_State0.ToggleInClassList("popup1--off"));
        m_MS_Popup_Image2.ToggleInClassList("popup2--on");
        m_MS_Popup_Image2.RegisterCallback<TransitionEndEvent>(evt => m_MS_State0.ToggleInClassList("popup2--on"));
    }

    private void AnimateState()
    {
        m_MS_State0.ToggleInClassList("popup--state1");
        m_MS_State0.RegisterCallback<TransitionEndEvent>(evt => m_MS_State0.ToggleInClassList("popup--state1"));
        m_MS_State1.ToggleInClassList("popup--state1");
        m_MS_State1.RegisterCallback<TransitionEndEvent>(evt => m_MS_State0.ToggleInClassList("popup--state1"));
    }     

    private void OnMainBt(int v)
    {
        AudioManager.PlayDefaultButtonSound();
        if (v == 0)
        {
            m_MainMenuUIManager.ShowProcessScreen();
            videoManager.PrepareClip(v);
            videoManager.PlayVideo();
        }
        else
        {
            m_MainMenuUIManager.ShowSmartCityScreen();
            videoManager.PrepareClip(v);
            videoManager.PlayVideo();
        }
    }
    
}
