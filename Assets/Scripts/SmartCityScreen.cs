using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SmartCityScreen : MenuScreen
{
    const string SCS_BUTTON = "SCS_Button";
    const string SCS_TXT_BUTTON = "SCS_txt_Button";
    const string SCS_BUTTON_BACK = "SCS_Button_Back";
    const string SCS_BUTTON_BACK1 = "SCS_Button_Back1";
    const string SCS_BUTTON_BACK2 = "SCS_Button_Back2";
    const string SCS_POPUP = "SCS_Popup";
    const string SCS_POPUP_LEFT = "SCS_Popup_Left";
    const string SCS_POPUP_RIGHT = "SCS_Popup_RIght";
    const string SCS_POPUP_ENTIRE = "SCS_Popup_Entire";
    const string SCS_POPUP_WINDOW = "SCS_Popup_Window";

    public Sprite[] SCS_PopContents;

    VisualElement m_SCS_Popup;
    VisualElement m_SCS_Popup_Entire;
    Button m_SCS_Popup_Left;
    Button m_SCS_Popup_Right;
    Button m_SCS_Button_Back;
    Button m_SCS_Button_Back1;
    Button m_SCS_Button_Back2;
    List<Button> m_SCS_Buttons = new List<Button>();
    List<VisualElement> m_SCS_txt_Buttons = new List<VisualElement>();
    VisualElement m_SCS_Popup_Window;

    int page_num;
    bool state_activate = false;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        for (int i = 0; i < 11; i++)
        {
            m_SCS_Buttons.Add(m_Root.Q<Button>(SCS_BUTTON + $"{i}"));
        }
        for (int i = 1; i < 10; i++)
        {
            m_SCS_txt_Buttons.Add(m_Root.Q<VisualElement>(SCS_TXT_BUTTON + $"{i}"));
        }

        m_SCS_Popup = m_Root.Q<VisualElement>(SCS_POPUP);
        m_SCS_Popup_Entire = m_Root.Q<VisualElement>(SCS_POPUP_ENTIRE);
        m_SCS_Popup_Left = m_Root.Q<Button>(SCS_POPUP_LEFT);        
        m_SCS_Popup_Right = m_Root.Q<Button>(SCS_POPUP_RIGHT);
        m_SCS_Button_Back = m_Root.Q<Button>(SCS_BUTTON_BACK);
        m_SCS_Button_Back1 = m_Root.Q<Button>(SCS_BUTTON_BACK1);
        m_SCS_Button_Back2 = m_Root.Q<Button>(SCS_BUTTON_BACK2);
        m_SCS_Popup_Window = m_Root.Q<VisualElement>(SCS_POPUP_WINDOW);

    }
    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        // ¸ÞÀÎ È­¸éÀ¸·Î
        m_SCS_Buttons[0].RegisterCallback<ClickEvent>(OnBackBt);

        // ÆË¾÷ ¹öÆ° È¿°ú
        m_SCS_Buttons[1].RegisterCallback<ClickEvent>(evt => OnPopupButton(0));
        m_SCS_Buttons[2].RegisterCallback<ClickEvent>(evt => OnPopupButton(1));
        m_SCS_Buttons[3].RegisterCallback<ClickEvent>(evt => OnPopupButton(2));
        m_SCS_Buttons[4].RegisterCallback<ClickEvent>(evt => OnPopupButton(3));
        m_SCS_Buttons[5].RegisterCallback<ClickEvent>(evt => OnPopupButton(4));
        m_SCS_Buttons[6].RegisterCallback<ClickEvent>(evt => OnPopupButton(5));
        m_SCS_Buttons[7].RegisterCallback<ClickEvent>(evt => OnPopupButton(6));
        m_SCS_Buttons[8].RegisterCallback<ClickEvent>(evt => OnPopupButton(7));
        m_SCS_Buttons[9].RegisterCallback<ClickEvent>(evt => OnPopupButton(8));

        m_SCS_Button_Back.RegisterCallback<ClickEvent>(OffPopupButton);

        // ÆË¾÷ Ã¢ ´Ý±â
        m_SCS_Button_Back1.RegisterCallback<ClickEvent>(OffPopupWindow);

        // ÇÏ´Ü ÆË¾÷ Ã¢ ¶ç¿ì±â & ´Ý±â
        m_SCS_Buttons[10].RegisterCallback<ClickEvent>(OnEntirePopupWindow);
        m_SCS_Button_Back2.RegisterCallback<ClickEvent>(OffEntirePopupWindow);
        
        // ÆË¾÷ Ã¢ ÁÂ¿ì ÀÌµ¿
        m_SCS_Popup_Left.RegisterCallback<ClickEvent>(OnLeftBt);
        m_SCS_Popup_Right.RegisterCallback<ClickEvent>(OnRightBt);
    }
    private void OnBackBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        
        // ¸ÞÀÎ È­¸éÀ¸·Î
        m_MainMenuUIManager.ShowMainScreen();
    }

    private void OnPopupButton(int v)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Buttons[v + 1].AddToClassList("buttonAnim--big");
        m_SCS_Buttons[v + 1].RemoveFromClassList("buttonAnim--on");
        m_SCS_txt_Buttons[v].RemoveFromClassList("buttonAnim--on");

        m_SCS_Button_Back.style.display = DisplayStyle.Flex;

        for (int i = 0; i < 9; i++)
        {
            if (i == v)
            {
                continue;
            }
            else
            {
                m_SCS_txt_Buttons[i].AddToClassList("buttonAnim--on");
                m_SCS_Buttons[i+1].AddToClassList("buttonAnim--on");
                m_SCS_Buttons[i+1].RemoveFromClassList("buttonAnim--big");
            }
        }
        
        // ÆË¾÷ Ã¢ ¶ç¿ì±â
        page_num = v;
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Popup.style.display = DisplayStyle.Flex;
        m_SCS_Popup_Window.style.backgroundImage = SCS_PopContents[v].texture;

        //¾Ö´Ï¸ÞÀÌ¼Ç
        m_SCS_Popup.AddToClassList("popup--fadein");
    }

    private void OffPopupButton(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();
        m_SCS_Button_Back.style.display = DisplayStyle.None;

        for (int i = 0; i < 9; i++)
        {
            m_SCS_Buttons[i + 1].RemoveFromClassList("buttonAnim--on");
            m_SCS_txt_Buttons[i].RemoveFromClassList("buttonAnim--on");
            m_SCS_Buttons[i + 1].RemoveFromClassList("buttonAnim--big");
        }
    }

    private void OffPopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Popup.style.display = DisplayStyle.None;

        //¾Ö´Ï¸ÞÀÌ¼Ç
        m_SCS_Popup.RemoveFromClassList("popup--fadein");
    }

    private void OnEntirePopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Popup_Entire.style.display = DisplayStyle.Flex;

        //¾Ö´Ï¸ÞÀÌ¼Ç
        m_SCS_Popup_Entire.AddToClassList("popup--fadein");
    }

    private void OffEntirePopupWindow(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        m_SCS_Popup_Entire.style.display = DisplayStyle.None;

        //¾Ö´Ï¸ÞÀÌ¼Ç
        m_SCS_Popup_Entire.RemoveFromClassList("popup--fadein");
    }
    private void OnLeftBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        if(page_num == 0)
        {
            m_SCS_Popup_Window.style.backgroundImage = SCS_PopContents[8].texture;

            m_SCS_txt_Buttons[0].AddToClassList("buttonAnim--on");
            m_SCS_txt_Buttons[8].RemoveFromClassList("buttonAnim--on");

            m_SCS_Buttons[1].AddToClassList("buttonAnim--on");
            m_SCS_Buttons[9].RemoveFromClassList("buttonAnim--on");
            m_SCS_Buttons[1].RemoveFromClassList("buttonAnim--big");
            m_SCS_Buttons[9].AddToClassList("buttonAnim--big");

            page_num = 8;
        }
        else
        {
            m_SCS_Popup_Window.style.backgroundImage = SCS_PopContents[page_num - 1].texture;

            m_SCS_txt_Buttons[page_num].AddToClassList("buttonAnim--on");
            m_SCS_txt_Buttons[page_num - 1].RemoveFromClassList("buttonAnim--on");

            m_SCS_Buttons[page_num + 1].AddToClassList("buttonAnim--on");
            m_SCS_Buttons[page_num].RemoveFromClassList("buttonAnim--on");
            m_SCS_Buttons[page_num + 1].RemoveFromClassList("buttonAnim--big");
            m_SCS_Buttons[page_num].AddToClassList("buttonAnim--big");

            page_num -= 1;
        }
    }
    private void OnRightBt(ClickEvent evt)
    {
        AudioManager.PlayDefaultButtonSound();

        if (page_num == 8)
        {
            m_SCS_Popup_Window.style.backgroundImage = SCS_PopContents[0].texture;

            m_SCS_txt_Buttons[8].AddToClassList("buttonAnim--on");
            m_SCS_txt_Buttons[0].RemoveFromClassList("buttonAnim--on");

            m_SCS_Buttons[9].AddToClassList("buttonAnim--on");
            m_SCS_Buttons[1].RemoveFromClassList("buttonAnim--on");
            m_SCS_Buttons[9].RemoveFromClassList("buttonAnim--big");
            m_SCS_Buttons[1].AddToClassList("buttonAnim--big");

            page_num = 0;
        }
        else
        {
            m_SCS_Popup_Window.style.backgroundImage = SCS_PopContents[page_num + 1].texture;

            m_SCS_txt_Buttons[page_num].AddToClassList("buttonAnim--on");
            m_SCS_txt_Buttons[page_num + 1].RemoveFromClassList("buttonAnim--on");

            m_SCS_Buttons[page_num + 1].AddToClassList("buttonAnim--on");
            m_SCS_Buttons[page_num + 2].RemoveFromClassList("buttonAnim--on");
            m_SCS_Buttons[page_num + 1].RemoveFromClassList("buttonAnim--big");
            m_SCS_Buttons[page_num + 2].AddToClassList("buttonAnim--big");

            page_num += 1;
        }
    }

    public void InitSmartCityScreen()
    {
      
        m_SCS_Button_Back.style.display = DisplayStyle.None;    

        for (int i = 0; i < 9; i++)
        {
            m_SCS_Buttons[i + 1].RemoveFromClassList("buttonAnim--on");
            m_SCS_txt_Buttons[i].RemoveFromClassList("buttonAnim--on");
            m_SCS_Buttons[i + 1].RemoveFromClassList("buttonAnim--big");
        }

        m_SCS_Popup.style.display = DisplayStyle.None;
        m_SCS_Popup.RemoveFromClassList("popup--fadein");

        m_SCS_Popup_Entire.style.display = DisplayStyle.None;
        m_SCS_Popup_Entire.RemoveFromClassList("popup--fadein");
    }
}
