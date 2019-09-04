using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private string customID;
    private bool waitWebRequest;

    [SerializeField] private PlayFabLog log;

    private void Start()
    {
        Login();
    }

    public void Login()
    {        
        CreateCustomID();

        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest { CustomId = customID, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

        log.InsertLogText("Aguarde a conexão...");
        waitWebRequest = true;
    }
    
    public void CreateCustomID()
    {
        customID = System.Guid.NewGuid().ToString("N");
    }

    private void OnLoginSuccess(LoginResult result)
    {
        log.InsertLogText("Conectado");

        waitWebRequest = false;
    }

    private void OnLoginFailure(PlayFabError error)
    {
        log.InsertLogText("Erro na conexão");
        log.InsertLogText(error.GenerateErrorReport());
        waitWebRequest = false;

        Login();
    }
    
    public bool IsProcessingWebRequest()
    {
        return waitWebRequest;
    }

    public void SetProcessingWebRequestState(bool _currentState)
    {
        waitWebRequest = _currentState;
    }
}