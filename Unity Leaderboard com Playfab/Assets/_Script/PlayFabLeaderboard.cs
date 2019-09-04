using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeaderboard : MonoBehaviour
{
    private StatisticUpdate score;
    private List<StatisticUpdate> playerScore;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField pointsField;

    [SerializeField] private PlayFabLog log;
    [SerializeField] private PlayFabLogin login;

    private void Start()
    {
        score = new StatisticUpdate();
        playerScore = new List<StatisticUpdate>();
        playerScore.Add(score);
    }

    #region Insere no Placar
    public void AddLeaderboardEntry()
    {
        if(!login.IsProcessingWebRequest())
        {
            playerScore[0].StatisticName = "Placar";
            playerScore[0].Value = int.Parse(pointsField.text);

            UpdateUserTitleDisplayNameRequest requestDisplayName = new UpdateUserTitleDisplayNameRequest { DisplayName = nameField.text };
            PlayFabClientAPI.UpdateUserTitleDisplayName(requestDisplayName, OnDisplayNameChange, OnDisplayNameError);

            log.InsertLogText("Inserindo no placar...");

            login.SetProcessingWebRequestState(true);
        }
    }

    private void OnDisplayNameChange(UpdateUserTitleDisplayNameResult result)
    {
        UpdatePlayerStatisticsRequest requestStatistic = new UpdatePlayerStatisticsRequest { Statistics = playerScore };
        PlayFabClientAPI.UpdatePlayerStatistics(requestStatistic, OnLeaderBoardPost, OnLeaderboardError);
    }    

    private void OnDisplayNameError(PlayFabError error)
    {            
        log.InsertLogText("Erro ao inserir nome");
        log.InsertLogText(error.GenerateErrorReport());
        login.SetProcessingWebRequestState(false);
    }

    private void OnLeaderBoardPost(UpdatePlayerStatisticsResult result)
    {
        log.InsertLogText("Inserido! Recarregue o placar para visualizar os resultados");

        login.SetProcessingWebRequestState(false);
        nameField.text = "";
        pointsField.text = "";

        login.Login();
    }

    private void OnLeaderboardError(PlayFabError error)
    {
        log.InsertLogText("Erro ao inserir no placar");
        log.InsertLogText(error.GenerateErrorReport());
    }
    #endregion

    #region Carrega o placar
    public void GetLeaderboard()
    {
        if(!login.IsProcessingWebRequest())
        {
            GetLeaderboardRequest requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "Placar" };
            PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnGetLeaderboardError);

            log.InsertLogText("Carregando placar...");

            login.SetProcessingWebRequestState(true);
        }
    }

    private void OnGetLeaderboard(GetLeaderboardResult result)
    {
        scoreText.text = "";
        foreach (PlayerLeaderboardEntry player in result.Leaderboard)
        {
            scoreText.text += player.DisplayName + ": " + player.StatValue + "\n";
        }

        log.InsertLogText("Placar carregado");

        login.SetProcessingWebRequestState(false);
    }

    private void OnGetLeaderboardError(PlayFabError error)
    {
        log.InsertLogText("Erro ao carregar o placar");
        log.InsertLogText(error.GenerateErrorReport());
    }
    #endregion
}