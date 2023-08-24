using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UIManager : MonoBehaviour
{
    [Header("Modal Menu Screens")]
    [Tooltip("Only one modal interface can appear on-screen at a time.")]
    [SerializeField] MainScreen m_MainModalScreen;
    [SerializeField] ProcessScreen m_ProcessModalScreen;
    [SerializeField] SmartCityScreen m_SmartCityModalScreen;

    UIDocument m_MainMenuDocument;
    public UIDocument MainMenuDocument => m_MainMenuDocument;
    List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

    void SetupModalScreens()
    {
        if (m_MainModalScreen != null)
            m_AllModalScreens.Add(m_MainModalScreen);
        if (m_ProcessModalScreen != null)
            m_AllModalScreens.Add(m_ProcessModalScreen);
        if (m_SmartCityModalScreen != null)
            m_AllModalScreens.Add(m_SmartCityModalScreen);
    }

    void ShowModalScreen(MenuScreen modalScreen)
    {
        foreach (MenuScreen m in m_AllModalScreens)
        {
            if (m == modalScreen)
            {
                m?.ShowScreen();
            }
            else
            {
                m?.HideScreen();
            }
        }
    }
    void OnEnable()
    {
        m_MainMenuDocument = GetComponent<UIDocument>();
        SetupModalScreens();
        ShowMainScreen();
    }
    public void ShowMainScreen()
    {
        ShowModalScreen(m_MainModalScreen);
    }
    public void ShowProcessScreen()
    {
        ShowModalScreen(m_ProcessModalScreen);
    }
    public void ShowSmartCityScreen()
    {
        ShowModalScreen(m_SmartCityModalScreen);
    }
}
