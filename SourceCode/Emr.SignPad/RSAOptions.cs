// Copyright 2000-2020, signotec GmbH, Ratingen, Germany, All Rights Reserved
// signotec GmbH
// Am Gierath 20b
// 40885 Ratingen
// Tel: +49 (2102) 5 35 75-10
// Fax: +49 (2102) 5 35 75-39
// E-Mail: <info@signotec.de>
//
//-----------------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//   * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//   * Neither the name of the signotec GmbH nor the names of its contributors
//     may be used to endorse or promote products derived from this software
//     without specific prior written permission.
//
// THIS SOFTWARE ONLY DEMONSTRATES HOW TO IMPLEMENT SIGNOTEC SOFTWARE COMPONENTS
// AND IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
// OF THE POSSIBILITY OF SUCH DAMAGE.
//-----------------------------------------------------------------------------
//
// Version: 8.5.1.0
// Date:    2020-11-12

using Security.Cryptography;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using signotec.STPadLibNet;
using CERTENROLLLib;
using System.Security;

namespace Emr.SignPad
{
    public partial class RSAOptions : Form
    {

        private MainWindow _parent;
        private STPadLib _stPad;
        private bool _enableSecureMode;
        private byte[] _imageData;
        private byte[] _hash1;
        private byte[] _signature;
        private byte[] _signData;
        private string _decCertPath;
        private bool _changedProgrammatically = false;
        const string _passwordCertText = "Password for certificate file:";
        const string _passwordPadText = "The pad is password protected. Please enter password:";
        #region Form

        public RSAOptions()
        {
            InitializeComponent();

            InitControls(null);
        }

        public void InitControls(MainWindow parent)
        {
            _parent = parent;
            ComboBoxKeyLength.SelectedIndex = 0;
            ComboBoxValidity.SelectedIndex = 0;
            ComboBoxCertType.SelectedIndex = 0;
            CheckBoxCompHash.Checked = false;
            ComboBoxHashAlgo.SelectedIndex = 1;
            ComboBoxScheme.SelectedIndex = 0;
            ComboBoxValue.SelectedIndex = 0;
            CheckBoxDemoCert.Checked = true;
            CheckBoxSignData.Checked = false;
            UpdateControls();
        }

        public void UpdateControls()
        {
            if (_parent == null)
                return;

            LabelRSASupport.Visible = (!_parent.SignPad.SupportsRSA || ((_parent.SignPad.PadModel != PadModel.Alpha) && !_parent.SignPad.SupportsContentSigning));

            // Signing Certificate
            ButtonGenSignCert.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
            ButtonLoadSignCert.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
            ButtonSaveCert.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
            ButtonShowCert.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
            if (_parent.SignPad.Supports4096BitKeys)
            {
                if (!ComboBoxKeyLength.Items.Contains("3072 Bit"))
                    ComboBoxKeyLength.Items.Add("3072 Bit");
                if (!ComboBoxKeyLength.Items.Contains("4096 Bit"))
                    ComboBoxKeyLength.Items.Add("4096 Bit");
                ComboBoxKeyLength.SelectedIndex = 1;
            }
            else
            {
                ComboBoxKeyLength.Items.Remove("3072 Bit");
                ComboBoxKeyLength.Items.Remove("4096 Bit");
                ComboBoxKeyLength.SelectedIndex = 0;
            }

            // Signing
            CheckBoxCompHash.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsContentSigning);
            CheckSigningOptions();

            // RSA Encryption
            CheckEncryptionOptions();
            ButtonGetEncCertID.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
            _enableSecureMode = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);

