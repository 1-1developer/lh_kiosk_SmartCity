using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainScreen : MenuScreen
{
    const string MS_POPUP1 = "MS_Popup1";
    const string MS_POPUP2 = "MS_Popup2";
    const string MS_STATE0 = "MS_State0";
    const string MS_STATE1 = "MS_State1";
    const string MS_BUTTON1 = "MS_Button1";
    const string MS_BUTTON2 = "MS_Button2";

    [SerializeField]
    TimeManager Timer;

    VisualElement m_MS_Popup1;
    VisualElement m_MS_Popup2;
    VisualElement m_MS_State0;
    VisualElement m_MS_State1;
    Button m_MS_Button1;
    Button m_MS_Button2;


 
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_MS_Popup1 = m_Root.Q<VisualElement>(MS_POPUP1);
        m_MS_Popup2 = m_Root.Q<VisualElement>(MS_POPUP2);
        m_MS_State0 = m_Root.Q<VisualElement>(MS_STATE0);
        m_MS_State1 = m_Root.Q<VisualElement>(MS_STATE1);
        m_MS_Button1 = m_Root.Q<Button>(MS_BUTTON1);
        m_MS_Button2 = m_Root.Q<Button>(MS_BUTTON2);

        AnimateState();

    }
 
    private void AnimateState()
    {
        m_MS_State0.ToggleInClassList("popup-state1");
        m_MS_State1.RegisterCallback<TransitionEndEvent>(evt => m_MS_State0.ToggleInClassList("popup-state1"));
        Debug.Log("asdf");
    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        AnimateState();

        m_MS_Button1.RegisterCallback<ClickEvent>(evt => OnMainBt(0));
        m_MS_Button2.RegisterCallback<ClickEvent>(evt => OnMainBt(1));

    }
    private void OnMainBt(int v)
    {
        AudioManager.PlayDefaultButtonSound();
        if (v == 0)
        {
            m_MainMenuUIManager.ShowProcessScreen();
        }
        else
        {
            m_MainMenuUIManager.ShowSmartCityScreen();
        }
    }

}