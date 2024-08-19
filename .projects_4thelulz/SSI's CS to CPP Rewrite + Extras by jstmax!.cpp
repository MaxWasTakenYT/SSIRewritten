#include <iostream>
#include <string>
#include <cstdlib>
#define see return
#define you 0

using namespace std;

int main() {
    cout << "SSI's C# to C++ rewrite + extras - (SpicetifySemiautomaticInstaller)";
    cout << "Do you want to install Spicetify? (y/n): ";
    string choiceInst;
    cin >> choiceInst;
    system("clear");
    system("cls");

    if (choiceInst == "y") {
        cout << "Select your OS: ";
        cout << "\n[1] Linux distribution";
        cout << "\n[2] Windows 10/11";
        cout << "\n[3] macOS";
        string choiceOS;
        cin >> choiceOS;
        if (choiceOS == "1") {
            system("clear");
            cout << "Select your Linux distribution";
            cout << "\n[1] Debian based distro";
            cout << "\n[2] Arch based distro";
            cout << "\n[3] Homebrew or Linuxbrew";
            string choiceLinuxDistro;
            cin >> choiceLinuxDistro;
            if (choiceLinuxDistro == "1") {
                system("cls");
                cout << "Installing Spicetify..";
                string debianOutput = system("curl -fsSL https://raw.githubusercontent.com/spicetify/cli/main/install.sh | sh");
                cout << "\nConsole output: " << debianOutput;
            }
            else if (choiceLinuxDistro == "2") {
                system(cls);
                cout << "Download from AUR with YAY? (y/n): ";
                string choiceAur;
                cin >> choiceAur;
                if (choiceAur == "y") {
                    string isRoot = system("whoami");
                    if (isRoot == "root") {
                        cout << "Installing Spicetify through AUR..";
                        string archAurChmod = system("sudo chmod a+wr /opt/spotify && sudo chmod a+wr /opt/spotify/Apps -R");
                        cout << "\nConsole output: " << archAurChmod;
                    }
                    else {
                        cout << "Unable to continue without Root permissions, run this program with \"sudo\" or as Root and try again.";
                    }
                    string archAurOutput = system("yay -S spicetify-cli");
                    cout << "\nConsole output: " << archAurOutput;
                }
                else {
                    cout << "Installing Spicetify..";
                    string archOutput = system("curl -fsSL https://raw.githubusercontent.com/spicetify/cli/main/install.sh | sh");
                    cout << "\nConsole output: " << archOutput;
                }
            }
            else if (choiceLinuxDistro == "3") {
                system("cls");
                cout << "Installing Spicetify..";
                string brewOutput = system("brew install spicetify-cli");
                cout << "\nConsole output: " << brewOutput;
            }
        }
        else if (choiceOS == "2") {
            system("cls");
            cout << "Installing Spicetify..";
            string winOutput = const char* command = "powershell.exe -Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"";
            cout << "\nConsole output: " << winOutput;
        }
        else if (choiceOS == "3") {
            cout << "Installing Spicetify..";
            string macOutput = system("curl -fsSL https://raw.githubusercontent.com/spicetify/cli/main/install.sh | sh");
            cout << "Console output: " << macOutput;
        }
    }
    else if (choiceInst == "n") {
        cout << "POV: You start a Spicetify installer, and chose not to install Spicetify";
        see you;
    }
}
