using System;
using System.Diagnostics;

class SSI
{
    static void Main()
    {
            // User experience stuff
            Console.WriteLine("SSI - SpicetifySemiautomaticInstaller");
            Console.WriteLine("Do you want to install Spicetify? (y/n): ");
            String choiceInst = Console.ReadLine();
            Console.WriteLine("Do you want to install Spicetify Marketplace? (y/n): ");
            String choiceMktp = Console.ReadLine();
            Console.Clear();

        // Check user's choice, and install Spicetify
        if (choiceInst == "y")
        {
            Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"");
        }
        else
        {
            Console.WriteLine("POV: You start a Spicetify installer, and select not to install Spicetify");
            Environment.Exit(0);
        }
        // Same for Spicetify Marketplace
        if (choiceMktp == "y")
        {
            Process.Start("powershell.exe", "-Command \"iwr -useb iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex\"");
        }
        else
        {
            Console.WriteLine("Spicetify installed without Spicetify Marketplace");
            Console.WriteLine("Exciting SSI..");
            Environment.Exit(0);
        }
    }
}
