using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Caesar
{
    public partial class XORForm : System.Windows.Forms.Form
    {
        public XORForm()
        {
            InitializeComponent();
            saveMenuItem.Enabled = false;
            comboBoxAlphabet.SelectedItem = "English";
        }

        public bool RichTextBoxChanged = false;
        public string DocName = "";
        public bool IsSaved = false;
       
        private void Open(string OpenFileName)
        {

            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                StreamReader readFile = new StreamReader(OpenFileName);
                while (!readFile.EndOfStream)
                {
                    richTextBoxInput.Text = readFile.ReadToEnd();
                }
                readFile.Close();
                DocName = OpenFileName;
            }
        }
        private void Save(string SaveFileName)
        {
            if (SaveFileName == "")
            {
                return;
            }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                for (int i = 0; i < richTextBoxResult.Lines.Length; i++)
                {
                    sw.WriteLine(richTextBoxResult.Lines[i]);
                }
                sw.Flush();
                sw.Close();
                DocName = SaveFileName;
            }
        }
        private string Encryption(string inputText, string key, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string encryptText;
            char[] inputTextArray = inputText.ToCharArray();
            int index;

            if (typeAlphabet == "English")
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            }
            else if (typeAlphabet == "Ukrainian")
            {
                alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя".ToCharArray();
            }
            for (int j = 0; j < inputTextArray.Length; j++)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (inputTextArray[j] == alphabet[i])
                    {
                        index = (Array.IndexOf(alphabet, inputTextArray[j]) + Array.IndexOf(alphabet, key[j % key.Length])) % alphabet.Length;
                        if (char.IsLower(inputTextArray[j]))
                        {
                            inputTextArray[j] = char.ToLower(alphabet[index]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[index]);
                        }
                        break;
                    }
                }
            }
            encryptText = new string(inputTextArray);
            return encryptText;
        }
        private string VernamaEncryption(string inputText, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string encryptText;
            Random rnd = new Random();
            string vernamaKey = "";

            if (typeAlphabet == "English")
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            }
            else if (typeAlphabet == "Ukrainian")
            {
                alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя".ToCharArray();
            }

            for (int i = 0; i < inputText.Length; i++)
            {
                if (typeAlphabet == "English")
                {
                    vernamaKey += Convert.ToString(alphabet[rnd.Next(0, 26)]);
                }
                if (typeAlphabet == "Ukrainian")
                {
                    vernamaKey += Convert.ToString(alphabet[rnd.Next(0, 33)]);
                }
            }
            textBoxGama.Text = vernamaKey;
            byte[] bytesInputText = Encoding.Unicode.GetBytes(inputText);
            byte[] bytesKey = Encoding.Unicode.GetBytes(textBoxGama.Text);
            byte[] bytesEncryptText = new byte[bytesInputText.Length];
            for (int i = 0; i < bytesInputText.Length; i++)
            {
                bytesEncryptText[i] = (byte)(bytesInputText[i] ^ bytesKey[i]);
            }
            encryptText = Encoding.Unicode.GetString(bytesEncryptText);
            return encryptText;
        }
        private string Decryption(string inputText, string key, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string decryptText;
            char[] inputTextArray = inputText.ToCharArray();
            int index;

            if (typeAlphabet == "English")
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            }
            else if (typeAlphabet == "Ukrainian")
            {
                alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя".ToCharArray();
            }
            for (int j = 0; j < inputTextArray.Length; j++)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (inputTextArray[j] == alphabet[i])
                    {
                        index = (Array.IndexOf(alphabet, inputTextArray[j]) + alphabet.Length - (Array.IndexOf(alphabet, key[j % key.Length]) % alphabet.Length)) % alphabet.Length;
                        if (char.IsLower(inputTextArray[j]))
                        {
                            inputTextArray[j] = char.ToLower(alphabet[index]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[index]);
                        }
                        break;
                    }
                }
            }
            decryptText = new string(inputTextArray);
            return decryptText;
        }
        private string VernamaDecryption(string inputText)
        {
            string decryptText;
            byte[] bytesInputText = Encoding.Unicode.GetBytes(inputText);
            byte[] bytesKeys = Encoding.Unicode.GetBytes(textBoxGama.Text);
            byte[] bytesEncryptText = new byte[bytesInputText.Length];
            for (int i = 0; i < bytesInputText.Length; i++)
            {
                bytesEncryptText[i] = (byte)(bytesInputText[i] ^ bytesKeys[i]);
            }
            decryptText = Encoding.Unicode.GetString(bytesEncryptText);
            return decryptText;
        }
        private bool isValidText(string inputText, string typeAlphabet)
        {
            bool isValid;
            if (typeAlphabet == "English")
            {
                isValid = Regex.IsMatch(inputText, "^[.a-zA-Z,!?' ]*$");
                if (isValid)
                {
                    return true;
                }
            }
            else if (typeAlphabet == "Ukrainian")
            {
                isValid = Regex.IsMatch(inputText, "^[.А-ЩЬЮЯҐЄІЇа-щьюяґєії,!?' ]+$");
                if (isValid)
                {
                    return true;
                }
            }
            return false; 
        }
        private void ClearRichTextBox()
        {
            richTextBoxInput.Text = "";
            richTextBoxResult.Text = "";
        }
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            saveMenuItem.Enabled = false;
            if (RichTextBoxChanged == true)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes in the current file", "File", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {

                    saveMenuItem.PerformClick();
                    ClearRichTextBox();
                    this.Text = "Unnamed-XORCipher";

                }
                else if (dialogResult == DialogResult.No)
                {
                    ClearRichTextBox();
                    this.Text = "Unnamed-XORCipher";
                }
            }
            else
            {
                ClearRichTextBox();
                this.Text = "Unnamed-XORCipher";
            }
        }
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (RichTextBoxChanged == true)
            {
                if (richTextBoxResult.Text != String.Empty)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save changes in the current file", "Message", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        saveMenuItem.PerformClick();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult res;
                        res = openFileDialog1.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            Open(openFileDialog1.FileName);
                            RichTextBoxChanged = false;
                        }
                        DocName = openFileDialog1.FileName;
                        this.Text = Path.GetFileNameWithoutExtension(DocName) + "-XORCipher";
                    }
                }
                else
                {
                    DialogResult res;
                    res = openFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        Open(openFileDialog1.FileName);
                        RichTextBoxChanged = false;
                    }
                    DocName = openFileDialog1.FileName;
                    this.Text = Path.GetFileNameWithoutExtension(DocName) + "-XORCipher";
                }
            }
            else
            {
                DialogResult res;
                res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Open(openFileDialog1.FileName);
                }
                DocName = openFileDialog1.FileName;
                this.Text = Path.GetFileNameWithoutExtension(DocName) + "-XORCipher";
            }
            saveMenuItem.Enabled = true;
            IsSaved = true;
            RichTextBoxChanged = false;
        }
        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|Word Doucment (*.doc)|*.doc;*.docx|All files (*.*)|*.*";
            res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                Save(saveFileDialog1.FileName);
                RichTextBoxChanged = false;
                IsSaved = true;
            }
            DocName = saveFileDialog1.FileName;
            this.Text = Path.GetFileNameWithoutExtension(DocName) + "-XORCipher";
        }
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
             if (richTextBoxResult.Text != String.Empty)
             {
                if (string.IsNullOrEmpty(DocName))
                {
                    saveAsMenuItem.PerformClick();
                    MessageBox.Show("Do you want to save changes in the current file", "Message", MessageBoxButtons.YesNo);
                }
                else
                {
                    Save(DocName);
                    RichTextBoxChanged = false;
                    IsSaved = true;
                    saveMenuItem.Enabled = true;
                }
             }
        }
        private void encryptMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;
            string gama = textBoxGama.Text;
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();

            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isValidText(gama, alphabet) || gama.Length > text.Length)
            {
                MessageBox.Show("Key is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isValidText(text, alphabet) && isValidText(gama, alphabet) && gama.Length <= text.Length)
            {
                richTextBoxResult.Text = Encryption(text, gama, alphabet);
            }
            RichTextBoxChanged = true;
        }
        private void decryptMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;
            string gama = textBoxGama.Text;
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();
            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gama.Length > text.Length)
            {
                MessageBox.Show("Key is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isValidText(text, alphabet) && gama.Length <= text.Length)
            {
                richTextBoxResult.Text = Decryption(text, gama, alphabet);
            }
            RichTextBoxChanged = true;
        }
        private void vernamaEncryptMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();
            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isValidText(text, alphabet))
            {
                richTextBoxResult.Text = VernamaEncryption(text, alphabet);
            }
            RichTextBoxChanged = true;
        }
        private void vernamaDecryptMenuItem_Click(object sender, EventArgs e)
        {
            string encryptText = richTextBoxResult.Text;
            richTextBoxInput.Text = VernamaDecryption(encryptText);
            RichTextBoxChanged = true;
        }
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void printMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            else
            {
                MessageBox.Show("Print Cancelled");
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            float leftMargin = e.MarginBounds.Left;
            e.Graphics.DrawString(richTextBoxResult.Text, myFont, Brushes.Black, leftMargin, 150, new StringFormat());
        }
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsButtonNew":
                    newMenuItem.PerformClick();
                    break;
                case "tsButtonOpen":
                    openMenuItem.PerformClick();
                    break;
                case "tsButtonSave":
                    saveMenuItem.PerformClick();
                    break;
                default:
                    break;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved == true && RichTextBoxChanged == true)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes in " + this.DocName, "Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveMenuItem.PerformClick();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}