            // RSA Password
            groupBoxPasswordOptions.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsRSASignPassword);
            buttonSetPassword.Text = (_parent.SignPad.Open && _parent.SignPad.SupportsRSASignPassword) ? "Set Password" : "Not Supported";

            ButtonCloseCapture.Enabled = (_parent.SignPad.Open && (CheckBoxSignAfterCapture.Checked || CheckBoxSignData.Checked));
        }

        public DialogResult ShowDialog(MainWindow parent, STPadLib stPad)
        {
            if (_parent == null)
            {
                _parent = parent;
                UpdateControls();
            }
            else
                _parent = parent;
            _stPad = stPad;

            ButtonCloseCapture.Enabled = (CheckBoxSignAfterCapture.Checked || CheckBoxSignData.Checked);
            try
            {
                _stPad.SignatureSetSecureMode(_enableSecureMode);
                CheckBoxSecureMode.CheckState = _enableSecureMode ? CheckState.Checked : CheckState.Unchecked;
            }
            catch (STPadException) { }

            return ShowDialog();
        }

        private void RSAOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckBoxSignAfterCapture.Checked)
            {
                if ((_hash1 == null) && !CheckBoxCompHash.Checked && (ComboBoxValue.SelectedIndex != 2))
                {
                    MessageBox.Show("For the selected features a hash 1 must be computed!", Application.ProductName);
                    e.Cancel = true;
                }
                if (ComboBoxValue.SelectedIndex == 0)
                {
                    if (ComboBoxScheme.SelectedIndex == 1)
                    {
                        MessageBox.Show("Signing the combination of hash 1 and hash 2 with the selected scheme is not possible.", Application.ProductName);
                        e.Cancel = true;
                    }
                    if ((ComboBoxScheme.SelectedIndex == 0) && (ComboBoxHashAlgo.SelectedIndex == 0))
                    {
                        MessageBox.Show("Signing the combination of hash 1 and hash 2 with the selected scheme and the selected algorithm is not possible.", Application.ProductName);
                        e.Cancel = true;
                    }
                }
            }
        }


        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCloseCapture_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        #endregion
        #region RSASigning
        #region Certificate

        private void ButtonGenSignCert_Click(object sender, EventArgs e)
        {
            LabelGenerate.Text = "Generating a new certificate. Please wait!";
            LabelGenerate.ForeColor = Color.Red;
            LabelGenerate.Refresh();
            Cursor = Cursors.WaitCursor;

            int keyLength = 0;
            switch (ComboBoxKeyLength.SelectedIndex)
            {
                case 0:
                    keyLength = 1024;
                    break;
                case 1:
                    keyLength = 2048;
                    break;
                case 2:
                    keyLength = 3072;
                    break;
                case 3:
                    keyLength = 4096;
                    break;
            }
            try
            {
                _stPad.RSAGenerateSigningCert(keyLength, ComboBoxValidity.SelectedIndex);
                MessageBox.Show("The signing certificate has been generated successfully!", Application.ProductName);
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode != -34)
                    MessageBox.Show(exc.Message, Application.ProductName);
                else // error pad is password protected
                {
                    PasswordPrompt passwordWindow = new PasswordPrompt(_passwordPadText);
                    passwordWindow.StartPosition = FormStartPosition.CenterParent;
                    try
                    {
                        if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                        {
                            _stPad.RSAGenerateSigningCertPw(keyLength, ComboBoxValidity.SelectedIndex, passwordWindow.PasswordHandover);
                            MessageBox.Show("The signing certificate has been generated successfully!", Application.ProductName);
                        }
                    }
                    catch (STPadException exceptPad)
                    {
                        MessageBox.Show(exceptPad.Message, Application.ProductName);
                    }
                    finally
                    {
                        SafeDeletePassword(passwordWindow);
                    }
                }
            }

            LabelGenerate.Text = "Generating a certificate may take several minutes!";
            LabelGenerate.ForeColor = Color.Black;
            Cursor = Cursors.Default;
        }

        private void ButtonLoadSignCert_Click(object sender, EventArgs e)
        {
            DialogOpen.Title = "Open certificate file";
            DialogOpen.FileName = "";
            DialogOpen.Filter = "Private certificate (*.PFX)|*.pfx|Private certificate (*.P12)|*.p12|Public certificate (*.CER)|*.cer";
            if (DialogOpen.ShowDialog() != DialogResult.OK)
                return;
            if (String.IsNullOrEmpty(DialogOpen.FileName))
                return;

            try
            {
                _stPad.RSASetSigningCert(DialogOpen.FileName, (SecureString)null);
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode == -34)   // error pad is password protected
                    SetSigningCertPwProtect(null);
                else if (exc.ErrorCode == -89)   // error wrong certificate password
                {
                    SecureString secureRsaPassword = new SecureString();
                    PasswordPrompt passwordWindow = new PasswordPrompt(_passwordCertText);
                    passwordWindow.StartPosition = FormStartPosition.CenterParent;
                    try
                    {
                        if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                        {
                            secureRsaPassword = passwordWindow.PasswordHandover.Copy();
                            _stPad.RSASetSigningCert(DialogOpen.FileName, secureRsaPassword);
                        }
                    }
                    catch (STPadException except)
                    {
                        if (except.ErrorCode == -34)    // error pad is password protected
                            SetSigningCertPwProtect(secureRsaPassword);
                        else
                            MessageBox.Show(except.Message, Application.ProductName);
                    }
                    finally
                    {
                        secureRsaPassword.Dispose();
                        SafeDeletePassword(passwordWindow);
                    }
                }
                else
                    MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void SetSigningCertPwProtect(SecureString secureRsaPassword)
        {
            PasswordPrompt padPasswordWindow = new PasswordPrompt(_passwordPadText);
            padPasswordWindow.StartPosition = FormStartPosition.CenterParent;
            try
            {
                if (padPasswordWindow.ShowDialog(this) == DialogResult.OK)
                    _stPad.RSASetSigningCertPw(DialogOpen.FileName, secureRsaPassword, padPasswordWindow.PasswordHandover);
            }
            catch (STPadException exceptPad)
            {
                MessageBox.Show(exceptPad.Message, Application.ProductName);
            }
            finally
            {
                SafeDeletePassword(padPasswordWindow);
            }
        }

        private void ButtonSaveCert_Click(object sender, EventArgs e)
        {
            DialogOpen.Title = "Save certificate file";
            DialogSave.FileName = "";
            CertType type;
            switch (ComboBoxCertType.SelectedIndex)
            {
                case 1:
                    DialogSave.Filter = "DER encoded (*.CSR)|*.csr|PEM encoded (*.PEM)|*.pem";
                    type = CertType.CSR_DER;
                    break;
                default:
                    DialogSave.Filter = "DER encoded (*.CER)|*.cer|PEM encoded (*.CRT)|*.crt";
                    type = CertType.Cert_DER;
                    break;
            }
            if (DialogSave.ShowDialog() != DialogResult.OK)
                return;
            if (DialogSave.FileName == "")
                return;
            if (DialogSave.FilterIndex == 2)
            {    // PEM encoded
                switch (ComboBoxCertType.SelectedIndex)
                {
                    case 1:
                        type = CertType.CSR_PEM;
                        break;
                    default:
                        type = CertType.Cert_PEM;
                        break;
                }
            }

            try
            {
                _stPad.RSASaveSigningCertAsFile(DialogSave.FileName, type);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        private void ButtonShowCert_Click(object sender, EventArgs e)
        {
            try
            {
                Object certData = _stPad.RSASaveSigningCertAsStream((CertType)ComboBoxCertType.SelectedIndex);
                string message;
                int keyLength;
                switch (ComboBoxCertType.SelectedIndex)
                {
                    case 1:
                        CX509CertificateRequestPkcs10 csr = new CX509CertificateRequestPkcs10();
                        csr.InitializeDecode(Convert.ToBase64String((byte[])certData), EncodingType.XCN_CRYPT_STRING_BASE64_ANY);
                        csr.CheckSignature();
                        CX500DistinguishedName subject = csr.Subject;
                        subject.Decode(subject.EncodedName);
                        message = "Subject: " + subject.Name;
                        keyLength = csr.PublicKey.Length;
                        break;
                    default:
                        X509Certificate2 cert = (X509Certificate2)certData;
                        message = "Issued for: " + cert.GetNameInfo(X509NameType.SimpleName, false);
                        message += "\nIssued by: " + cert.GetNameInfo(X509NameType.SimpleName, true);
                        message += "\nValid from " + cert.NotBefore + " to " + cert.NotAfter;
                        keyLength = cert.PublicKey.Key.KeySize;
                        break;
                }
                message += "\nLength: " + Convert.ToString(keyLength) + " Bits";
                MessageBox.Show(message, Application.ProductName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }

        #endregion
        #region Signing

        private void CheckBoxCompHash_CheckedChanged(object sender, EventArgs e)
        {
            ButtonCompHash.Enabled = !CheckBoxCompHash.Checked;

            CheckSigningOptions();
        }

        internal bool ComputeDisplayHash(DisplayTarget source)
        {
            _imageData = _stPad.RSACreateDisplayHash((HashAlgo)ComboBoxHashAlgo.SelectedIndex, source);
            return ComputeHash1(_imageData);
        }

        private void ButtonCompHash_Click(object sender, EventArgs e)
        {
            DialogOpen.Title = "Open document to compute hash over";
            DialogOpen.FileName = "";
            DialogOpen.Filter = null;
            if (DialogOpen.ShowDialog() != DialogResult.OK)
                return;
            if (DialogOpen.FileName == "")
                return;

            FileStream fs = null;
            try
            {
                fs = new FileStream(DialogOpen.FileName, FileMode.Open);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                ComputeHash1(data);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            if (fs != null)
                fs.Close();

            CheckSigningOptions();
        }

        private bool ComputeHash1(byte[] buffer)
        {
            HashAlgorithm hashAlgo = null;
            if (ComboBoxHashAlgo.SelectedIndex == 0)
                hashAlgo = new SHA1Managed();
            else if (ComboBoxHashAlgo.SelectedIndex == 1)
                hashAlgo = new SHA256Managed();
            else
                hashAlgo = new SHA512Managed();

            try
            {
                _hash1 = hashAlgo.ComputeHash(buffer);
                ButtonSignHash1.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return false;
            }
            finally
            {
                CheckSigningOptions();
            }
            return true;
        }

        internal bool SetHash1()
        {
            try
            {
                if (_hash1 == null)
                    _stPad.RSASetHash((HashAlgo)(ComboBoxHashAlgo.SelectedIndex));
                else
                    _stPad.RSASetHash(_hash1, (HashAlgo)(ComboBoxHashAlgo.SelectedIndex), HashFlag.None);
                return true;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
            return false;
        }

        private void ComboBoxHashAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _hash1 = null;
            if (ComboBoxHashAlgo.SelectedIndex == 2)//SHA-512 is only available when computing the display hash
                ButtonCompHash.Enabled = false;
            else
                ButtonCompHash.Enabled = !CheckBoxCompHash.Checked;

            CheckSigningOptions();
        }

        private void ButtonSignHash1_Click(object sender, EventArgs e)
        {
            // set hash 1
            if (!SetHash1())
                return;

            // sign & verify
            Sign(HashValue.Hash1);
        }

        internal void Sign()
        {
            Sign((HashValue)ComboBoxValue.SelectedIndex);
        }

        private void Sign(HashValue hashValue)
        {
            if (hashValue == HashValue.Combination)
            {
                if (ComboBoxScheme.SelectedIndex == 1)
                {
                    MessageBox.Show("Signing the combination of hash 1 and hash 2 with the selected scheme is not possible.", Application.ProductName);
                    return;
                }
                if ((ComboBoxScheme.SelectedIndex == 0) && (ComboBoxHashAlgo.SelectedIndex == 0))
                {
                    MessageBox.Show("Signing the combination of hash 1 and hash 2 with the selected scheme and the selected algorithm is not possible.", Application.ProductName);
                    return;
                }
            }

            Cursor = Cursors.WaitCursor;

            // sign data
            bool signSuccess = false;
            try
            {
                _signature = _stPad.RSASign((RSAScheme)ComboBoxScheme.SelectedIndex, hashValue, SignFlag.None);
                signSuccess = true;
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode != -34)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                    return;
                }
                else    // error wrong password
                {
                    string label = "Password for signing process";
                    PasswordPrompt passwordWindow = new PasswordPrompt(label);
                    passwordWindow.StartPosition = FormStartPosition.CenterParent;
                    try
                    {
                        if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                        {
                            _signature = _stPad.RSASignPw((RSAScheme)ComboBoxScheme.SelectedIndex, hashValue, SignFlag.None, passwordWindow.PasswordHandover);
                            signSuccess = true;
                        }
                    }
                    catch (STPadException except)
                    {
                        MessageBox.Show(except.Message, Application.ProductName);
                    }
                    finally
                    {
                        SafeDeletePassword(passwordWindow);
                    }
                }
            }

            if (signSuccess)
            {
                try
                {
                    // convert signature into string
                    string signature = "";
                    foreach (byte value in _signature)
                        signature += value.ToString("X2") + " ";

                    // get public signing certificate from pad
                    X509Certificate2 cert = (X509Certificate2)_stPad.RSASaveSigningCertAsStream(CertType.Cert_DER);

                    // setup provider
                    RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
                    RSACng rsa = null;
                    string oid = null;
                    if (ComboBoxScheme.SelectedIndex == 2)
                    {   // "PSS (PKCS1-V2_1)" scheme can only be verified with the CNG API
                        rsa = new RSACng(CngKey.Import(csp.ExportCspBlob(false), CngKeyBlobFormat.GenericPublicBlob));
                        rsa.SignaturePaddingMode = AsymmetricPaddingMode.Pss;
                        switch (ComboBoxHashAlgo.SelectedIndex)
                        {
                            case 0:
                                rsa.SignatureHashAlgorithm = CngAlgorithm.Sha1;
                                rsa.SignatureSaltBytes = 20;
                                break;
                            case 1:
                                rsa.SignatureHashAlgorithm = CngAlgorithm.Sha256;
                                rsa.SignatureSaltBytes = 32;
                                break;
                            case 2:
                                rsa.SignatureHashAlgorithm = CngAlgorithm.Sha512;
                                rsa.SignatureSaltBytes = 64;
                                break;
                        }
                    }
                    else
                    {   // use standard Cryptography namespace
                        if (hashValue == 0)
                            // the combined hash always has a length of 64 bytes
                            oid = CryptoConfig.MapNameToOID("SHA512");
                        else
                        {
                            switch (ComboBoxHashAlgo.SelectedIndex)
                            {
                                case 0:
                                    oid = CryptoConfig.MapNameToOID("SHA1");
                                    break;
                                case 1:
                                    oid = CryptoConfig.MapNameToOID("SHA256");
                                    break;
                                case 2:
                                    oid = CryptoConfig.MapNameToOID("SHA512");
                                    break;
                            }
                        }
                    }

                    // compute hash 2 if necessary
                    string message = null;
                    byte[] hash2 = null;
                    if (hashValue != HashValue.Hash1)
                    {
                        // get SignData
                        try
                        {
                            _signData = _stPad.RSAGetSignData(SignDataGetFlag.None);
                        }
                        catch (STPadException exc)
                        {
                            message = "The RSA signature could not be verified because the RSA SignData that are necessary to compute the hash 2 could not be retrieved from the pad.\n";
                            message += "Reason: " + exc.Message;
                            message += "\n\n\nThe RSA signature is:\n" + signature;
                            Cursor = Cursors.Default;
                            MessageBox.Show(message, Application.ProductName);
                            return;
                        }

                        // compute hash 2 over signdata using the apropriate algorithm
                        ExtraData extraDataExtracted = _stPad.RSAExtractExtraData((HashAlgo)ComboBoxHashAlgo.SelectedIndex, _signData);
                        if ((extraDataExtracted.Hash2 != null) && (extraDataExtracted.Hash2.Data != null))
                            hash2 = extraDataExtracted.Hash2.Data;
                    }

                    // verify signature
                    string hash = "";
                    bool result = false;
                    try
                    {
                        switch (hashValue)
                        {
                            case HashValue.Combination:
                                // combine hash 1 & hash 2
                                byte[] hashCombi = new byte[_hash1.Length + hash2.Length];
                                Array.Copy(hash2, 0, hashCombi, 0, hash2.Length);
                                Array.Copy(_hash1, 0, hashCombi, hash2.Length, _hash1.Length);
                                // convert hash into string
                                foreach (byte value in hashCombi)
                                    hash += value.ToString("X2") + " ";
                                // verify
                                if (ComboBoxScheme.SelectedIndex == 0)//"PKCS1-V1_5 w/o OID"
                                {
                                    if (ComboBoxHashAlgo.SelectedIndex == 2)
                                        result = false;
                                    else
                                        result = csp.VerifyHash(hashCombi, oid, _signature);
                                }
                                else if (ComboBoxScheme.SelectedIndex == 2)//"PSS (PKCS1-V2_1)"
                                    result = rsa.VerifyHash(hashCombi, _signature);
                                break;
                            case HashValue.Hash1:
                                // convert hash into string
                                foreach (byte value in _hash1)
                                    hash += value.ToString("X2") + " ";
                                // verify
                                if (ComboBoxScheme.SelectedIndex != 2)//"PKCS1-V1_5 w/o OID" or "PKCS1-V1_5 with OID"
                                    result = csp.VerifyHash(_hash1, oid, _signature);
                                else //"PSS (PKCS1-V2_1)"
                                    result = rsa.VerifyHash(_hash1, _signature);
                                break;
                            case HashValue.Hash2:
                                // convert hash into string
                                foreach (byte value in hash2)
                                    hash += value.ToString("X2") + " ";
                                // verify
                                if (ComboBoxScheme.SelectedIndex != 2)//"PKCS1-V1_5 w/o OID" or "PKCS1-V1_5 with OID"
                                    result = csp.VerifyHash(hash2, oid, _signature);
                                else //"PSS (PKCS1-V2_1)"
                                    result = rsa.VerifyHash(hash2, _signature);
                                break;
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, Application.ProductName);
                        return;
                    }
                    finally
                    {
                        // display result
                        message = "The computed hash is:\n" + hash + "\n\nThe RSA signature is:\n" + signature;
                        if ((ComboBoxHashAlgo.SelectedIndex == 2) && (ComboBoxValue.SelectedIndex == 0) && (ComboBoxScheme.SelectedIndex != 2))
                            message += "\n\nThis demo application can't verify the combination of two SHA-512 signed with the PKCS1-V1_5 scheme!";
                        else if ((ComboBoxScheme.SelectedIndex == 2) && (Environment.OSVersion.Version.Major < 6))
                            message += "\n\nThis demo application can't verify an RSA-PSS signature on Windows XP!";
                        else if (result)
                            message += "\n\nThe RSA signature has been verified successfully.";
                        else
                            message += "\n\nThe RSA signature could not be verified.";
                        MessageBox.Show(message, Application.ProductName);
                    }

                    // display image of which the Hash 1 has been computed
                    if (CheckBoxCompHash.Checked)
                    {
                        Bitmap bitmap = _stPad.RSACreateHashedImage(_imageData, Color.Magenta, _parent.SignPad.PadType);
                        ImageView imageView = new ImageView();
                        imageView.BackgroundImage = bitmap;
                        imageView.Text = "This is the signed display content";
                        imageView.ShowDialog();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void CheckBoxSignAfterCapture_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSignAfterCapture.Checked && (ComboBoxValue.SelectedIndex != 1) && CheckBoxDemoCert.Checked)
            {
                string certID = "";
                if (!LoadDemoCert(ref certID))
                    CheckBoxSignAfterCapture.Checked = false;
            }
            ButtonCloseCapture.Enabled = (CheckBoxSignAfterCapture.Checked || CheckBoxSignData.Checked); ;
        }

        private void ComboBoxScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSigningOptions();
        }

        private void ComboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSigningOptions();
        }

        private void CheckSigningOptions()
        {
            bool signHash1 = false;
            bool signAfterCapture = false;
            if (ComboBoxValue.SelectedIndex == 2)// "Hash 2"
            {
                CheckBoxCompHash.Enabled = (_parent.SignPad.Open && _parent.SignPad.SupportsH2ContentSigning);
                CheckBoxCompHash.Checked = (_parent.SignPad.Open && _parent.SignPad.SupportsH2ContentSigning);
            }
            if (_hash1 == null)// no Hash 1 has been computed
            {
                if (CheckBoxCompHash.Checked)// Computing of Display Hash is enabled
                    signAfterCapture = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
                if (ComboBoxValue.SelectedIndex == 2)// "Hash 2"
                    signAfterCapture = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
            }
            else// Hash 1 has been computed
            {
                if (!CheckBoxCompHash.Checked)
                    signHash1 = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
                if (ComboBoxValue.SelectedIndex != 0)// "Hash 1" or "Hash 2"
                    signAfterCapture = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
                else// "Hash 1 + Hash 2"
                {
                    if (ComboBoxHashAlgo.SelectedIndex == 0)// "SHA 1"
                    {
                        if (ComboBoxScheme.SelectedIndex == 2)// "PSS (PKCS1-V2_1)"
                            signAfterCapture = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
                    }
                    else if (ComboBoxScheme.SelectedIndex != 1)//"PKCS1-V1_5 w/o OID" or "PSS (PKCS1-V2_1)"
                        signAfterCapture = (_parent.SignPad.Open && _parent.SignPad.SupportsRSA);
                }
            }
            ButtonSignHash1.Enabled = signHash1;
            CheckBoxSignAfterCapture.Enabled = signAfterCapture;
            if (!signAfterCapture)
                CheckBoxSignAfterCapture.Checked = signAfterCapture;
        }

        #endregion
        #endregion
        #region RSA Encryption

        private void CheckBoxDemoCert_CheckedChanged(object sender, EventArgs e)
        {
            ButtonEraseEncCert.Enabled = !CheckBoxDemoCert.Checked;
            ButtonLoadEncCert.Enabled = !CheckBoxDemoCert.Checked;
            ButtonSelectDecCert.Enabled = !CheckBoxDemoCert.Checked;
            _signData = null;
            if (CheckBoxDemoCert.Checked || ((_decCertPath != null) && (_decCertPath != "")))
                CheckBoxSignData.Enabled = true;
            else
            {
                CheckBoxSignData.Enabled = false;
                CheckBoxSignData.Checked = false;
            }
        }

        private void CheckBoxSignData_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSignData.Checked)
            {
                if (CheckBoxDemoCert.Checked)
                {
                    string strCertID = "";
                    if (!LoadDemoCert(ref strCertID))
                        CheckBoxSignData.Checked = false;
                }
                ButtonCloseCapture.Enabled = (CheckBoxSignAfterCapture.Checked || CheckBoxSignData.Checked);
            }
        }

        private void CheckBoxSecureMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!_changedProgrammatically)
            {
                try
                {
                    _stPad.SignatureSetSecureMode(CheckBoxSecureMode.Checked);
                }
                catch (STPadException exc)
                {
                    _changedProgrammatically = true;
                    if (CheckBoxSecureMode.Checked)
                        CheckBoxSecureMode.CheckState = CheckState.Unchecked;
                    else
                        CheckBoxSecureMode.CheckState = CheckState.Checked;
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
            }
            _changedProgrammatically = false;
        }

        private void CheckEncryptionOptions()
        {
            CheckBoxDemoCert.Enabled = _parent.SignPad.SupportsRSA;
            if (CheckBoxDemoCert.Checked)
            {
                CheckBoxSignData.Enabled = _parent.SignPad.SupportsRSA;
                ButtonEraseEncCert.Enabled = false;
                ButtonLoadEncCert.Enabled = false;
                ButtonSelectDecCert.Enabled = false;
            }
            else
            {
                if (_decCertPath != null)
                    CheckBoxSignData.Enabled = _parent.SignPad.SupportsRSA;
                else
                    CheckBoxSignData.Enabled = false;
                ButtonEraseEncCert.Enabled = _parent.SignPad.SupportsRSA;
                ButtonLoadEncCert.Enabled = _parent.SignPad.SupportsRSA;
                ButtonSelectDecCert.Enabled = _parent.SignPad.SupportsRSA;
            }
            if (!CheckBoxSignData.Enabled)
                CheckBoxSignData.Checked = false;
        }

        #region Encryption Certificate

        private void ButtonEraseEncCert_Click(object sender, EventArgs e)
        {
            try
            {
                _stPad.RSASetEncryptionCert();
                CheckBoxSignData.Checked = false;
                _signData = null;
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode != -34)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
                else    // error pad is password protected
                {
                    PasswordPrompt passwordWindow = new PasswordPrompt(_passwordPadText);
                    passwordWindow.StartPosition = FormStartPosition.CenterParent;
                    try
                    {
                        if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                        {
                            _stPad.RSASetEncryptionCertPw(passwordWindow.PasswordHandover);
                            CheckBoxSignData.Checked = false;
                            _signData = null;
                        }
                    }
                    catch (STPadException exceptPad)
                    {
                        MessageBox.Show(exceptPad.Message, Application.ProductName);
                    }
                    finally
                    {
                        SafeDeletePassword(passwordWindow);
                    }
                }
            }
        }

        private void ButtonLoadEncCert_Click(object sender, EventArgs e)
        {
            DialogOpen.Title = "Open certificate file";
            DialogOpen.FileName = "";
            DialogOpen.Filter = "Public certificate (*.CER)|*.cer";
            if (DialogOpen.ShowDialog() != DialogResult.OK)
                return;
            if (DialogOpen.FileName == "")
                return;

            try
            {
                _stPad.RSASetEncryptionCert(DialogOpen.FileName);
                _signData = null;
            }
            catch (STPadException exc)
            {
                if (exc.ErrorCode != -34)
                {
                    MessageBox.Show(exc.Message, Application.ProductName);
                }
                else    // error pad is password protected
                {
                    PasswordPrompt passwordWindow = new PasswordPrompt(_passwordPadText);
                    passwordWindow.StartPosition = FormStartPosition.CenterParent;
                    try
                    {
                        if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                        {
                            _stPad.RSASetEncryptionCertPw(DialogOpen.FileName, passwordWindow.PasswordHandover);
                            _signData = null;
                        }
                    }
                    catch (STPadException exceptPad)
                    {
                        MessageBox.Show(exceptPad.Message, Application.ProductName);
                    }
                    finally
                    {
                        SafeDeletePassword(passwordWindow);
                    }
                }
            }
        }

        private void ButtonGetEncCertID_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("The ID of the stored encryption certificate is:\n" + _stPad.RSAGetEncryptionCertId(), Application.ProductName);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                return;
            }
        }

        #endregion
        #region Decryption Certificate

        private bool LoadDemoCert(ref string certId)
        {
            try
            {
                certId = _stPad.RSAGetEncryptionCertId();
            }
            catch
            {
            }
            if ((certId == null) || (!certId.Equals("C=Germany, S=NRW, L=Ratingen, O=signotec GmbH, E=info@signotec.de, CN=signoPAD-API Demo Certificate, SNR=5F3E2FA039107B864A1DF5D74290E283")))
            {
                try
                {
                    //_stPad.RSASetEncryptionCert(new X509Certificate2(Emr.SignPad.Properties.Resources.PublicCert));
                }
                catch (STPadException exc)
                {
                    if (exc.ErrorCode != -34)
                    {
                        MessageBox.Show(exc.Message, Application.ProductName);
                        return false;
                    }
                    else    // error pad is password protected
                    {
                        PasswordPrompt passwordWindow = new PasswordPrompt(_passwordPadText);
                        passwordWindow.StartPosition = FormStartPosition.CenterParent;
                        try
                        {
                            if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                            {
                                //_stPad.RSASetEncryptionCertPw(new X509Certificate2(Emr.SignPad.Properties.Resources.PublicCert), passwordWindow.PasswordHandover);
                            }
                        }
                        catch (STPadException exceptPad)
                        {
                            MessageBox.Show(exceptPad.Message, Application.ProductName);
                            return false;
                        }
                        finally
                        {
                            SafeDeletePassword(passwordWindow);
                        }
                    }
                }
                certId = null;
            }
            return true;
        }

        private void ButtonSelectDecCert_Click(object sender, EventArgs e)
        {
            try
            {
                string id = _stPad.RSAGetEncryptionCertId();
                DialogOpen.Title = "Select private certificate with the ID \"" + id + "\"...";
                DialogOpen.FileName = "";
                DialogOpen.Filter = "Private certificate (*.PFX)|*.pfx";
                if ((DialogOpen.ShowDialog() == DialogResult.OK) && (DialogOpen.FileName != ""))
                {
                    _decCertPath = DialogOpen.FileName;
                    CheckBoxSignData.Enabled = true;
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
                CheckBoxSignData.Checked = false;
            }
        }

        #endregion
        #endregion
        
        private void buttonSetPassword_Click(object sender, EventArgs e)
        {
            string label = "New password (0-9, a-e, A-E): ";
            PasswordPrompt passwordWindow = new PasswordPrompt(label, true);
            passwordWindow.StartPosition = FormStartPosition.CenterParent;
            try
            {
                if (passwordWindow.ShowDialog(this) == DialogResult.OK)
                    _stPad.RSASetSignPassword(passwordWindow.PasswordHandover, passwordWindow.PasswordHandoverOptional, passwordWindow.MaxWrongEntries);
            }
            catch (STPadException except)
            {
                MessageBox.Show(except.Message, Application.ProductName);
            }
            finally
            {
                SafeDeletePassword(passwordWindow);
            }
        }

        // dispose SecureStrings used by PasswordPrompt-Form immediately after use
        public void SafeDeletePassword(PasswordPrompt lastWindow)
        {
            if (lastWindow.PasswordHandover != null)
                lastWindow.PasswordHandover.Dispose();
            if (lastWindow.PasswordHandoverOptional != null)
                lastWindow.PasswordHandoverOptional.Dispose();
        }

        public bool UseSignData
        {
            get { return CheckBoxSignData.Checked; }
        }

        public byte[] SignData
        {
            get { return _signData; }
            set { _signData = value; }
        }

        public bool SignAfterCapture
        {
            get { return CheckBoxSignAfterCapture.Checked; }
        }

        public bool ComputeHash
        {
            get { return CheckBoxCompHash.Checked; }
        }

        public bool DemoCert
        {
            get { return CheckBoxDemoCert.Checked; }
        }

        public String CertPath
        {
            get { return _decCertPath; }
        }

        private void RSAOptions_OnLoad(object sender, EventArgs e)
        {
            comboBoxPwMinLength.Text = _stPad.RSASignPasswordLength.ToString();
        }

        private void comboBoxPwMinLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int minRsaPassLength = 0;
                bool succ = int.TryParse(comboBoxPwMinLength.Text, out minRsaPassLength);

                if (succ)
                    _stPad.RSASignPasswordLength = minRsaPassLength;
                else
                    comboBoxPwMinLength.Text = _stPad.RSASignPasswordLength.ToString();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message, Application.ProductName);
            }
        }
    }
}