using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;
    //TODO add other input events here

    public Button ATHButton;
    public Button AGIButton;
    public Button INTButton;
    public Button CHAButton;

    public Button ResetButton;
    public bool _resetPressed;

    public Button QuitButton;
    public bool _quitPressed;

    public bool SkillSelected { get; private set; } = false;
    public bool AthCheck { get; private set; } = false;
    public bool AgiCheck { get; private set; } = false;
    public bool IntCheck { get; private set; } = false;
    public bool ChaCheck { get; private set; } = false;

    private void Awake()
    {
        SkillSelected = false;
    }

    private void Update()
    {
        //NOTE: Put your Input/Detection here, this code does not account for new Input
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsTapPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsTapPressed = false;
        }

        ATHButton.onClick.AddListener(AthleticsCheck);
        AGIButton.onClick.AddListener(AgilityCheck);
        INTButton.onClick.AddListener(IntelligenceCheck);
        CHAButton.onClick.AddListener(CharismaCheck);

        ResetButton.onClick.AddListener(ResetScenario);
        QuitButton.onClick.AddListener(QuitScenario);
    }

    public void AthleticsCheck()
    {
        //Debug.Log("Roll for Athletics");
        SkillSelected = true;
        AthCheck = true;
    }
    public void AgilityCheck()
    {
        //Debug.Log("Roll for Agility");
        SkillSelected = true;
        AgiCheck = true;
    }
    public void IntelligenceCheck()
    {
        //Debug.Log("Roll for Intelligence");
        SkillSelected = true;
        IntCheck = true;
    }
    public void CharismaCheck()
    {
        //Debug.Log("Roll for Charisma");
        SkillSelected = true;
        ChaCheck = true;
    }
    public void ResetScenario()
    {
        _resetPressed = true;
    }

    public void QuitScenario()
    {
        _quitPressed = true;
        SceneManager.LoadScene(0);
    }
}
