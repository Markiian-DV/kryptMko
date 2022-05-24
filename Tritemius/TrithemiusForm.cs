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
    public partial class TrithemiusForm : System.Windows.Forms.Form
    {
        public TrithemiusForm()
        {
            InitializeComponent();
            saveMenuItem.Enabled = false;
            comboBoxAlphabet.SelectedItem = "English";
            frequenceTable.Columns.Add("Character");
            frequenceTable.Columns.Add("Count");
            textBoxGaslo.Visible = false;
            numericUpDownKey3.Visible = false;
        }

        public bool RichTextBoxChanged = false;
        public string DocName = "";
        public bool IsSaved = false;
        public DataTable frequenceTable = new DataTable();
        int length;
       
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
        private string EncryptionTwoDimensionalKey(string inputText, int keyOne, int keyTwo, string typeAlphabet)
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
                            inputTextArray[j] = char.ToLower(alphabet[(i + keyOne * j + keyTwo) % alphabet.Length]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[(i + keyOne * j + keyTwo) % alphabet.Length]);
                        }
                        break;
                    }
                }
            }
            encryptText = new string(inputTextArray);
            return encryptText;
        }
        private string EncryptionThreeDimensionalKey(string inputText, int keyOne, int keyTwo, int keyThree, string typeAlphabet)
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
                            inputTextArray[j] = char.ToLower(alphabet[(i + (keyOne * j*j) + (keyTwo * j) + keyThree) % alphabet.Length]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[(i + (keyOne * j*j) + (keyTwo * j) + keyThree) % alphabet.Length]);
                        }
                        break;
                    }
                }
            }
            encryptText = new string(inputTextArray);
            return encryptText;
        }
        private string EncryptionGaslo(string inputText, string gaslo, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string encryptText;
            char[] inputTextArray = inputText.ToCharArray();
            int key;
            int keyCounter = 0;

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
                key = Array.IndexOf(alphabet, gaslo[(keyCounter + gaslo.Length) % gaslo.Length]);
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (inputTextArray[j] == alphabet[i])
                    {
                        if (char.IsLower(inputTextArray[j]))
                        {
                            inputTextArray[j] = char.ToLower(alphabet[(i + key+1) % alphabet.Length]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[(i + key+1) % alphabet.Length]);
                        }
                        keyCounter += 1;
                        break;
                    }
                }
            }
            encryptText = new string(inputTextArray);
            return encryptText;
        }
        private string DecryptionTwoDimensionalKey(string inputText, int keyOne, int keyTwo, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string decryptText;
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
                            inputTextArray[j] = char.ToLower(alphabet[(i + alphabet.Length - (keyOne * j + keyTwo) % alphabet.Length) % alphabet.Length]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[(i + alphabet.Length - (keyOne * j + keyTwo) % alphabet.Length) % alphabet.Length]);
                        }
                        break;
                    }
                }
            }
            decryptText = new string(inputTextArray);
            return decryptText;
        }
        private string DecryptionThreeDimensionalKey(string inputText, int keyOne, int keyTwo, int keyThree, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string decryptText;
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
                            inputTextArray[j] = char.ToLower(alphabet[(i + alphabet.Length - (keyOne * j*j + keyTwo * j + keyThree) % alphabet.Length) % alphabet.Length]);
                        }
                        else
                        {
                            inputTextArray[j] = char.ToUpper(alphabet[(i + alphabet.Length - (keyOne * j*j + keyTwo * j + keyThree) % alphabet.Length) % alphabet.Length]);
                        }
                        break;
                    }
                }
            }
            decryptText = new string(inputTextArray);
            return decryptText;
        }
        private string DecryptionGaslo(string inputText, string gaslo, string typeAlphabet)
        {
            char[] alphabet = new char[0];
            string decryptText;
            char[] inputTextArray = inputText.ToCharArray();
            int key;
            int keyCounter = 0;

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
                key = Array.IndexOf(alphabet, gaslo[(keyCounter + gaslo.Length) % gaslo.Length]);
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (inputTextArray[j] == alphabet[i])
                    {
                        if (typeAlphabet == "English")
                        {
                            if (char.IsLower(inputTextArray[j]))
                            {
                                inputTextArray[j] = char.ToLower(alphabet[(i + (52 - (key + 1))) % alphabet.Length]);
                            }
                            else
                            {
                                inputTextArray[j] = char.ToUpper(alphabet[(i + (52 - (key + 1))) % alphabet.Length]);
                            }
                            keyCounter += 1;
                            break;
                        }
                        else if (typeAlphabet == "Ukrainian")
                        {
                            if (char.IsLower(inputTextArray[j]))
                            {
                                inputTextArray[j] = char.ToLower(alphabet[(i + (66 - (key + 1))) % alphabet.Length]);
                            }
                            else
                            {
                                inputTextArray[j] = char.ToUpper(alphabet[(i + (66 - (key + 1))) % alphabet.Length]);
                            }
                            keyCounter += 1;
                            break;
                        }
                    }
                }
            }
            decryptText = new string(inputTextArray);
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
                    this.Text = "Unnamed-TrithemiusCipher";

                }
                else if (dialogResult == DialogResult.No)
                {
                    ClearRichTextBox();
                    this.Text = "Unnamed-TrithemiusCipher";
                }
            }
            else
            {
                ClearRichTextBox();
                this.Text = "Unnamed-TrithemiusCipher";
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
                        this.Text = Path.GetFileNameWithoutExtension(DocName) + "-TrithemiusCipher";
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
                    this.Text = Path.GetFileNameWithoutExtension(DocName) + "-TrithemiusCipher";
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
                this.Text = Path.GetFileNameWithoutExtension(DocName) + "-TrithemiusCipher";
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
            this.Text = Path.GetFileNameWithoutExtension(DocName) + "-TrithemiusCipher";
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
            int keyOne = Convert.ToInt32(numericUpDownKey1.Value);
            int keyTwo = Convert.ToInt32(numericUpDownKey2.Value);
            int keyThree = Convert.ToInt32(numericUpDownKey3.Value);
            string gaslo = textBoxGaslo.Text;
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();

            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioButtonTwoDimensionalKey.Checked)
            {
                if (isValidText(text, alphabet))
                {
                    richTextBoxResult.Text = EncryptionTwoDimensionalKey(text, keyOne, keyTwo, alphabet);
                }
            }
            else if (radioButtonThreeDimensionalKey.Checked)
            {
                if (isValidText(text, alphabet))
                {
                    richTextBoxResult.Text = EncryptionThreeDimensionalKey(text, keyOne, keyTwo, keyThree, alphabet);
                }
            }
            else if (radioButtonGaslo.Checked)
            {
                if (!isValidText(gaslo, alphabet) || gaslo.Length > text.Length)
                {
                    MessageBox.Show("Key is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (isValidText(text, alphabet) && gaslo.Length <= text.Length)
                {
                    richTextBoxResult.Text = EncryptionGaslo(text, gaslo, alphabet);
                }
            }

            RichTextBoxChanged = true;
        }
        private void decryptMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;
            int keyOne = Convert.ToInt32(numericUpDownKey1.Value);
            int keyTwo = Convert.ToInt32(numericUpDownKey2.Value);
            int keyThree = Convert.ToInt32(numericUpDownKey3.Value);
            string gaslo = textBoxGaslo.Text;
            string alphabet = comboBoxAlphabet.SelectedItem.ToString();
            if (!isValidText(text, alphabet))
            {
                MessageBox.Show("Text is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioButtonTwoDimensionalKey.Checked)
            {
                if (isValidText(text, alphabet))
                {
                    richTextBoxResult.Text = DecryptionTwoDimensionalKey(text, keyOne, keyTwo, alphabet);
                }
            }
            else if (radioButtonThreeDimensionalKey.Checked)
            {
                if (isValidText(text, alphabet))
                {
                    richTextBoxResult.Text = DecryptionThreeDimensionalKey(text, keyOne, keyTwo, keyThree, alphabet);
                }
            }
            else if (radioButtonGaslo.Checked)
            {
                if (!isValidText(gaslo, alphabet) || gaslo.Length > text.Length)
                {
                    MessageBox.Show("Key is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isValidText(text, alphabet) && gaslo.Length <= text.Length)
                {
                    richTextBoxResult.Text = DecryptionGaslo(text, gaslo, alphabet);
                }
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
            string inputText = richTextBoxInput.Text;
            string encryptText = richTextBoxResult.Text;
            string typeAlphabet = comboBoxAlphabet.SelectedItem.ToString();
            string attackResult = "";

            if (!string.IsNullOrEmpty(inputText) || !string.IsNullOrEmpty(encryptText))
            {
                if (radioButtonTwoDimensionalKey.Checked)
                {
                    string[] attackResults = (from keyOne in Enumerable.Range(1, 10)
                                              from keyTwo in Enumerable.Range(1, 10)
                                              let keys = "Key one: " + keyOne.ToString() + "\n" + "Key two: " + keyTwo.ToString()
                                              let encrypt = EncryptionTwoDimensionalKey(inputText, keyOne, keyTwo, typeAlphabet)
                                              where string.Equals(encrypt, encryptText)
                                              select keys).ToArray();
                    attackResult = string.Join("\n", attackResults);
                }
                else if (radioButtonThreeDimensionalKey.Checked)
                {
                    string[] attackResults = (from keyOne in Enumerable.Range(1, 10)
                                              from keyTwo in Enumerable.Range(1, 10)
                                              from keyThree in Enumerable.Range(1, 10)
                                              let keys = "Key one: " + keyOne.ToString() + "\n" + "Key two: " + keyTwo.ToString() + "\n" + "Key three: " + keyThree.ToString()
                                              let encrypt = EncryptionThreeDimensionalKey(inputText, keyOne, keyTwo, keyThree, typeAlphabet)
                                              where string.Equals(encrypt, encryptText)
                                              select keys).ToArray();
                    attackResult = string.Join("\n", attackResults);
                }
                else if (radioButtonGaslo.Checked)
                {
                    attackResult = "Key: ";
                    string alphabet = "";
                    if (typeAlphabet == "English")
                    {
                        alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    }
                    else if (typeAlphabet == "Ukrainian")
                    {
                        alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
                    }
                    if (inputText.Length == encryptText.Length)
                    {
                        for (int i = 0; i < encryptText.Length; i++)
                        {
                            if (char.IsLetter(encryptText[i]))
                            {
                                foreach (char ch in alphabet)
                                {
                                    if (encryptText[i].ToString() == EncryptionGaslo(inputText[i].ToString(), ch.ToString(), typeAlphabet))
                                    {
                                        attackResult += ch;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Length of the texts is different!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    attackResult = new string(attackResult.Take(length+5).ToArray());
                }
                MessageBox.Show(attackResult, "Attack");
            }
            else
            {
                MessageBox.Show("Text is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            AboutBox frm = new AboutBox();
            frm.Show();
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
        private void radioButtonTwoDimensionalKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxGaslo.Visible = false;
            numericUpDownKey1.Visible = true;
            numericUpDownKey2.Visible = true;
            numericUpDownKey3.Visible = false;
        }
        private void radioButtonThreeDimensionalKey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxGaslo.Visible = false;
            numericUpDownKey1.Visible = true;
            numericUpDownKey2.Visible = true;
            numericUpDownKey3.Visible = true;
        }
        private void radioButtonGaslo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxGaslo.Visible = true;
            numericUpDownKey1.Visible = false;
            numericUpDownKey2.Visible = false;
            numericUpDownKey3.Visible = false;
        }

        private void textBoxGaslo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGaslo.Text.Length != 0)
            {
                length = textBoxGaslo.Text.Length;
            }
        }
    }
}