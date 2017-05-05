using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Vigenere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string klarText = richTextBox1.Text;
            string Passwort = richTextBox3.Text;
            string Verschlüsselung = "";
            int j = 0;
            for (int i = 0; i < klarText.Length; i++)
            {
                // Voreinstellungen

                klarText = klarText.ToLower();
                Passwort = Passwort.ToLower();
                klarText = klarText.Replace(" ", "");
                Passwort = Passwort.Replace(" ", "");
                Regex.Replace(klarText, @"( |\r?\n)\1+.&", "");

                // Hauptfunktion Verschlüsselung

                if ((((klarText[i] + Passwort[j]) % 122) + 26) > 123)
                    Verschlüsselung += (char)((((klarText[i] + Passwort[j]) % 123) + 26) - 26);

                else Verschlüsselung += (char)(((klarText[i] + Passwort[j]) % 123) + 26);

                // Passwortindex j an Klartextlänge anpassen

                j = j + 1 == Passwort.Length ? 0 : j + 1;

                // Ausgabe in Textbox

                richTextBox2.Text = Verschlüsselung;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
                string Cipher = richTextBox2.Text;
                string Passwort = richTextBox3.Text;
                string Entschlüsselung = "";
                int j = 0;
                for (int i = 0; i < Cipher.Length; i++)
                {
                    // Voreinstellungen

                    Cipher = Cipher.ToLower();
                    Passwort = Passwort.ToLower();
                    Cipher = Cipher.Replace(" ", "");
                    Passwort = Passwort.Replace(" ", "");
                    Regex.Replace(Cipher, @"( |\r?\n)\1+.&", "");

                // Hauptfunktion Entschlüsselung
                if (((97 + (Cipher[i] - Passwort[j])) % 122) <= 96)
                    Entschlüsselung += (char)(((97 + (Cipher[i] - Passwort[j])) % 122) + 26);

                else if (((97 + (Cipher[i] - Passwort[j])) % 122) >= 123)

                    Entschlüsselung += (char)(((97 + (Cipher[i] - Passwort[j])) % 122) - 26);

                else Entschlüsselung += (char)((97 + (Cipher[i] - Passwort[j])) % 122);

                    // Passwortindex j an Klartextlänge anpassen

                    j = j + 1 == Passwort.Length ? 0 : j + 1;

                    // Ausgabe in Textbox       

                    richTextBox1.Text = Entschlüsselung;
                }
            }
    }
}
