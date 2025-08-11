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
// Version: 8.5.0.0
// Date:    2020-03-27

using System;
using signotec.STPadLibNet;

namespace Emr.SignPad
{
    public enum PadModel
    {
        Sigma,
        Zeta,
        Omega,
        Gamma,
        Delta,
        Alpha
    }

    public class SignPad
    {
        private STPadLib _stPad = null;
        private int _index = -1;
        private int _padType = 0;
        private int _connectionType = 0;
        private string _serial = "";
        private int _fwMajor = 0;
        private int _fwMinor = 0;
        private bool _open = false;

        public SignPad()
        {
        }

        public SignPad(STPadLib stPad, int index)
        {
            _stPad = stPad;
            _index = index;

            // get serial and type of selected device
            _stPad.DeviceGetInfo(out _serial, out _padType, index);

            // get connection type
            _connectionType = _stPad.DeviceGetConnectionType(index);

            // get firmware version
            string version = _stPad.DeviceGetVersion(index);
            string[] versionArray = version.Split('.');
            if ((versionArray != null) && (versionArray.Length > 1))
            {
                _fwMajor = Int32.Parse(versionArray[0]);
                _fwMinor = Int32.Parse(versionArray[1]);
            }
        }

        public int PadType
        {
            get { return _padType; }
        }

        public PadModel PadModel
        {
            get
            {
                switch (PadType)
                {
                    case 1:
                    case 2:
                        return PadModel.Sigma;
                    case 5:
                    case 6:
                        return PadModel.Zeta;
                    case 11:
                    case 12:
                        return PadModel.Omega;
                    case 15:
                    case 16:
                        return PadModel.Gamma;
                    case 21:
                    case 22:
                    case 23:
                        return PadModel.Delta;
                    case 31:
                    case 32:
                    case 33:
                        return PadModel.Alpha;
                    default:
                        throw new Exception("This pad type is not supported by this demo application!");
                };
            }
        }

        public string PadName
        {
            get
            {
                switch (_padType)
                {
                    case 1:
                        return "Sigma USB";
                    case 2:
                        return "Sigma Serial";
                    case 5:
                        return "Zeta USB";
                    case 6:
                        return "Zeta Serial";
                    case 11:
                        return "Omega USB";
                    case 12:
                        return "Omega Serial";
                    case 15:
                        return "Gamma USB";
                    case 16:
                        return "Gamma Serial";
                    case 21:
                        return "Delta USB";
                    case 22:
                        return "Delta Serial";
                    case 23:
                        return "Delta IP";
                    case 31:
                        return "Alpha USB";
                    case 32:
                        return "Alpha Serial";
                    case 33:
                        return "Alpha IP";
                    default:
                        return "Unkown pad type " + _padType;
                }
            }
        }

        public string ConnectionName
        {
            get
            {
                switch (_connectionType)
                {
                    case 0:
                        return "HID";
                    case 1:
                        return "USB";
                    case 2:
                        return String.Format("COM{0}", _stPad.DeviceGetComPort(_index));
                    case 3:
                        return _stPad.DeviceGetIPAddress(_index);
                    default:
                        return "Unkown connection type " + _connectionType;
                }
            }
        }

        public bool USB
        {
            get { return (_connectionType == 1); }
        }

        public bool IP
        {
            get { return (_connectionType == 3); }
        }

        public string Serial
        {
            get { return _serial; }
        }

        public bool FastConnection
        {
            get { return (USB || (PadModel == PadModel.Sigma) || (((PadModel == PadModel.Delta) || (PadModel == PadModel.Alpha)) && IP)); }
        }

        public string Firmware
        {
            get { return String.Format("{0}.{1}", _fwMajor, _fwMinor); }
        }

        public int DefaultPenWidth
        {
            get
            {
                switch (PadModel)
                {
                    case PadModel.Omega:
                    case PadModel.Gamma:
                    case PadModel.Delta:
                        return 2;
                    default:
                        return 1;
                }
            }
        }

        public int DefaultFontSize
        {
            get
            {
                switch (PadModel)
                {
                    case PadModel.Sigma:
                        return 20;
                    default:
                        return 40;
                }
            }
        }

        public bool HasDisplay
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).HasDisplay;
            }
        }

        public bool HasColorDisplay
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).HasColorDisplay;
            }
        }

        public bool HasBacklight
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).HasBacklight;
            }
        }

        public bool SupportsVerticalScrolling
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsVerticalScrolling;
            }
        }

        public bool SupportsHorizontalScrolling
        {
            get 
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsHorizontalScrolling;
            }
        }

        public bool SupportsPenScrolling
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsPenScrolling;
            }
        }

        public bool SupportsServiceMenu
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsServiceMenu;
            }
        }

        public bool SupportsKeypad
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsKeypad;
            }
        }

        public bool SupportsKeypad32
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsKeypad32;
            }
        }

        public bool SupportsRSA
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsRSA;
            }
        }
                public bool SupportsRSASignPassword
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsRSASignPassword;
            }
        }

        public bool SupportsContentSigning
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsContentSigning;
            }
        }

        public bool SupportsH2ContentSigning
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).SupportsH2ContentSigning;
            }
        }

        public bool Supports4096BitKeys
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).Supports4096BitKeys;
            }
        }

        public bool HasNFCReader
        {
            get
            {
                if (_stPad == null)
                    return false;
                else
                    return _stPad.DeviceGetCapabilities(_index).HasNFCReader;
            }
        }

        public bool Open
        {
            get {return _open;}
        }

        public bool IsFirmware(int fwMajor, int fwMinor)
        {
            return ((_fwMajor > fwMajor) || ((_fwMajor == fwMajor) && (_fwMinor >= fwMinor)));
        }

        public void DeviceOpen()
        {
            if (_stPad == null)
                return;

            _stPad.DeviceOpen(_index);
            _open = true;
            _stPad.DeviceDisconnected += new DeviceDisconnectedEventHandler(STPad_DeviceDisconnected);
        }

        public void DeviceClose()
        {
            if (_stPad == null)
                return;

            try
            {
                _stPad.DeviceClose(_index);
                _stPad.DeviceDisconnected -= new DeviceDisconnectedEventHandler(STPad_DeviceDisconnected);
                _open = false;
            }
            catch (STPadException exc)
            {
                if (!(exc.ErrorCode == -5) || (exc.ErrorCode == -22))
                    throw exc;
            }
        }

        private void STPad_DeviceDisconnected(object sender, DeviceDisconnectedEventArgs e)
        {
            if (e.index == _index)
                _open = false;
        }
    }
}
