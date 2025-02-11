using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace WindowsFormsAppWithReact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           initWebView();
        }

        private async void initWebView()
        {
            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(
                userDataFolder: "WebView2Data",
                options: new CoreWebView2EnvironmentOptions("--allow-file-access-from-files")
            );
           
            await webView21.EnsureCoreWebView2Async(env);
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "app.example", "ReactBuild",
                CoreWebView2HostResourceAccessKind.Allow
            );
            string buildPath = Path.Combine(Application.StartupPath, "ReactBuild", "index.html");
            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            //webView21.CoreWebView2.AddHostObjectToScript("winFormInterop", new WinFormInterop());
            webView21.Source = new Uri($"file:///{buildPath}");
        }
        private async void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            // 接收来自 WebView2 控件的消息
            MessageBox.Show("Test");

        }
        private void webView21_Click(object sender, EventArgs e)
        {
             
        }
    }
}
