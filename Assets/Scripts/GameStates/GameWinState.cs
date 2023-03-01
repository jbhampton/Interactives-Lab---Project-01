using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public ScenarioBlock _winScenario;

    public GameWinState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("GAME STATE: Win State");
        Debug.Log("You succeed skill check.");

        //set scenario
        _winScenario = _controller._currentScenario;

        //Set Win state hud
        _controller.ScenarioHUD.SetActive(false); //disable scenario hud
        _controller.WinScreen.SetActive(true);
        
        //set reset button to active
        _controller.ResetButton.SetActive(true);

        //SET WIN TEXT
        if (_controller.Input.AthCheck == true)
        {
            _controller.WinText.text = _winScenario._athWin;
        }
        else if (_controller.Input.AgiCheck == true)
        {
            _controller.WinText.text = _winScenario._agiWin;
        }
        else if (_controller.Input.IntCheck == true)
        {
            _controller.WinText.text = _winScenario._intWin;
        }
        else if (_controller.Input.ChaCheck == true)
        {
            _controller.WinText.text = _winScenario._chaWin;
        }
    }

    public override void Exit()
    {
        _controller.WinScreen.SetActive(false); //set win screen UI to inactive
        _controller.ResetButton.SetActive(false);
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        if (_controller.Input._resetPressed == true) //if reset button is pressed revert back to play state and reload the level
        {
            SceneManager.LoadScene(1);
        }

        /*
        if (_controller.Input._quitPressed == true) //if quit button is pressed load back to main menu
        {
            SceneManager.LoadScene(0);
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        */
    }
}
