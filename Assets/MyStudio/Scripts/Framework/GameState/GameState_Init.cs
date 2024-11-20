using MyStudio.Framework.GameSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyStudio.Framework.GameState
{
    public class GameState_Init : GameState
    {
        public override void Enter()
        {
            SceneManager.LoadScene("Loading"); //TODO: scene system

            var playfabSystem = GameManager.Instance.GetSystem<PlayFabSystem>();
            playfabSystem.Login(
                () =>
                {
                    SceneManager.LoadScene("MainMenu");
                },
                (e) =>
                {
                    Debug.LogError(e);
                }
            );
        }

        public override void Exit()
        {
        }
    }
}

