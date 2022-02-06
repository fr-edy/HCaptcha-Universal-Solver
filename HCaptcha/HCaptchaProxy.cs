using System.Net;

public class HCatpchaProxy
{
    private string ip, username, password;
    private ushort port;
    private bool useCredentials;
    private HCaptchaProxyType proxyType;

    public HCatpchaProxy(HCaptchaProxyType proxyType, string ip, ushort port)
    {
        this.proxyType = proxyType;
        this.ip = ip;
        this.port = port;
    }

    public HCatpchaProxy(HCaptchaProxyType proxyType, string ip, ushort port, string username, string password)
    {
        this.proxyType = proxyType;
        this.ip = ip;
        this.port = port;
        this.username = username;
        this.password = password;
        this.useCredentials = true;
    }

    public string GetIP()
    {
        return this.ip;
    }

    public void SetIP(string ip)
    {
        this.ip = ip;
    }

    public ushort GetPort()
    {
        return this.port;
    }

    public void SetPort(ushort port)
    {
        this.port = port;
    }

    public string GetUsername()
    {
        return this.username;
    }

    public void SetUsername(string username)
    {
        this.username = username;
    }

    public string GetPassword()
    {
        return this.password;
    }

    public void SetPassword(string password)
    {
        this.password = password;
    }

    public bool IsUsingCredentials()
    {
        return this.useCredentials;
    }

    public void SetUseCredentials(bool useCredentials)
    {
        this.useCredentials = useCredentials;
    }

    public HCaptchaProxyType GetProxyType()
    {
        return this.proxyType;
    }

    public void SetProxyType(HCaptchaProxyType proxyType)
    {
        this.proxyType = proxyType;
    }

    public WebProxy GetProxy()
    {
        try
        {
            WebProxy proxy = null;

            switch (this.proxyType)
            {
                case HCaptchaProxyType.Basic:
                    proxy = new WebProxy(ip, port);
                    break;
                case HCaptchaProxyType.HTTP:
                    proxy = new WebProxy("http://" + ip + ":" + port);
                    break;
                case HCaptchaProxyType.HTTPS:
                    proxy = new WebProxy("https://" + ip + ":" + port);
                    break;
                case HCaptchaProxyType.SOCKS4:
                    proxy = new WebProxy("socks4://" + ip + ":" + port);
                    break;
                case HCaptchaProxyType.SOCKS5:
                    proxy = new WebProxy("socks5://" + ip + ":" + port);
                    break;
                default:
                    break;
            }

            if (proxy != null && this.useCredentials)
            {
                proxy.Credentials = new NetworkCredential(this.username, this.password);
            }

            return proxy;
        }
        catch
        {
            return null;
        }
    }
}