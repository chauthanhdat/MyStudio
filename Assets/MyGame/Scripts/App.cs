using MyStudio.Framework;
using MyStudio.Framework.GameSystem;
using UnityEngine;

namespace MyGame.Common
{
    public class App : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.RegisterSystem<PlayFabSystem>(new());

            GameManager.Instance.ChangeState(new GameState_Init());
        }
    }
}

