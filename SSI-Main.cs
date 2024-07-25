// OLD CODE
// GOING THROUGH A HELL OF A REWRITE USING QTSHARP
// WAIT UNTIL IT'S DONE FOR AN UPDATED CODE HERE

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class SSIui : Form
{
    private CheckBox checkBoxMarketplace;
    private CheckBox checkBoxSpicetify;
    private Button installButton;
    private Label labelTitle;
    private Label labelSubtitle;
    private Label labelFooter;

    public SSIui()
    {
        this.Width = 400;
        this.Height = 300;
        this.BackColor = Color.FromArgb(45, 45, 45);
        this.Text = "Spicetify Semiautomatic Installer";

        checkBoxMarketplace = new CheckBox
        {
            Text = "Install Marketplace",
            Location = new Point(18, 164),
            Size = new Size(138, 26),
            ForeColor = Color.White,
            Font = new Font("Arial", 10, FontStyle.Regular)
        };

        checkBoxSpicetify = new CheckBox
        {
            Text = "Install Spicetify",
            Location = new Point(18, 140),
            Size = new Size(138, 26),
            ForeColor = Color.White,
            Font = new Font("Arial", 10, FontStyle.Regular)
        };

        installButton = new Button
        {
            Text = "Install!",
            Location = new Point(29, 202),
            Size = new Size(115, 25),
            Font = new Font("Arial", 11, FontStyle.Regular),
            BackColor = Color.Gray,
            ForeColor = Color.Black
        };
        installButton.Click += InstallButton_Click;

        labelTitle = new Label
        {
            Text = "SSI",
            Location = new Point(123, 40),
            Size = new Size(200, 50),
            ForeColor = Color.FromArgb(215, 215, 215),
            Font = new Font("Arial", 50, FontStyle.Regular)
        };

        labelSubtitle = new Label
        {
            Text = "ui!",
            Location = new Point(139, 100),
            Size = new Size(200, 28),
            ForeColor = Color.FromArgb(190, 190, 190),
            Font = new Font("Arial", 28, FontStyle.Regular)
        };

        labelFooter = new Label
        {
            Text = "made by jstmax! with <3",
            Location = new Point(18, 87),
            Size = new Size(200, 12),
            ForeColor = Color.FromArgb(188, 188, 188),
            Font = new Font("Arial", 12, FontStyle.Regular)
        };

        this.Controls.Add(checkBoxMarketplace);
        this.Controls.Add(checkBoxSpicetify);
        this.Controls.Add(installButton);
        this.Controls.Add(labelTitle);
        this.Controls.Add(labelSubtitle);
        this.Controls.Add(labelFooter);
    }

    private void InstallButton_Click(object sender, EventArgs e)
    {
        bool installSpicetify = checkBoxSpicetify.Checked;
        bool installMarketplace = checkBoxMarketplace.Checked;

        if (installSpicetify && installMarketplace)
        {
            MessageBox.Show("Installing Spicetify with Marketplace...", "Installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExecutePowershellCommand("iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex");
            ExecutePowershellCommand("iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex");
        }
        else if (installSpicetify && !installMarketplace)
        {
            MessageBox.Show("Installing Spicetify without Marketplace...", "Installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExecutePowershellCommand("iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex");
        }
        else if (!installSpicetify && installMarketplace)
        {
            MessageBox.Show("Installing Marketplace without Spicetify... (lol)", "Installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExecutePowershellCommand("iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex");
        }
        else
        {
            MessageBox.Show("Don't wanna install anything? Ok, ok, your business...", "Installation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ExecutePowershellCommand(string command)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"{command}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error executing PowerShell command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SSIui());
    }
}
