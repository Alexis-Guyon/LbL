using System;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using League_Bot_Legends;
using League_Bot_Legends.IO;

using Leaf.xNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
public class ClientLCU 
{ 
    private static string auth;
    private static int port;
    private static string URL => "https://127.0.0.1:" + port + "/";
    private static string loginURL => URL + "lol-login/v1/session";
    private static string createLobbyURL => URL + "lol-lobby/v2/lobby";
    private static string searchURL => URL + "lol-lobby/v2/lobby/matchmaking/search";
    private static string acceptURL => URL + "lol-matchmaking/v1/ready-check/accept";
    private static string pickURL => URL + "lol-champ-select/v1/session/actions/";
    private static string SessionURL => URL + "lol-champ-select/v1/session";
    private static string loginUrl => URL + "rso-auth/v1/session/credentials";
    private static string honorURL => URL + "lol-honor-v2/v1/honor-player";
    private static string getHonorDataUrl => URL + "lol-honor-v2/v1/ballot";
    private static string pickableChampionsUrl => URL + "lol-champ-select/v1/pickable-champion-ids";
    private static string killUXUrl => URL + "riotclient/kill-ux";
    private static string gameflowAvailabilityUrl => URL + "lol-gameflow/v1/availability";
    private static string gameflowPhaseUrl => URL + "lol-gameflow/v1/gameflow-phase";
    private static string currentSummonerUrl => URL + "lol-summoner/v1/current-summoner";

    public static void Initialize()
    {
        string path = Path.Combine(Configuration.Instance.ClientPath, @"League of Legends\lockfile");

        using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (var streamReader = new StreamReader(fileStream, Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] lines = line.Split(':');
                    port = int.Parse(lines[2]);
                    string riotPass = lines[3];
                    auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("riot:" + riotPass));
                }
            }
        }

        if (port == 0)
        {
            Logger.Write("Unnable to initialize the client (read API port from process", MessageState.ERROR_FATAL);
        }
    }

    public static bool IsApiReady()
    {
        using (HttpRequest request = new HttpRequest())
        {
            request.IgnoreProtocolErrors = true;
            request.ConnectTimeout = Constants.HttpRequestTimeout;
            request.ReadWriteTimeout = Constants.HttpRequestTimeout;
            request.CharacterSet = Constants.HttpRequestEncoding;
            request.AddHeader("Authorization", "Basic " + auth);
            try
            {
                var response = request.Get(gameflowAvailabilityUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        

        return false;
    }
}
