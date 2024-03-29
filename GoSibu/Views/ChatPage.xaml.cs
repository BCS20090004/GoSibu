using Microsoft.AspNetCore.SignalR.Client;

namespace GoSibu.Views;

public partial class ChatPage : ContentPage
{
    private readonly HubConnection hubConnection;

    public ChatPage()
    {
        InitializeComponent();

        var baseUrl = "http://localhost";

        // Android can't connect to localhost
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            baseUrl = "http://10.0.2.2";
        }

        hubConnection = new HubConnectionBuilder()
            .WithUrl($"{baseUrl}:5007/chatHub")
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            lblChat.Text += $"<b>{user}</b>: {message}<br/>";
        });

        Task.Run(() =>
        {
            Dispatcher.Dispatch(async () =>
            {
                await hubConnection.StartAsync();
            });
        });
    }

    private async void btnSend_Clicked(object sender, EventArgs e)
    {
        await hubConnection.InvokeCoreAsync("SendMessageToAll", args: new[]
        {
                txtUsername.Text,
                txtMessage.Text
            });

        txtMessage.Text = String.Empty;
    }
}