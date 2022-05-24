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
    public partial class CaesarForm : Form
    {
        public CaesarForm()
        {
            InitializeComponent();
            saveMenuItem.Enabled = false;
            comboBoxAlphabet.SelectedItem = "English";
            frequenceTable.Columns.Add("Character");
            frequenceTable.Columns.Add("Count");
            attackTable.Columns.Add("Key");
            attackTable.Columns.Add("Value");
        }

        public bool RichTextBoxChanged = false;
        public string DocName = "";
        public bool IsSaved = false;
        public DataTable frequenceTable = new DataTable();
        public DataTable attackTable = new DataTable();

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
        private string Encryption(string inputText, int key, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string encryptText;
            char[] inputTextArray = inputText.ToCharArray();

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
                        if (char.IsLower(inputTextArray[j]))
                        {
                            inputTextArray[j] = char.ToLower(alphabet[(i + key) % alphabet.Length]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[(i + key) % alphabet.Length]);
                        }
                        break;
                    }
                }
            }
            encryptText = new string(inputTextArray);
            return encryptText;
        }
        private string Decryption(string inputText, int key, string typeAlphabet)
        {
            string decryptText = "";
            if (typeAlphabet == "English")
            {
                decryptText = Encryption(inputText, 52 - key, typeAlphabet);
            }
            else if (typeAlphabet == "Ukrainian")
            {
                decryptText = Encryption(inputText, 66 - key, typeAlphabet);
            }
            return decryptText;
        }
        private bool isValidText(string inputText, string typeAlphabet)
        {
            bool isValid;
            if (typeAlphabet == "English")
            {
                isValid = Regex.IsMatch(inputText, "^[a-zA-Z ]+$");
                if (isValid)
                {
                    return true;
                }
            }
            else if (typeAlphabet == "Ukrainian")
            {
                isValid = Regex.IsMatch(inputText, "^[А-ЩЬЮЯҐЄІЇа-щьюяґєії ]+$");
                if (isValid)
                {
                    return true;
                }
            }
            return false; 
        }
        private bool isValidKey(int key, string typeAlphabet)
        {
            if (typeAlphabet == "English")
            {
                if (key < 26 && key >= 0)
                {
                    return true;
                }
            }
            else if (typeAlphabet == "Ukrainian")
            {
                if (key < 33 && key >= 0)
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
                    this.Text = "Unnamed-CeaserCipher";

                }
                else if (dialogResult == DialogResult.No)
                {
                    ClearRichTextBox();
                    this.Text = "Unnamed-CeaserCipher";
                }
            }
            else
            {
                ClearRichTextBox();
                this.Text = "Unnamed-CeaserCipher";
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
                        this.Text = Path.GetFileNameWithoutExtension(DocName) + "-CeaserCipher";
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
                    this.Text = Path.GetFileNameWithoutExtension(DocName) + "-CeaserCipher";
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
                this.Text = Path.GetFileNameWithoutExtension(DocName) + "-CeaserCipher";
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
            this.Text = Path.GetFileNameWithoutExtension(DocName) + "-CeaserCipher";
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
            int key = Convert.ToInt32(numericUpDownKey.Value);
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();

            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (!isValidKey(key, alphabet))
            //{
            //    MessageBox.Show("Key is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            if (isValidText(text, alphabet) /*&& isValidKey(key, alphabet)*/)
            {
                richTextBoxResult.Text = Encryption(text, key, alphabet);
            }
            RichTextBoxChanged = true;
        }
        private void decryptMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;
            int key = Convert.ToInt32(numericUpDownKey.Value);
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();
            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (!isValidKey(key, alphabet))
            //{
            //    MessageBox.Show("Key is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            if (isValidText(text, alphabet) /*&& isValidKey(key, alphabet)*/)
            {
                richTextBoxResult.Text = Decryption(text, key, alphabet);
            }
            RichTextBoxChanged = true;
        }
        private void frequencyTableMenuItem_Click(object sender, EventArgs e)
        {
            frequenceTable.Clear();
            if (!string.IsNullOrEmpty(richTextBoxResult.Text))
            {
                Dictionary<char, int> dictChar = new Dictionary<char, int>();
                foreach (char ch in richTextBoxResult.Text)
                {
                    if (dictChar.ContainsKey(ch))
                    {
                        dictChar[ch] += 1;
                    }
                    else
                    {
                        dictChar[ch] = 1;
                    }
                }
                foreach (var item in dictChar)
                {
                    if (!Char.IsWhiteSpace(item.Key))
                    {
                        DataRow row = frequenceTable.NewRow();
                        row[0] = item.Key;
                        row[1] = item.Value;
                        frequenceTable.Rows.Add(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrequenceTableBox frm = new FrequenceTableBox();
            frm.Show(this);
        }

        private void attackMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxResult.Text;
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();
            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            attackTable.Clear();
            if (!string.IsNullOrEmpty(text))
            {
                Dictionary<int, string> dictAttack = new Dictionary<int, string>();
                if (alphabet == "English")
                {
                    for (int key = 0; key < 26; ++key)
                    {
                        dictAttack.Add(key, Decryption(richTextBoxResult.Text, key, "English"));
                    }
                }
                else if (alphabet == "Ukrainian")
                {
                    for (int key = 0; key < 33; ++key)
                    {
                        dictAttack.Add(key, Decryption(richTextBoxResult.Text, key, "Ukrainian"));
                    }
                }
                foreach (var item in dictAttack)
                {
                    DataRow row = attackTable.NewRow();
                    row[0] = item.Key;
                    row[1] = item.Value;
                    attackTable.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AttackBox frm = new AttackBox();
            frm.Show(this);
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
    }
}