using System;
using System.Diagnostics;
using System.Threading;
// TWFpbiBkZXZlbG9wZXIgYW5kIG1haW50YWluZXI6IGpzdG1heCEgKCo0PSoyKjIgc2wp

class SSI
{
    static void Main()
    {
        // SSI - Release 2.3
        Console.WriteLine("SSI - SpicetifySemiautomaticInstaller");
        Console.Write("Do you want to install Spicetify? (y/n): ");
        String choiceInst = Console.ReadLine();
        Console.Write("Do you want to install Spicetify Marketplace? (y/n): ");
        String choiceMktp = Console.ReadLine();

        // Check user's choices, case #1
        if (choiceInst == "y" && choiceMktp == "y")
        {
            Console.WriteLine("Installing Spicetify with Marketplace..");
            Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"");
            Process.Start("powershell.exe", "-Command \"iwr -useb iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex\"");
        }
        // Case #2
        else if (choiceInst == "y" && choiceMktp == "n")
        {
            Console.WriteLine("Installing Spicetify without Marketplace..");
            Thread.Sleep(1500);
            Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"");
        }
        // Case #3
        else if (choiceInst == "n" && choiceMktp == "y")
        {
            Console.WriteLine("Installing Marketplace without Spicetify.. (lol)");
            Thread.Sleep(1500);
            Process.Start("powershell.exe", "-Command \"iwr -useb iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex\"");
        }
        else if (choiceInst == "n" && choiceMktp == "n")
        {
            Console.WriteLine("Don't wanna install anything? Ok, ok, your business..");
            Thread.Sleep(1500);
            Environment.Exit(0);
        }
    }
}
