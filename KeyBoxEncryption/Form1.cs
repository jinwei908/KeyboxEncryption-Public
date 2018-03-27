using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyBoxEncryption
{
    public partial class Form1 : Form
    {
        // Matrices are matrix1[COLUMN, ROW]
        private enum EncryptionState
        {
            None,
            Box1,
            Box2,
            Box3,
            Box4,
            KeyPosTable,
            ConvertPlainTextToBinary,
            Matrix1,
            Matrix2,
            SummationOfMatrix,
            Tranpose,
            Multiply,
            MultiplyElements,
            ConvertToBinary,
            Encrypt,
            EncrpytRest
        }

        private int[,] box1;
        private int[,] box2;
        private int[,] box3;
        private int[,] box4;
        private int[] keyPosTable;
        

        private Int64 integerKey;

        private string plainPassword;
        private string plainText;
        private string binaryPlainText;
        private EncryptionState eState;

        //matrices
        private int[,] matrix1;
        private int[,] matrix2;
        private string mData1;
        private string mData2;

        private int noOfIt;
        private int numberOfMatrixCreated;
        private int numberOfBinaryIterations;
        private int noOfItRequired;
        private int noOfLastOffset;
        private int itIndex;
        private int permutationDeterminer;

        //Controls
        private int permutationIndex;
        private int[,] rawMultipledMatrix;
        private double rawMultiplied;
        private string binaryKey;
        private List<double> listOfKeys;
        

        private string binaryStringToBeIterated;

        //ciper handlers
        private string cipherBinary;
        private string cipherText;

        //Logs
        private string popupLogText;
        private PopupLog popupLog;
        private string repeatedIterations;
        private string increased;

        public Form1()
        {
            InitializeComponent();

            increased = "";
            cipher.Visible = false;
            listOfKeys = new List<double>();
            binaryStringToBeIterated = "";
            cipherText = "";
            cipherBinary = "";
            numberOfMatrixCreated = 0;
            eState = EncryptionState.Box1;
            repeatedIterations = "";
            keyPos.MaximumSize = new Size(465, 0);
            keyPos.AutoSize = true;
            keyPos.Visible = false;
            noOfIt = 1;
            numberOfMatrixCreated = 0;
            numberOfBinaryIterations = 0;
            itIndex = 0;
            permutationDeterminer = 0;
            noOfItRequired = 0;
            noOfLastOffset = 0;
            popupLogText = "";
            tableMatrix1.Visible = false;
            tableMatrix2.Visible = false;

            eState = EncryptionState.Box1;
            //take the password
            plainPassword = passwordText.Text;
            plainText = plainCipherText.Text;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            popupLog = null;
            increased = "";
            listOfKeys = new List<double>();
            binaryStringToBeIterated = "";
            cipherText = "";
            cipherBinary = "";
            numberOfMatrixCreated = 0;
            eState = EncryptionState.Box1;
            repeatedIterations = "";
            keyPos.MaximumSize = new Size(465, 0);
            keyPos.AutoSize = true;
            keyPos.Visible = false;
            noOfIt = 1;
            numberOfMatrixCreated = 0;
            numberOfBinaryIterations = 0;
            itIndex = 0;
            permutationDeterminer = 0;
            noOfItRequired = 0;
            noOfLastOffset = 0;
            popupLogText = "";
            tableMatrix1.Visible = false;
            tableMatrix2.Visible = false;

            eState = EncryptionState.Box1;
            //take the password
            plainPassword = passwordText.Text;
            plainText = plainCipherText.Text;

            if (plainPassword.Length < 12)
            {
                logText.Text = "Please specify a password with at least 12 characters.";
                return;
            }
            
            //logText.Text = KeyExpansionHandler.GetBox1(plainPassword);
            
            box1 = KeyExpansionHandler.GetBox1(plainPassword);
            logText.Text = "Box 1 Table";
            for (int i = 0; i < 15; i++)
            {
                for (int v = 0; v < 15; v++)
                {
                    Label objlabel = new Label();
                    objlabel.Text = box1[i, v].ToString();
                    tableLayoutPanel1.Controls.Add(objlabel, i, v);
                }
            }
            keyPos.Visible = false;
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            popupLog = null;
            increased = "";
            listOfKeys = new List<double>();
            binaryStringToBeIterated = "";
            cipherText = "";
            cipherBinary = "";
            numberOfMatrixCreated = 0;
            eState = EncryptionState.Box1;
            repeatedIterations = "";
            keyPos.MaximumSize = new Size(465, 0);
            keyPos.AutoSize = true;
            keyPos.Visible = false;
            noOfIt = 1;
            numberOfMatrixCreated = 0;
            numberOfBinaryIterations = 0;
            itIndex = 0;
            permutationDeterminer = 0;
            noOfItRequired = 0;
            noOfLastOffset = 0;
            popupLogText = "";
            tableMatrix1.Visible = false;
            tableMatrix2.Visible = false;

            eState = EncryptionState.Box1;
            //take the password
            plainPassword = passwordText.Text;
            plainText = plainCipherText.Text;


            if (plainPassword.Length < 12)
            {
                logText.Text = "Please specify a password with at least 12 characters.";
                return;
            }
            //Reset

            cipherText = plainCipherText.Text;
            
            plainPassword = passwordText.Text;
            plainText = plainCipherText.Text;
            DecryptCipher();
        }

        private void stepThrough_Click(object sender, EventArgs e)
        {
            switch (eState)
            {
                case EncryptionState.Box1:
                    //go to Box2
                    logText.Text = "Box 2 Table";
                    tableLayoutPanel1.Controls.Clear();
                    box2 = KeyExpansionHandler.GetBox2(plainPassword);
                    for (int i = 0; i < 15; i++)
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = box2[i, v].ToString();
                            tableLayoutPanel1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Box2;
                    break;

                case EncryptionState.Box2:
                    //goto Box3
                    logText.Text = "Box 3 Table";
                    tableLayoutPanel1.Controls.Clear();
                    box3 = KeyExpansionHandler.GetBox3(plainPassword);
                    for (int i = 0; i < 15; i++)
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = box3[i, v].ToString();
                            tableLayoutPanel1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Box3;
                    break;

                case EncryptionState.Box3:
                    //goto Box 4
                    logText.Text = "Box 4 Table";
                    tableLayoutPanel1.Controls.Clear();
                    box4 = KeyExpansionHandler.GetBox4(plainPassword);
                    for (int i = 0; i < 15; i++)
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = box4[i, v].ToString();
                            tableLayoutPanel1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Box4;
                    break;

                case EncryptionState.Box4:
                    //get the keypos table
                    tableLayoutPanel1.Dispose();
                    keyPosTable = KeyExpansionHandler.GetKeyPos(plainPassword);
                    string keyText = "";
                    int lines = 1;
                    for (int i = 0; i < keyPosTable.Length; i++)
                    {
                        keyText += keyPosTable[i].ToString() + " ";
                        if (keyText.Length > 60 && lines == 1)
                        {
                            lines++;
                            keyText += Environment.NewLine;
                        }
                        else if (keyText.Length > 120 && lines == 2)
                        {
                            lines++;
                            keyText += Environment.NewLine;
                        }
                    }
                    keyPos.Visible = true;
                    keyPos.Text = keyText;
                    eState = EncryptionState.KeyPosTable;
                    break;

                case EncryptionState.KeyPosTable:
                    
                    logText.Text = "Converting Plain Text To Binary";

                    //convert
		            byte[] arr = System.Text.Encoding.Unicode.GetBytes(plainText);
                    //logText.Text += Environment.NewLine + System.Text.Encoding.Unicode.GetBytes(plainText).Length + " " + System.Text.Encoding.Unicode.GetBytes(plainText).Length;
		
		            StringBuilder sb = new StringBuilder();
		            StringBuilder binaryStringBuilder = new StringBuilder();
		            foreach (byte b in arr)
		            {
		                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8,'0'));
		            }

                    binaryPlainText = binaryStringBuilder.ToString();
                    keyPos.Text = binaryPlainText;
                    if (keyPos.Text.Length > 600)
                    {
                        keyPos.Text = keyPos.Text.Substring(0, 600);
                    }
                    eState = EncryptionState.ConvertPlainTextToBinary;
                    noOfItRequired = Convert.ToInt32(Math.Floor((float)(binaryPlainText.Length / 64)));
                    noOfLastOffset = binaryPlainText.Length % 64;
                    break;

                case EncryptionState.ConvertPlainTextToBinary:
                    keyPos.Visible = false;
                    tableMatrix1.Visible = true;
                    //get matrix 1
                    logText.Text = "Getting matrix 1";
                    matrix1 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    popupLogText += "First Iteration Matrix Pos: " + KeyExpansionHandler.GetMatrixData(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    itIndex++;
                    numberOfMatrixCreated++;
                    if (itIndex >= keyPosTable.Length-1)
                    {
                        noOfIt++;
                        itIndex = 0;
                        if (noOfIt == 5)
                        {
                             List<int> keyPosList = keyPosTable.ToList<int>();
                            keyPosList.Reverse();
                            keyPosTable = keyPosList.ToArray();
                            
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = matrix1[i, v].ToString();
                            tableMatrix1.Controls.Add(objlabel, i, v);
                        }
                    }
                    tableMatrix1.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                    
                    eState = EncryptionState.Matrix1;
                    break;

                case EncryptionState.Matrix1:
                    tableMatrix2.Visible = true;
                    //get matrix 2
                    logText.Text = "Getting matrix 2";
                    matrix2 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    popupLogText += "First Iteration Matrix Pos: " + KeyExpansionHandler.GetMatrixData(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    itIndex++;
                    numberOfMatrixCreated++;
                    if (itIndex >= keyPosTable.Length-1)
                    {
                        noOfIt++;
                        itIndex = 0;
                        if (noOfIt == 5)
                        {
                            List<int> keyPosList = keyPosTable.ToList<int>();
                            keyPosList.Reverse();
                            keyPosTable = keyPosList.ToArray();
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = matrix2[i, v].ToString();
                            tableMatrix2.Controls.Add(objlabel, i, v);
                        }
                    }
                    tableMatrix2.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                    eState = EncryptionState.Matrix2;
                    break;

                case EncryptionState.Matrix2:
                    //sum up
                    logText.Text = "Summing up all elements of matrices";
                    int summation = matrix1[0, 0] + matrix1[0, 1] + matrix1[1, 0] + matrix1[1, 1] + matrix2[0, 0] + matrix2[0, 1] + matrix2[1, 0] + matrix2[1, 1];
                    permutationDeterminer = summation % 2;
                    
                    logText.Text +=Environment.NewLine + "Permutation Determiner is: " + summation.ToString() + " " + (permutationDeterminer == 0 ? "even - Tranposing M2" : "odd - Tranposing M1");
                    
                    eState = EncryptionState.SummationOfMatrix;
                    
                    break;

                case EncryptionState.SummationOfMatrix:
                    keyPos.Visible = false;
                    
                    if (permutationDeterminer == 0)
                    {
                        logText.Text = "M2 Transposed";
                        //even number transpose M2 else transposse M1
                        int[,] tempMatrix = new int[2, 2];
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                tempMatrix[i, v] = matrix2[i, v];
                            }
                        }
                        matrix2 = new int[2, 2];
                        matrix2[0, 0] = tempMatrix[0, 0];
                        matrix2[1, 0] = tempMatrix[0, 1];
                        matrix2[0, 1] = tempMatrix[1, 0];
                        matrix2[1, 1] = tempMatrix[1, 1];
                        tableMatrix2.Controls.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                Label objlabel = new Label();
                                objlabel.Text = matrix2[i, v].ToString();
                                tableMatrix2.Controls.Add(objlabel, i, v);
                            }
                        }
                    }
                    else
                    {
                        logText.Text = "M1 Transposed" + Environment.NewLine + "Proceeding to multiply both matrix";
                        int[,] tempMatrix = new int[2, 2];
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                tempMatrix[i, v] = matrix1[i, v];
                            }
                        }
                        matrix1 = new int[2, 2];
                        matrix1[0, 0] = tempMatrix[0, 0];
                        matrix1[1, 0] = tempMatrix[0, 1];
                        matrix1[0, 1] = tempMatrix[1, 0];
                        matrix1[1, 1] = tempMatrix[1, 1];
                        tableMatrix1.Controls.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                Label objlabel = new Label();
                                objlabel.Text = matrix1[i, v].ToString();
                                tableMatrix1.Controls.Add(objlabel, i, v);
                            }
                        }
                    }
                    eState = EncryptionState.Tranpose;
                    break;

                case EncryptionState.Tranpose:
                    //Multiply the Matrixes
                    tableMatrix1.Size = new Size(125, 60);
                    logText.Text = "Multiplied Both Matrix " + Environment.NewLine + " Proceeding to multiply all elemnts";

                    tableMatrix1.Controls.Clear();
                    tableMatrix2.Controls.Clear();

                    //table 1 sumed

                    rawMultipledMatrix = new int[2, 2];
                    rawMultipledMatrix[0, 0] = (matrix1[0, 0] * matrix2[0, 0]) + (matrix1[1,0] * matrix2[0,1]);
                    rawMultipledMatrix[1, 0] = (matrix1[0, 0] * matrix2[1, 0]) + (matrix1[1,0] * matrix2[1,1]);
                    rawMultipledMatrix[0, 1] = (matrix1[0, 1] * matrix2[0, 0]) + (matrix1[1, 1] * matrix2[0, 1]);
                    rawMultipledMatrix[1, 1] = (matrix1[0, 1] * matrix2[1, 0]) + (matrix1[1, 1] * matrix2[1, 1]);

                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = rawMultipledMatrix[i, v].ToString();
                            tableMatrix1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Multiply;
                    break;

                case EncryptionState.Multiply:
                    //multiply elements
                    tableMatrix1.Visible = false;
                    tableMatrix2.Visible = false;
                    tableMatrix1.Controls.Clear();
                    logText.Text = "Multiplying all elements of matrix";
                    keyPos.Visible = true;
                    keyPos.Text = "Multiplying: " + rawMultipledMatrix[0, 0].ToString() + " * " + rawMultipledMatrix[0, 1].ToString() + " * " + rawMultipledMatrix[1, 0] + " * " + rawMultipledMatrix[1, 1] + " = ";
                    rawMultiplied = rawMultipledMatrix[0, 0];
                    rawMultiplied *= rawMultipledMatrix[0, 1];
                    rawMultiplied *= rawMultipledMatrix[1, 0];
                    rawMultiplied *= rawMultipledMatrix[1, 1];
                    keyPos.Text += rawMultiplied.ToString();
                    eState = EncryptionState.MultiplyElements;
                    break;

                case EncryptionState.MultiplyElements:

                    //convert to binary 64-bit
                    logText.Text = "Converting number to key number to binary";
                    byte[] numberArray = BitConverter.GetBytes(rawMultiplied);
                    StringBuilder stringB = new StringBuilder();
                    foreach (byte b in numberArray)
		            {
                        stringB.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
		            }
                    keyPos.Text = stringB.ToString() + " " + stringB.ToString().Length.ToString();
                    binaryKey = stringB.ToString();

                    

                    eState = EncryptionState.ConvertToBinary;
                    break;

                case EncryptionState.ConvertToBinary:
                    //encrypt one portion
                    binaryStringToBeIterated = binaryPlainText.Substring(0, 64);
                    //convert to string;
                    string encryptedBinary = "";

                    List<byte> encryptedBytes = new List<byte>();
                    for (int i = 0; i < binaryStringToBeIterated.Length; i += 8)
                    {
                        encryptedBytes.Add(Convert.ToByte(binaryStringToBeIterated.Substring(i, 8), 2));
		            }
                    logText.Text = "Encrypting one portion.";

                    keyPos.Text = "Performing bitwise operation XOR on two binaries- Plain Text Portion: " + binaryStringToBeIterated + Environment.NewLine + "Matrix Key Portion: " + binaryKey;
                    keyPos.Text += Environment.NewLine + "Encrypting Plain Text Portion: " + Encoding.Unicode.GetString(encryptedBytes.ToArray()) + Environment.NewLine + "Ciper Text: ";

                    
                    for (int i = 0; i < binaryKey.Length; i++)
                    {
                        encryptedBinary += ((binaryKey[i] == '1' ? true : false) ^ (binaryStringToBeIterated[i] == '1' ? true : false) == true ? "1" : "0");
                    }

                    //Encrption
                    cipherBinary += encryptedBinary;
                    List<byte> encryptedBytes1 = new List<byte>();
                    for (int i = 0; i < encryptedBinary.Length; i += 8)
                    {
                        encryptedBytes1.Add(Convert.ToByte(encryptedBinary.Substring(i, 8), 2));
                    }
                    //perform
                   

                    //convert to text to see
                    

                    cipherText = Encoding.Unicode.GetString(encryptedBytes1.ToArray()).ToString();
                    //loop through cipher text
                    
                    keyPos.Text += cipherText + " Binary: " + encryptedBinary;

                    listOfKeys.Add(rawMultiplied);

                    // end test
                    cipher.Text = cipherText;
                    numberOfBinaryIterations++;
                    
                    eState = EncryptionState.Encrypt;
                    break;

                case EncryptionState.Encrypt:
                    //encrypt the rest
                    if (numberOfBinaryIterations <= noOfItRequired)
                    {
                        EncryptRest();
                    }
                    eState = EncryptionState.EncrpytRest;
                    break;
                    
            }
        }



        private void DecryptCipher()
        {

            box1 = KeyExpansionHandler.GetBox1(plainPassword);
             box2 = KeyExpansionHandler.GetBox2(plainPassword);    
             box3 = KeyExpansionHandler.GetBox3(plainPassword);
             box4 = KeyExpansionHandler.GetBox4(plainPassword); 
             keyPosTable = KeyExpansionHandler.GetKeyPos(plainPassword);
            keyPos.Text = "";
            
            StringBuilder sb = new StringBuilder();
            foreach (byte b1 in Encoding.Unicode.GetBytes(cipherText))
            {
                sb.Append((Convert.ToString(b1, 2).PadLeft(8, '0')));
                
            }
            binaryPlainText = sb.ToString();
            noOfItRequired = Convert.ToInt32(Math.Floor((float)(binaryPlainText.Length / 64)));
            noOfLastOffset = binaryPlainText.Length % 64;
            popupLogText += "NoOfIt: " + noOfItRequired + " " + cipherText.Length + " " + binaryPlainText.Length + Environment.NewLine;
            plainText = "";
            DecryptingCipher();
            
        }

        private void GetFirstKey()
        {

            //go to Box2
            logText.Text = "Box 1 Table";
            tableLayoutPanel1.Controls.Clear();
            box1 = KeyExpansionHandler.GetBox1(plainPassword);
            for (int i = 0; i < 15; i++)
            {
                for (int v = 0; v < 15; v++)
                {
                    Label objlabel = new Label();
                    objlabel.Text = box1[i, v].ToString();
                    tableLayoutPanel1.Controls.Add(objlabel, i, v);
                }
            }
            eState = EncryptionState.Box1;

                    //go to Box2
                    logText.Text = "Box 2 Table";
                    tableLayoutPanel1.Controls.Clear();
                    box2 = KeyExpansionHandler.GetBox2(plainPassword);
                    for (int i = 0; i < 15; i++)
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = box2[i, v].ToString();
                            tableLayoutPanel1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Box2;
                    
                    //goto Box3
                    logText.Text = "Box 3 Table";
                    tableLayoutPanel1.Controls.Clear();
                    box3 = KeyExpansionHandler.GetBox3(plainPassword);
                    for (int i = 0; i < 15; i++)
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = box3[i, v].ToString();
                            tableLayoutPanel1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Box3;
                 
                    //goto Box 4
                    logText.Text = "Box 4 Table";
                    tableLayoutPanel1.Controls.Clear();
                    box4 = KeyExpansionHandler.GetBox4(plainPassword);
                    for (int i = 0; i < 15; i++)
                    {
                        for (int v = 0; v < 15; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = box4[i, v].ToString();
                            tableLayoutPanel1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Box4;
                
                    //get the keypos table
                    tableLayoutPanel1.Dispose();
                    keyPosTable = KeyExpansionHandler.GetKeyPos(plainPassword);
                    string keyText = "";
                    int lines = 1;
                    for (int i = 0; i < keyPosTable.Length; i++)
                    {
                        keyText += keyPosTable[i].ToString() + " ";
                        if (keyText.Length > 60 && lines == 1)
                        {
                            lines++;
                            keyText += Environment.NewLine;
                        }
                        else if (keyText.Length > 120 && lines == 2)
                        {
                            lines++;
                            keyText += Environment.NewLine;
                        }
                    }
                    keyPos.Visible = true;
                    keyPos.Text = keyText;
                    eState = EncryptionState.KeyPosTable;
                  

                
                    
                    logText.Text = "Converting Plain Text To Binary";

                    //convert
		            byte[] arr = System.Text.Encoding.Unicode.GetBytes(plainText);
                    //logText.Text += Environment.NewLine + System.Text.Encoding.Unicode.GetBytes(plainText).Length + " " + System.Text.Encoding.Unicode.GetBytes(plainText).Length;
		
		            StringBuilder sb = new StringBuilder();
		            StringBuilder binaryStringBuilder = new StringBuilder();
		            foreach (byte b in arr)
		            {
		                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8,'0'));
		            }

                    binaryPlainText = binaryStringBuilder.ToString();
                    keyPos.Text = binaryPlainText;
                    eState = EncryptionState.ConvertPlainTextToBinary;
                    noOfItRequired = Convert.ToInt32(Math.Floor((float)(binaryPlainText.Length / 64)));
                    noOfLastOffset = binaryPlainText.Length % 64;
                    

               
                    keyPos.Visible = false;
                    tableMatrix1.Visible = true;
                    //get matrix 1
                    logText.Text = "Getting matrix 1";
                    matrix1 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    //itIndex++;
                    //numberOfMatrixCreated++;
                    //if (itIndex >= keyPosTable.Length)
                    //{
                    //    noOfIt++;
                    //    itIndex = 0;
                    //    if (noOfIt == 5)
                    //    {
                    //        keyPosTable.ToList<int>();
                    //    }
                    //}
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    for (int v = 0; v < 2; v++)
                    //    {
                    //        Label objlabel = new Label();
                    //        objlabel.Text = matrix1[i, v].ToString();
                    //        tableMatrix1.Controls.Add(objlabel, i, v);
                    //    }
                    //}
                    eState = EncryptionState.Matrix1;
                    

                
                    tableMatrix2.Visible = true;
                    //get matrix 2
                    logText.Text = "Getting matrix 2";
                    matrix2 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    itIndex++;
                    numberOfMatrixCreated++;
                    if (itIndex >= keyPosTable.Length-1)
                    {
                        noOfIt++;
                        itIndex = 0;
                        if (noOfIt == 5)
                        {
                            List<int> keyPosList = keyPosTable.ToList<int>();
                            keyPosList.Reverse();
                            keyPosTable = keyPosList.ToArray();
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = matrix2[i, v].ToString();
                            tableMatrix2.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Matrix2;
                    
               
                    //sum up
                    logText.Text = "Summing up all elements of matrices";
                    int summation = matrix1[0, 0] + matrix1[0, 1] + matrix1[1, 0] + matrix1[1, 1] + matrix2[0, 0] + matrix2[0, 1] + matrix2[1, 0] + matrix2[1, 1];
                    permutationDeterminer = summation % 2;
                    
                    logText.Text +=Environment.NewLine + "Permutation Determiner is: " + summation.ToString() + " " + (permutationDeterminer == 0 ? "even - Tranposing M2" : "odd - Tranposing M1");
                    
                    eState = EncryptionState.SummationOfMatrix;
                    
                    

               
                    keyPos.Visible = false;
                    
                    if (permutationDeterminer == 0)
                    {
                        logText.Text = "M2 Transposed";
                        //even number transpose M2 else transposse M1
                        int[,] tempMatrix = new int[2, 2];
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                tempMatrix[i, v] = matrix2[i, v];
                            }
                        }
                        matrix2 = new int[2, 2];
                        matrix2[0, 0] = tempMatrix[0, 0];
                        matrix2[1, 0] = tempMatrix[0, 1];
                        matrix2[0, 1] = tempMatrix[1, 0];
                        matrix2[1, 1] = tempMatrix[1, 1];
                        tableMatrix2.Controls.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                Label objlabel = new Label();
                                objlabel.Text = matrix2[i, v].ToString();
                                tableMatrix2.Controls.Add(objlabel, i, v);
                            }
                        }
                    }
                    else
                    {
                        logText.Text = "M1 Transposed" + Environment.NewLine + "Proceeding to multiply both matrix";
                        int[,] tempMatrix = new int[2, 2];
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                tempMatrix[i, v] = matrix1[i, v];
                            }
                        }
                        matrix1 = new int[2, 2];
                        matrix1[0, 0] = tempMatrix[0, 0];
                        matrix1[1, 0] = tempMatrix[0, 1];
                        matrix1[0, 1] = tempMatrix[1, 0];
                        matrix1[1, 1] = tempMatrix[1, 1];
                        tableMatrix1.Controls.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                Label objlabel = new Label();
                                objlabel.Text = matrix1[i, v].ToString();
                                tableMatrix1.Controls.Add(objlabel, i, v);
                            }
                        }
                    }
                    eState = EncryptionState.Tranpose;
                  
                
                    //Multiply the Matrixes

                    logText.Text = "Multiplied Both Matrix " + Environment.NewLine + " Proceeding to multiply all elemnts";

                    tableMatrix1.Controls.Clear();
                    tableMatrix2.Controls.Clear();

                    //table 1 sumed

                    rawMultipledMatrix = new int[2, 2];
                    rawMultipledMatrix[0, 0] = (matrix1[0, 0] * matrix2[0, 0]) + (matrix1[1, 0] * matrix2[0, 1]);
                    rawMultipledMatrix[1, 0] = (matrix1[0, 0] * matrix2[1, 0]) + (matrix1[1, 0] * matrix2[1, 1]);
                    rawMultipledMatrix[0, 1] = (matrix1[0, 1] * matrix2[0, 0]) + (matrix1[1, 1] * matrix2[0, 1]);
                    rawMultipledMatrix[1, 1] = (matrix1[0, 1] * matrix2[1, 0]) + (matrix1[1, 1] * matrix2[1, 1]);

                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = rawMultipledMatrix[i, v].ToString();
                            tableMatrix1.Controls.Add(objlabel, i, v);
                        }
                    }
                    eState = EncryptionState.Multiply;
                  

               
                    //multiply elements
                    tableMatrix1.Controls.Clear();
                    logText.Text = "Multiplying all elements of matrix";
                    keyPos.Visible = true;
                    keyPos.Text = "Multiplying: " + rawMultipledMatrix[0, 0].ToString() + " * " + rawMultipledMatrix[0, 1].ToString() + " * " + rawMultipledMatrix[1, 0] + " * " + rawMultipledMatrix[1, 1] + " = ";
                    rawMultiplied = rawMultipledMatrix[0, 0];
                    rawMultiplied *= rawMultipledMatrix[0, 1];
                    rawMultiplied *= rawMultipledMatrix[1, 0];
                    rawMultiplied *= rawMultipledMatrix[1, 1];
                    keyPos.Text += rawMultiplied.ToString();
                    eState = EncryptionState.MultiplyElements;
                   

                

                    //convert to binary 64-bit
                    logText.Text = "Converting number to key number to binary";
                    byte[] numberArray = BitConverter.GetBytes(rawMultiplied);
                    StringBuilder stringB = new StringBuilder();
                    foreach (byte b in numberArray)
		            {
                        stringB.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
		            }
                    keyPos.Text = stringB.ToString() + " " + stringB.ToString().Length.ToString();
                    binaryKey = stringB.ToString();

                    eState = EncryptionState.ConvertToBinary;
                    

               
                   
                   
             
        }

        private int EncryptRest()
        {
            
            if (popupLog == null)
            {
                
                popupLog = new PopupLog();
                popupLog.Show();
            }
            else
            {
                popupLog.LogText = popupLogText;
            }

                    
                    matrix1 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    mData1 = KeyExpansionHandler.GetMatrixData(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    itIndex++;
                    numberOfMatrixCreated++;
                    if (itIndex >= keyPosTable.Length-1)
                    {
                        noOfIt++;
                        itIndex = 0;
                        if (noOfIt == 5)
                        {
                            List<int> keyPosList = keyPosTable.ToList<int>();
                            keyPosList.Reverse();
                            keyPosTable = keyPosList.ToArray();
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            
                        }
                    }
                    
                    matrix2 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    mData2 = KeyExpansionHandler.GetMatrixData(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
                    itIndex++;
                    numberOfMatrixCreated++;
                    if (itIndex >= keyPosTable.Length-1)
                    {
                        noOfIt++;
                        itIndex = 0;
                        if (noOfIt == 5)
                        {
                            List<int> keyPosList = keyPosTable.ToList<int>();
                            keyPosList.Reverse();
                            keyPosTable = keyPosList.ToArray();
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            Label objlabel = new Label();
                            objlabel.Text = matrix2[i, v].ToString();
                            tableMatrix2.Controls.Add(objlabel, i, v);
                        }
                    }
               

                
                    
                    int summation = matrix1[0, 0] + matrix1[0, 1] + matrix1[1, 0] + matrix1[1, 1] + matrix2[0, 0] + matrix2[0, 1] + matrix2[1, 0] + matrix2[1, 1];
                    permutationDeterminer = summation % 2;
                    

                
                    
                    if (permutationDeterminer == 0)
                    {
                        
                        //even number transpose M2 else transposse M1
                        int[,] tempMatrix = new int[2, 2];
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                tempMatrix[i, v] = matrix2[i, v];
                            }
                        }
                        matrix2 = new int[2, 2];
                        matrix2[0, 0] = tempMatrix[0, 0];
                        matrix2[1, 0] = tempMatrix[0, 1];
                        matrix2[0, 1] = tempMatrix[1, 0];
                        matrix2[1, 1] = tempMatrix[1, 1];
                        tableMatrix2.Controls.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                Label objlabel = new Label();
                                objlabel.Text = matrix2[i, v].ToString();
                                tableMatrix2.Controls.Add(objlabel, i, v);
                            }
                        }
                    }
                    else
                    {
                        
                        int[,] tempMatrix = new int[2, 2];
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                tempMatrix[i, v] = matrix1[i, v];
                            }
                        }
                        matrix1 = new int[2, 2];
                        matrix1[0, 0] = tempMatrix[0, 0];
                        matrix1[1, 0] = tempMatrix[0, 1];
                        matrix1[0, 1] = tempMatrix[1, 0];
                        matrix1[1, 1] = tempMatrix[1, 1];
                        tableMatrix1.Controls.Clear();
                        for (int i = 0; i < 2; i++)
                        {
                            for (int v = 0; v < 2; v++)
                            {
                                Label objlabel = new Label();
                                objlabel.Text = matrix1[i, v].ToString();
                                tableMatrix1.Controls.Add(objlabel, i, v);
                            }
                        }
                    }
                    
                    //Multiply the Matrixes

                    //table 1 sumed

                    rawMultipledMatrix = new int[2, 2];
                    rawMultipledMatrix[0, 0] = (matrix1[0, 0] * matrix2[0, 0]) + (matrix1[1, 0] * matrix2[0, 1]);
                    rawMultipledMatrix[1, 0] = (matrix1[0, 0] * matrix2[1, 0]) + (matrix1[1, 0] * matrix2[1, 1]);
                    rawMultipledMatrix[0, 1] = (matrix1[0, 1] * matrix2[0, 0]) + (matrix1[1, 1] * matrix2[0, 1]);
                    rawMultipledMatrix[1, 1] = (matrix1[0, 1] * matrix2[1, 0]) + (matrix1[1, 1] * matrix2[1, 1]);

                    for (int i = 0; i < 2; i++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            
                        }
                    }



                    //multiply elements
                    rawMultiplied = rawMultipledMatrix[0, 0];
                    rawMultiplied *= rawMultipledMatrix[0, 1];
                    rawMultiplied *= rawMultipledMatrix[1, 0];
                    rawMultiplied *= rawMultipledMatrix[1, 1];

                    if (fUnique.Checked)
                    {
                        while (listOfKeys.Contains(rawMultiplied))
                        {
                            rawMultiplied *= 1.02;
                            increased += " Instance1 ";
                        }
                    }
                    else
                    {
                        increased = "Not Forcing Unique Keys";
                    }

                    //convert to binary 64-bit
                    byte[] numberArray = BitConverter.GetBytes(rawMultiplied);
                    StringBuilder stringB = new StringBuilder();
                    foreach (byte b in numberArray)
		            {
                        stringB.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
		            }
                    
                    binaryKey = stringB.ToString();

                   
                    //encrypt one portion
                    binaryStringToBeIterated = "";
                    

            if (numberOfBinaryIterations == noOfItRequired && noOfLastOffset > 0)
            {
                //offset it
                binaryStringToBeIterated = binaryPlainText.Substring(numberOfBinaryIterations * 64, noOfLastOffset);
                binaryKey = binaryKey.Substring(0, noOfLastOffset);
            }
            else if (numberOfBinaryIterations < noOfItRequired)
            {
                binaryStringToBeIterated = binaryPlainText.Substring(numberOfBinaryIterations * 64, 64);
                
            }
            else
            {
                //Log
                cipher.Text = cipherText;
                popupLogText += "------------ Overall Statistics ------------" + Environment.NewLine +
                                "Number of Iterations: " + numberOfBinaryIterations + Environment.NewLine +
                                "Number of Unique Keys: " + listOfKeys.Count + Environment.NewLine +
                                "Repeated Iterations: " + repeatedIterations + Environment.NewLine +
                                "Increased Instances: " + Environment.NewLine + Environment.NewLine;
                popupLogText += "Encrypted Text:" + cipherText;
                popupLog.LogText = popupLogText;
                return 0;
            }

            //convert to string;
            string encryptedBinary = "";

            List<byte> encryptedBytes = new List<byte>();
            for (int i = 0; i < binaryStringToBeIterated.Length; i += 8)
            {
                encryptedBytes.Add(Convert.ToByte(binaryStringToBeIterated.Substring(i, 8), 2));
            }


            for (int i = 0; i < binaryKey.Length; i++)
            {
                encryptedBinary += ((binaryKey[i] == '1' ? true : false) ^ (binaryStringToBeIterated[i] == '1' ? true : false) == true ? "1" : "0");
            }

            //Encrption
            cipherBinary += encryptedBinary;
            List<byte> encryptedBytes1 = new List<byte>();
            for (int i = 0; i < encryptedBinary.Length; i += 8)
            {
                
                encryptedBytes1.Add(Convert.ToByte(encryptedBinary.Substring(i, 8), 2));
            }
            //perform


            //convert to text to see


            cipherText += Encoding.Unicode.GetString(encryptedBytes1.ToArray()).ToString();
            //loop through cipher text

            popupLogText += "Iteration Number: " + numberOfBinaryIterations + Environment.NewLine +
                            "---------- Matrix Data -------------" + Environment.NewLine +
                            "Matrix 1: " + matrix1[0, 0] + ", " + matrix1[0, 1] + ", " + matrix1[1, 0] + ", " + matrix1[1, 1] + Environment.NewLine +
                            "Matrix 1 Data: " + mData1 + Environment.NewLine +
                            "Matrix 2: " + matrix2[0, 0] + ", " + matrix2[0, 1] + ", " + matrix2[1, 0] + ", " + matrix2[1, 1] + Environment.NewLine +
                            "Matrix 2 Data: " + mData2 +
                            "-------------------------------------" + Environment.NewLine + 
                            "Permutation Index: " + permutationDeterminer + " | Number Key: " + rawMultiplied + Environment.NewLine +
                            "Before SubStr: " + Encoding.Unicode.GetString(encryptedBytes.ToArray()) + " | After SubStr: " + Encoding.Unicode.GetString(encryptedBytes1.ToArray()) + Environment.NewLine +
                            "********************** End of Iteration: " + numberOfBinaryIterations + " ***********************" + Environment.NewLine + Environment.NewLine;

            if (!listOfKeys.Contains(rawMultiplied))
            {
                listOfKeys.Add(rawMultiplied);
            }
            else
            {
                repeatedIterations += noOfIt + ", ";
            }

            // end test
            numberOfBinaryIterations++;
            popupLog.LogText = popupLogText;

            return EncryptRest();

        }

        private int DecryptingCipher()
        {
            if (popupLog == null)
            {
                
                popupLog = new PopupLog();
                popupLog.Show();
            }
            else
            {
                popupLog.LogText = popupLogText;
            }


            matrix1 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
            mData1 = KeyExpansionHandler.GetMatrixData(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
            itIndex++;
            numberOfMatrixCreated++;
            if (itIndex >= keyPosTable.Length - 1)
            {
                noOfIt++;
                itIndex = 0;
                if (noOfIt == 5)
                {
                    List<int> keyPosList = keyPosTable.ToList<int>();
                    keyPosList.Reverse();
                    keyPosTable = keyPosList.ToArray();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int v = 0; v < 2; v++)
                {

                }
            }

            matrix2 = KeyExpansionHandler.GetMatrix(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
            mData2 = KeyExpansionHandler.GetMatrixData(keyPosTable, noOfIt, itIndex, box1, box2, box3, box4, numberOfMatrixCreated);
            itIndex++;
            numberOfMatrixCreated++;
            if (itIndex >= keyPosTable.Length - 1)
            {
                noOfIt++;
                itIndex = 0;
                if (noOfIt == 5)
                {
                    List<int> keyPosList = keyPosTable.ToList<int>();
                    keyPosList.Reverse();
                    keyPosTable = keyPosList.ToArray();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int v = 0; v < 2; v++)
                {
                    Label objlabel = new Label();
                    objlabel.Text = matrix2[i, v].ToString();
                    tableMatrix2.Controls.Add(objlabel, i, v);
                }
            }




            int summation = matrix1[0, 0] + matrix1[0, 1] + matrix1[1, 0] + matrix1[1, 1] + matrix2[0, 0] + matrix2[0, 1] + matrix2[1, 0] + matrix2[1, 1];
            permutationDeterminer = summation % 2;




            if (permutationDeterminer == 0)
            {

                //even number transpose M2 else transposse M1
                int[,] tempMatrix = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int v = 0; v < 2; v++)
                    {
                        tempMatrix[i, v] = matrix2[i, v];
                    }
                }
                matrix2 = new int[2, 2];
                matrix2[0, 0] = tempMatrix[0, 0];
                matrix2[1, 0] = tempMatrix[0, 1];
                matrix2[0, 1] = tempMatrix[1, 0];
                matrix2[1, 1] = tempMatrix[1, 1];
                tableMatrix2.Controls.Clear();
                for (int i = 0; i < 2; i++)
                {
                    for (int v = 0; v < 2; v++)
                    {
                        Label objlabel = new Label();
                        objlabel.Text = matrix2[i, v].ToString();
                        tableMatrix2.Controls.Add(objlabel, i, v);
                    }
                }
            }
            else
            {

                int[,] tempMatrix = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int v = 0; v < 2; v++)
                    {
                        tempMatrix[i, v] = matrix1[i, v];
                    }
                }
                matrix1 = new int[2, 2];
                matrix1[0, 0] = tempMatrix[0, 0];
                matrix1[1, 0] = tempMatrix[0, 1];
                matrix1[0, 1] = tempMatrix[1, 0];
                matrix1[1, 1] = tempMatrix[1, 1];
                tableMatrix1.Controls.Clear();
                for (int i = 0; i < 2; i++)
                {
                    for (int v = 0; v < 2; v++)
                    {
                        Label objlabel = new Label();
                        objlabel.Text = matrix1[i, v].ToString();
                        tableMatrix1.Controls.Add(objlabel, i, v);
                    }
                }
            }

            //Multiply the Matrixes

            //table 1 sumed

            rawMultipledMatrix = new int[2, 2];
            rawMultipledMatrix[0, 0] = (matrix1[0, 0] * matrix2[0, 0]) + (matrix1[1, 0] * matrix2[0, 1]);
            rawMultipledMatrix[1, 0] = (matrix1[0, 0] * matrix2[1, 0]) + (matrix1[1, 0] * matrix2[1, 1]);
            rawMultipledMatrix[0, 1] = (matrix1[0, 1] * matrix2[0, 0]) + (matrix1[1, 1] * matrix2[0, 1]);
            rawMultipledMatrix[1, 1] = (matrix1[0, 1] * matrix2[1, 0]) + (matrix1[1, 1] * matrix2[1, 1]);

            for (int i = 0; i < 2; i++)
            {
                for (int v = 0; v < 2; v++)
                {

                }
            }



            //multiply elements
            rawMultiplied = rawMultipledMatrix[0, 0];
            rawMultiplied *= rawMultipledMatrix[0, 1];
            rawMultiplied *= rawMultipledMatrix[1, 0];
            rawMultiplied *= rawMultipledMatrix[1, 1];
            if (fUnique.Checked)
            {
                while (listOfKeys.Contains(rawMultiplied))
                {
                    rawMultiplied *= 1.02;
                    increased += " Instance1 ";
                }
            }
            else
            {
                increased = "Not Forcing Unique Keys";
            }

            //convert to binary 64-bit
            byte[] numberArray = BitConverter.GetBytes(rawMultiplied);
            StringBuilder stringB = new StringBuilder();
            foreach (byte b in numberArray)
            {
                stringB.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            binaryKey = stringB.ToString();


            //encrypt one portion
            binaryStringToBeIterated = "";


            if (numberOfBinaryIterations == noOfItRequired && noOfLastOffset > 0)
            {
                //offset it
                binaryStringToBeIterated = binaryPlainText.Substring(numberOfBinaryIterations * 64, noOfLastOffset);
                binaryKey = binaryKey.Substring(0, noOfLastOffset);
            }
            else if (numberOfBinaryIterations < noOfItRequired)
            {
                binaryStringToBeIterated = binaryPlainText.Substring(numberOfBinaryIterations * 64, 64);

            }
            else
            {
                //Log
                cipher.Text = cipherText;
                popupLogText += "------------ Overall Statistics ------------" + Environment.NewLine +
                                "Number of Iterations: " + numberOfBinaryIterations + Environment.NewLine +
                                "Number of Unique Keys: " + listOfKeys.Count + Environment.NewLine +
                                "Repeated Iterations: " + repeatedIterations + Environment.NewLine +
                                "Increased Instances: " + increased + Environment.NewLine + Environment.NewLine;
                popupLogText += "Plain Text:" + plainText;
                popupLog.LogText = popupLogText;
                return 0;
            }

            //convert to string;
            string encryptedBinary = "";

            List<byte> encryptedBytes = new List<byte>();
            for (int i = 0; i < binaryStringToBeIterated.Length; i += 8)
            {
                encryptedBytes.Add(Convert.ToByte(binaryStringToBeIterated.Substring(i, 8), 2));
            }


            for (int i = 0; i < binaryKey.Length; i++)
            {
                encryptedBinary += ((binaryKey[i] == '1' ? true : false) ^ (binaryStringToBeIterated[i] == '1' ? true : false) == true ? "1" : "0");
            }

            //Encrption
            cipherBinary += encryptedBinary;
            List<byte> encryptedBytes1 = new List<byte>();
            for (int i = 0; i < encryptedBinary.Length; i += 8)
            {
                encryptedBytes1.Add(Convert.ToByte(encryptedBinary.Substring(i, 8), 2));
            }
            //perform


            //convert to text to see


            plainText += Encoding.Unicode.GetString(encryptedBytes1.ToArray()).ToString();
            //loop through cipher text

            popupLogText += "Iteration Number: " + numberOfBinaryIterations + Environment.NewLine +
                            "---------- Matrix Data -------------" + Environment.NewLine +
                            "Matrix 1: " + matrix1[0, 0] + ", " + matrix1[0, 1] + ", " + matrix1[1, 0] + ", " + matrix1[1, 1] + Environment.NewLine +
                            "Matrix 1 Data: " + mData1 + Environment.NewLine +
                            "Matrix 2: " + matrix2[0, 0] + ", " + matrix2[0, 1] + ", " + matrix2[1, 0] + ", " + matrix2[1, 1] + Environment.NewLine +
                            "Matrix 2 Data: " + mData2 +
                            "-------------------------------------" + Environment.NewLine +
                            "Permutation Index: " + permutationDeterminer + " | Number Key: " + rawMultiplied + Environment.NewLine +
                            "Before SubStr: " + Encoding.Unicode.GetString(encryptedBytes.ToArray()) + " | After SubStr: " + Encoding.Unicode.GetString(encryptedBytes1.ToArray()) + Environment.NewLine +
                            "********************** End of Iteration: " + numberOfBinaryIterations + " ***********************" + Environment.NewLine + Environment.NewLine;

            if (!listOfKeys.Contains(rawMultiplied))
            {
                listOfKeys.Add(rawMultiplied);
            }
            else
            {
                repeatedIterations += noOfIt + ", ";
            }

            // end test
            numberOfBinaryIterations++;
            popupLog.LogText = popupLogText;

            return DecryptingCipher();

        }
       
    }
}
