#include <iostream>
#include <string>
#include <cstdlib>
#define see return
#define you 0

using namespace std;

int main() {
    cout << "SSI's C# to C++ rewrite + extras - (SpicetifySemiautomaticInstaller)";
    cout << "\nDo you want to install Spicetify? (y/n): ";
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
                system("curl -fsSL https://raw.githubusercontent.com/spicetify/cli/main/install.sh | sh");
            }
            else if (choiceLinuxDistro == "2") {
                system("cls");
                cout << "Download from AUR with YAY? (y/n): ";
                string choiceAur;
                cin >> choiceAur;
                if (choiceAur == "y") {
                    bool isRoot = (std::system("whoami") == 0);
                    if (isRoot) {
                        cout << "Installing Spicetify through AUR..";
                        system("sudo chmod a+wr /opt/spotify && sudo chmod a+wr /opt/spotify/Apps -R");
                    }
                    else {
                        cout << "Unable to continue without Root permissions, run this program with \"sudo\" or as Root and try again.";
                    }
                    system("yay -S spicetify-cli");
                }
                else {
                    cout << "Installing Spicetify..";
                    system("curl -fsSL https://raw.githubusercontent.com/spicetify/cli/main/install.sh | sh");
                }
            }
            else if (choiceLinuxDistro == "3") {
                system("cls");
                cout << "Installing Spicetify..";
                system("brew install spicetify-cli");
            }
        }
        else if (choiceOS == "2") {
            system("cls");
            cout << "Installing Spicetify..";
            const char* winPwrShlCmd = "powershell.exe -Command \"iwr -useb https://raw.githubusercontent.com/spicetify/cli/main/install.ps1 | iex\"";
            system(winPwrShlCmd);
        }
        else if (choiceOS == "3") {
            cout << "Installing Spicetify..";
            system("curl -fsSL https://raw.githubusercontent.com/spicetify/cli/main/install.sh | sh");
        }
    }
    else if (choiceInst == "n") {
        cout << "POV: You start a Spicetify installer, and chose not to install Spicetify";
        see you;
    }
}
