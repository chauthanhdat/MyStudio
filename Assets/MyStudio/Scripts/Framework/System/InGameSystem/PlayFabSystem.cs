using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace MyStudio.Framework.GameSystem
{
    public class PlayFabSystem : InGameSystem
    {
        private string _playFabId;
        private event System.Action _onLoginSuccess;
        private event System.Action<string> _onLoginFailure;

        public override void Init()
        {
        }

        public override void Destroy()
        {
        }

        public void Login(System.Action onLoginSuccess , System.Action<string> onLoginFailure)
        {
            _onLoginSuccess = onLoginSuccess;
            _onLoginFailure = onLoginFailure;

            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            {
                PlayFabSettings.staticSettings.TitleId = "71334";
            }
            var request = new LoginWithCustomIDRequest
            {
                CustomId = "GettingStartedGuide",
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        }

        private void OnLoginSuccess(LoginResult result)
        {
            SetUserData();
            GetUserData(result.PlayFabId);

            Debug.LogError(result.PlayFabId);

            _playFabId = result.PlayFabId;

            _onLoginSuccess?.Invoke();
        }

        private void OnLoginFailure(PlayFabError error)
        {
            _onLoginFailure?.Invoke(error.GenerateErrorReport());
            Debug.LogWarning("Something went wrong with your first API call.  :(");
            Debug.LogError("Here's some debug information:");
            Debug.LogError(error.GenerateErrorReport());
        }

        private void SetUserData()
        {
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = new()
                {
                    {"Ancestor", "Athur"},
                    {"Successor", "Fred"},
                }
            },
            result =>
            {
                Debug.Log("Successfully updated user data");
            },
            error =>
            {
                Debug.Log("Got error setting user data Ancestor to Athur");
            });
        }

        private void GetUserData(string myPlayFabId)
        {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest()
            {
                PlayFabId = myPlayFabId,
                Keys = null,
            },
            result =>
            {
                Debug.Log("Got user data:");
                if (result.Data == null || !result.Data.ContainsKey("Ancestor"))
                {
                    Debug.Log("No Ancestor");
                }
                else
                {
                    Debug.Log("Ancestor: " + result.Data["Ancestor"].Value);
                }
            },
            error =>
            {
                Debug.Log("Got error retriveing user data: ");
                Debug.Log(error.GenerateErrorReport());
            });
        }

        public string GetPlayFabId()
        {
            return _playFabId;
        }
    }
}
