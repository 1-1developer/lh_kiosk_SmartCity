using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ProcessScreen : MenuScreen
{
    const string PS_BUTTON = "PS_Button";

    List<Button> m_PS_Buttons = new List<Button>();

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        for (int i = 0; i < 7; i++)
        {
            m_PS_Buttons.Add(m_Root.Q<Button>(PS_BUTTON + $"{i}"));
        }

    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        m_PS_Buttons[0].RegisterCallback<ClickEvent>(OnBackBt);

        m_PS_Buttons[1].RegisterCallback<ClickEvent>(evt => OnPopupSelection(1));
        m_PS_Buttons[2].RegisterCallback<ClickEvent>(evt => OnPopupSelection(2));
        m_PS_Buttons[3].RegisterCallback<ClickEvent>(evt => OnPopupSelection(3));
        m_PS_Buttons[4].RegisterCallback<ClickEvent>(evt => OnPopupSelection(4));
        m_PS_Buttons[5].RegisterCallback<ClickEvent>(evt => OnPopupSelection(5));
        m_PS_Buttons[6].RegisterCallback<ClickEvent>(evt => OnPopupSelection(6));

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
    }

    private void OffPopupSelection(int v)
    {
        AudioManager.PlayDefaultButtonSound();
    }

    private void OnPopupWindow(int v)
    {
        AudioManager.PlayDefaultButtonSound();
    }

    private void OffPopupWindow(int v)
    {
        AudioManager.PlayDefaultButtonSound();
    }
}
