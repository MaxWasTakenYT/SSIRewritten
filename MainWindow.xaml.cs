using System;
using System.IO;
using System.Windows;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace SSIRewritten
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            await webView.EnsureCoreWebView2Async(null);
            var htmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "web", "index.html");
            webView.Source = new Uri(htmlFilePath, UriKind.Absolute);
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var message = e.WebMessageAsJson;
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(message);

            if (json.action == "install")
            {
                bool installSpicetify = json.installSpicetify;

                if (installSpicetify)
                {
                    MessageBox.Show("the script will ask you to install the marketplace!.. -~-*(# 3#)/*-~-");
                    Process.Start(new ProcessStartInfo("powershell", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"")).StandardOutput.ReadToEnd();
                }
                else
                {
                    MessageBox.Show("you need to select at least 1 option.. -~-*(@//@)/*-~-");
                }
            }
        }
    }
}
