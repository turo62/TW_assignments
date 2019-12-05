using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanity_Archiver
{
    class Cypherer
    {
        internal string password = "1234";
        byte[] abc;
        byte[,] table;
        byte[] fileContent;
        //byte[] keys;

        internal void ByteGenerator()
        {
            abc = new byte[256];
            for (int i = 0; i < 256; i++)
                abc[i] = Convert.ToByte(i);

            table = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    table[i, j] = abc[(i + j) % 256];
                }
        }

        internal Boolean FileChecker(string filePath)
        {
            // Check input values
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist.");
                return false;
            }
            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password empty. Please enter your password");
                return false;
            }

            return true;
        }

        internal void CompleteCrypt(string fileName, bool crypted)
        {
            ByteGenerator();
            FileChecker(fileName);
            byte[] keys;

            try
            {
                fileContent = File.ReadAllBytes(fileName);
                byte[] passwordTmp = Encoding.ASCII.GetBytes(password);
                keys = new byte[fileContent.Length];

                for (int i = 0; i < fileContent.Length; i++)
                    keys[i] = passwordTmp[i % passwordTmp.Length];

                // Encrypt
                byte[] result = new byte[fileContent.Length];

                if (!crypted)
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueIndex = -1, keyIndex = -1;

                        for (int j = 0; j < 256; j++)
                            if (abc[j] == value)
                            {
                                valueIndex = j;
                                break;
                            }

                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }

                        result[i] = table[keyIndex, valueIndex];
                    }
                }
                // Decrypt
                else
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueIndex = -1, keyIndex = -1;

                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }

                        for (int j = 0; j < 256; j++)
                            if (table[keyIndex, j] == value)
                            {
                                valueIndex = j;
                                break;
                            }

                        result[i] = abc[valueIndex];
                    }
                }

                // Save result to new file with the same extension
                String fileExt = Path.GetExtension(fileName);
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Files (*" + fileExt + ") | *" + fileExt;

                if (sd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sd.FileName, result);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "File is in use. " +
                    "Close other program is using this file and try again.");
                return;
            }
        }
    }
}
