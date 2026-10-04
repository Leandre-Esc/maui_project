namespace maui_project.Services.Api;

public class ApiConfig
{
    public const string StagingPingUrl = "http://51.11.240.246/api/ping";

    private const string LanIp = "192.168.0.30";
    private const int Port = 5265;

    public static string BaseUrl
    {
        get
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
                return $"http://10.0.2.2:{Port}";

            if (DeviceInfo.Platform == DevicePlatform.iOS &&
                DeviceInfo.DeviceType == DeviceType.Virtual)
                return $"http://localhost:{Port}";
            
            return $"http://{LanIp}:{Port}";
        }
    }
}
