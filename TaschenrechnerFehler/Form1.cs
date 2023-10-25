using System;
using System.Windows.Forms;

namespace TaschenrechnerFehler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //CSHP09D
        //Die Methoden textBoxZahl1_TextChanged und textBoxZahl2_TextChanged wurden implementiert, 
        //um die Eingabe des Benutzers zu überwachen und die Methode TextBoxKontrolle aufzurufen. 
        //Diese Methoden reagieren auf Textänderungen in den TextBox-Steuerelementen textBoxZahl1 und textBoxZahl2.
        //Wenn der Benutzer den Text in einem dieser Textboxen ändert, 
        //wird die TextBoxKontrolle-Methode aufgerufen und das entsprechende Textbox-Steuerelement als Parameter übergeben.


        private void textBoxZahl1_TextChanged(object sender, EventArgs e)
        {
            TextBoxKontrolle(textBoxZahl1);
        }
        

        private void textBoxZahl2_TextChanged(object sender, EventArgs e)
        {
            TextBoxKontrolle(textBoxZahl2);
        }


        private void ButtonBerechnen_Click(object sender, EventArgs e)
        {
            float zahl1, zahl2, ergebnis = 0;
           
            
            zahl1 = Convert.ToSingle(textBoxZahl1.Text);
            
            zahl2 = Convert.ToSingle(textBoxZahl2.Text);

;
        
            if (radioButtonAddition.Checked == true)
                ergebnis = zahl1 + zahl2;
            if (radioButtonSubtraktion.Checked == true)
                ergebnis = zahl1 - zahl2;
            if (radioButtonMultiplikation.Checked == true)
                ergebnis = zahl1 * zahl2;
            if (radioButtonDivision.Checked == true)
                //CSHP09D
                //In diesem Codeabschnitt wird überprüft, ob der Benutzer die Option "Division" ausgewählt hat und dann versucht,
                //die Division zahl1 / zahl2 durchzuführen. Dieser Abschnitt enthält auch eine Try-Catch-Struktur,
                //um auf die Division durch Null zu reagieren.
                try
                {
                    ergebnis = zahl1 / zahl2;
                    throw new DivideByZeroException("zeroEx");
                }
                catch (DivideByZeroException fehler) when (fehler.Message == "zeroEx")
                {
                    MessageBox.Show("Division mit \"0\" ist nicht definiert!!!");
                    if (textBoxZahl1.Text == "0")
                    {
                        textBoxZahl1.Select();
                    }
                    else
                    {
                        textBoxZahl2.Select();
                    }
                }
                


            labelAnzeige.Text = Convert.ToString(ergebnis);
            
        }

        //CSHP09D
        //Die Methode TextBoxKontrolle ist die Hauptmethode für die Kontrolle der Benutzereingabe.
        public void TextBoxKontrolle(TextBox textBox)
        {
            try
            {
                float zahl = Convert.ToSingle(textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show($"Die Eingabe '{textBox.Text}' ist keine gültige Zahl. Bitte geben Sie eine numerische Zahl ein.", "Ungültige Eingabe");
                textBox.Select();
            }
        }

        private void ButtonBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
