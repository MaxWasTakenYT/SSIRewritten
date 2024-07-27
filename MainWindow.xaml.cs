using System.Windows;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
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
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var message = e.WebMessageAsJson;
            dynamic json = JsonConvert.DeserializeObject(message);

            if (json.action == "install")
            {
                bool installSpicetify = json.installSpicetify;
                bool installMarketplace = json.installMarketplace;

                if (installSpicetify && installMarketplace)
                {
                    MessageBox.Show("installing Spicetify and Marketplace.. -~-*(# 3#)/*-~-");
                    System.Diagnostics.Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"");
                    System.Diagnostics.Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex\"");
                }
                else if (installSpicetify)
                {
                    MessageBox.Show("installing Spicetify.. -~-*(SwS)/*-~-");
                    System.Diagnostics.Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"");
                }
                else if (installMarketplace)
                {
                    MessageBox.Show("installing Marketplace.. -~-*(MwM)/*-~-");
                    System.Diagnostics.Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex\"");
                }
                else
                {
                    MessageBox.Show("you need to select at least 1 option.. -~-*(@//@)/*-~-");
                }
            }
        }
    }
}