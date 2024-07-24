using System;
using System.Diagnostics;

class SSI
{
    static void Main()
    {
            // SSI - Release A (WIP) // Do we need to add Console.ReadKey();
            Console.WriteLine("SSI - SpicetifySemiautomaticInstaller");
            Console.Write("Do you want to install Spicetify? (y/n): ");
            String choiceInst = Console.ReadLine();
            Console.Write("Do you want to install Spicetify Marketplace? (y/n): ");
            String choiceMktp = Console.ReadLine(); 

        // Check user's choice, and install Spicetify
        if (choiceInst == "y")
        {
            Process.Start("powershell.exe", "-Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"");
        }
        else
        {
            /* For those (not autistic) who didn't understand WHY i did this,
            i still don't know how to do like an "else: pass" thing or smth, so i
            created a useless function to fill in the else inside this if function */
            String uselessFuncKEKW = Console.ReadLine();
        }
        // Same for Spicetify Marketplace
        if (choiceMktp == "y")
        {
            Process.Start("powershell.exe", "-Command \"iwr -useb iwr -useb https://raw.githubusercontent.com/spicetify/marketplace/main/resources/install.ps1 | iex\"");
        }
        else if (choiceInst == "y")
        {
            Console.WriteLine("Spicetify installed without Spicetify Marketplace");
            Console.WriteLine("Exciting SSI..");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("You just started a Spicetify installer, and selected not to install Spicetify(?)");
            Environment.Exit(0);
        }
    }
}
