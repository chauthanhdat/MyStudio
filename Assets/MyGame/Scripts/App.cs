using MyStudio.Framework.GameState;
using MyStudio.Framework.GameSystem;
using UnityEngine;

namespace MyGame.Common
{
    public class App : MonoBehaviour
    {
        private void Start()
        {
            SetupSystem();
            GameManager.Instance.ChangeState(new GameState_Init());
        }

        private void SetupSystem()
        {
            GameManager.Instance.RegisterSystem<PlayFabSystem>(new());
            GameManager.Instance.RegisterSystem<GameEventSystem>(new());
        }
    }
}

