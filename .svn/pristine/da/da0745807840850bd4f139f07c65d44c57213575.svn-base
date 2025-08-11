using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace BOSERP.Utilities
{
    static class BarcodePrinter
    {
        #region ENUM
        public enum BarCodeStyle {EAN13 = 1, Code128 =  2};
        #endregion

        #region Declare Varibles
        private static String _barCode;
        private static int _printNum;
        private static double _price;
        private static String _no;
        private static String _color;
        private static String _size;
        private static String _name;
        #endregion

        #region Public Properties
        public static String BarCode
        {
            get
            {
                return _barCode;
            }
            set
            {
                _barCode = value;
            }
        }
        public static int PrintNum
        {
            get 
            {
                return _printNum;
            }
            set 
            {
                _printNum = value;
            }
        }
        public static double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public static String No
        {
            get
            {
                return _no;
            }
            set
            {
                _no = value;
            }
        }
        public static String Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        public static String Color

        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public static String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        #endregion

        #region Constructor
        static BarcodePrinter()
        {
            _barCode = String.Empty;
            _printNum = 0;
            _no = String.Empty;
            _price = 0;
            _size = _color = _name = String.Empty;
        }
        #endregion

        #region Code EAN13
        private static string EAN13(string chaine)
        {
            //V 1.0
            //Paramètres : une chaine de 12 chiffres
            //Parameters : a 12 digits length string
            //Retour : * une chaine qui, affichée avec la police EAN13.TTF, donne le code barre
            //         * une chaine vide si paramètre fourni incorrect
            //Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
            //         * an empty string if the supplied parameter is no good
            int i;
            int first;
            int checksum = 0;
            string CodeBarre = "";
            bool tableA;

            //Vérifier qu'il y a 12 caractères
            //Check for 12 characters
            //Et que ce sont bien des chiffres
            //And they are really digits
            if (Regex.IsMatch(chaine, "^\\d{12}$"))
            {
                // Calcul de la clé de contrôle
                // Calculation of the checksum
                for (i = 1; i < 12; i += 2)
                {
                    System.Diagnostics.Debug.WriteLine(chaine.Substring(i, 1));
                    checksum += Convert.ToInt32(chaine.Substring(i, 1));
                }
                checksum *= 3;
                for (i = 0; i < 12; i += 2)
                {
                    checksum += Convert.ToInt32(chaine.Substring(i, 1));
                }

                chaine += (10 - checksum % 10) % 10;
                //Le premier chiffre est pris tel quel, le deuxième vient de la table A
                //The first digit is taken just as it is, the second one come from table A
                CodeBarre = chaine.Substring(0, 1) + (char)(65 + Convert.ToInt32(chaine.Substring(1, 1)));
                first = Convert.ToInt32(chaine.Substring(0, 1));
                for (i = 2; i <= 6; i++)
                {
                    tableA = false;
                    switch (i)
                    {
                        case 2:
                            if (first >= 0 && first <= 3) tableA = true;
                            break;
                        case 3:
                            if (first == 0 || first == 4 || first == 7 || first == 8) tableA = true;
                            break;
                        case 4:
                            if (first == 0 || first == 1 || first == 4 || first == 5 || first == 9) tableA = true;
                            break;
                        case 5:
                            if (first == 0 || first == 2 || first == 5 || first == 6 || first == 7) tableA = true;
                            break;
                        case 6:
                            if (first == 0 || first == 3 || first == 6 || first == 8 || first == 9) tableA = true;
                            break;
                    }

                    if (tableA)
                        CodeBarre += (char)(65 + Convert.ToInt32(chaine.Substring(i, 1)));
                    else
                        CodeBarre += (char)(75 + Convert.ToInt32(chaine.Substring(i, 1)));
                }
                CodeBarre += "*"; //Ajout séparateur central / Add middle separator

                for (i = 7; i <= 12; i++)
                {
                    CodeBarre += (char)(97 + Convert.ToInt32(chaine.Substring(i, 1)));
                }
                CodeBarre += "+"; //Ajout de la marque de fin / Add end mark
            }
            return CodeBarre;
        }
        private static string AddOn(string chaine)
        {
            //  'V 1.0
            //  'Paramètres : une chaine de 2 ou 5 chiffres
            //  'Parameters : A 2 or 5 digits length string
            //  'Retour : * une chaine qui, affichée avec la police EAN13.TTF, donne le code barre supplementaire
            //  '         * une chaine vide si paramètre fourni incorrect
            //  'Return : * a string which give the add-on bar code when it is dispayed with EAN13.TTF font
            //  '         * an empty string if the supplied parameter is no good

            //  Dim i%, checksum%, first%, CodeBarre$, tableA As Boolean
            int i;
            //int first; - not used
            int checksum = 0;
            //string CodeBarre=""; - not used
            bool tableA;
            string AddOn = "";

            //  'Vérifier qu'il y a 2 ou 5 caractères
            //  'Check for 2 or 5 characters
            //  'Et que ce sont bien des chiffres
            //  'And it is digits
            if (Regex.IsMatch(chaine, "^\\d{2}$") || Regex.IsMatch(chaine, "^\\d{5}$"))
            {
                // Checksum calculation
                if (chaine.Length == 2)
                    checksum = 10 + Convert.ToInt32(chaine) % 4;
                else
                {
                    for (i = 0; i < 5; i += 2)
                    {
                        checksum += Convert.ToInt32(chaine.Substring(i, 1));
                    }
                    checksum = (checksum * 3 + Convert.ToInt32(chaine.Substring(1, 1)) * 9 + Convert.ToInt32(chaine.Substring(3, 1)) * 9) % 10;
                }
                AddOn = "[";

                for (i = 0; i < chaine.Length; i++)
                {
                    tableA = false;
                    switch (i)
                    {
                        case 0:
                            if ((checksum >= 4 && checksum <= 9) || checksum == 10 || checksum == 11) tableA = true;
                            break;
                        case 1:
                            if (checksum == 1 || checksum == 2 || checksum == 3 || checksum == 5 || checksum == 6
                                || checksum == 9 || checksum == 10 || checksum == 12) tableA = true;
                            break;
                        case 2:
                            if (checksum == 0 || checksum == 2 || checksum == 3 || checksum == 6
                                || checksum == 7 || checksum == 8) tableA = true;
                            break;
                        case 3:
                            if (checksum == 0 || checksum == 1 || checksum == 3 || checksum == 4
                                || checksum == 8 || checksum == 9) tableA = true;
                            break;
                        case 4:
                            if (checksum == 0 || checksum == 1 || checksum == 2 || checksum == 4
                                || checksum == 5 || checksum == 7) tableA = true;
                            break;
                    }
                    if (tableA)
                        AddOn += (char)(65 + Convert.ToInt32(chaine.Substring(i, 1)));
                    else
                        AddOn += (char)(75 + Convert.ToInt32(chaine.Substring(i, 1)));

                    if ((chaine.Length == 2 && i == 0) || (chaine.Length == 5 && i < 4)) AddOn += (char)(92); //Ajout du séparateur de caractère / Add character separator
                }
            }
            return AddOn;
        }
        public static String GenCodeEAN13(String input)
        {
            String result = input.Substring(0, 12).PadRight(12, '0');
            result = EAN13(result) + AddOn(String.Empty);
            return result;
        }
        #endregion

        #region Code 39
        private static String GenCode39(String input)
        {
            return ("*" + input + "*");
        }
        #endregion

        #region Code 128
        /// <summary>
        /// Use MakeBarcodeImage method of Code128Rendering class to create a barcode Image.
        /// </summary>
        #endregion

        #region Print Barcode
        public static void Print(BarCodeStyle type)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.Copies = (short)(PrintNum);
            if (type == BarCodeStyle.Code128)
                printDocument.PrintPage += new PrintPageEventHandler(PrintPage_Code128);
            else
                printDocument.PrintPage += new PrintPageEventHandler(PrintPage_EAN13);

            //PrintPreviewDialog dlg = new PrintPreviewDialog();
            //dlg.Document = printDocument;
            //dlg.ShowDialog();

            printDocument.Print();
        }
        static void PrintPage_Code128(Object sender, PrintPageEventArgs e)
        {
            Image barCodeImage = Code128Rendering.MakeBarcodeImage(BarCode, 1, true);
            Font fontTitle = new Font("New Time Roman", 8, FontStyle.Bold);
            Font fontNo = new Font("New Time Roman", 6, FontStyle.Bold);
            Font fontNormal = new Font("New Time Roman", 5);

            e.Graphics.DrawImage(barCodeImage, 5, 15);
            e.Graphics.DrawString(BarCode, fontNo, Brushes.Black, 5, 48);
        }

        static void PrintPage_EAN13(Object sender, PrintPageEventArgs e)
        {
            String outputBarCode = GenCodeEAN13(BarCode);
            Font fontTitle = new Font("New Time Roman", 7, FontStyle.Bold);
            Font fontBarCode = new Font("Code EAN13", 30);
            Font fontNormal = new Font("New Time Roman", 5);

            //e.Graphics.DrawString(Name, fontNormal, Brushes.Black, 15, 12);
            e.Graphics.DrawString(outputBarCode, fontBarCode, Brushes.Black, 5, 10);
        }
        #endregion
    }
}
