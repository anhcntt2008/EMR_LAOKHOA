using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BOSLib;
using Clas.Model.BHYT;
using Clas.Repository.HttpApi;

namespace Clas.Business.BHYT
{
    public class BHYTManager
    {
        private readonly string _bhytUrl = "http://egw.baohiemxahoi.gov.vn/";
        private readonly string _password = "e10adc3949ba59abbe56e057f20f883e".ToUpper();
        private readonly string _username = "19010_BV";
        readonly Crypto _cryp = new Crypto();

        public BHYTManager(string userName = null, string password = null)
        {
            if (!string.IsNullOrEmpty(userName))
                _username = userName;
            if (!string.IsNullOrEmpty(password))
            {
                var xpassword = _cryp.Decrypt(password);
                _password = GenMD5HashFromString(xpassword);
            }
        }

        private string GenMD5HashFromString(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.Default.GetBytes(input));

            //get hash result after compute it
            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in result)
                strBuilder.Append(t.ToString("x2"));

            return strBuilder.ToString();
        }

        public KQPhienLamViec GetPhienLamViec()
        {
            var client = new NetHttp(_bhytUrl);
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            var result = client.Post<KQPhienLamViec, ApiToken>("api/token/take", headers,
                new ApiToken {username = _username, password = _password});
            return result;
        }

        public KQNhanLichSuKCB GetLichSuKCB(ApiKey apiKey, ApiTheBHYT model)
        {
            var client = new NetHttp(_bhytUrl);
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            var data = string.Format("token={0}&id_token={1}&username={2}&password={3}", apiKey.access_token,
                apiKey.id_token, _username, _password);
            var result = client.Post<KQNhanLichSuKCB, ApiTheBHYT>("api/egw/nhanLichSuKCB?" + data, headers, model);
            return result;
        }

        public LichSuKCBChiTiet KQNhanHoSoKCBChiTiet(ApiKey apiKey, LichSuKCB model)
        {
            var client = new NetHttp(_bhytUrl);
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            var data = string.Format("token={0}&id_token={1}&username={2}&password={3}&maHoSo={4}", apiKey.access_token,
                apiKey.id_token, _username, _password, model.maHoSo);
            var result = client.Post<LichSuKCBChiTiet, LichSuKCB>("api/egw/nhanHoSoKCBChiTiet?" + data, headers, null);
            return result;
        }

        public GoiHoSoGiamDinhResultModel ImportReportToBhyt(ApiKey apiKey, GoiHoSoGiamDinhModel model)
        {
            var client = new NetHttp(_bhytUrl);
            var targetUrl = "api/egw/guiHoSoGiamDinh?";
            var headers = new Dictionary<string, string> {{"Content-Type", "application/json"}};
            var file = new FileInfo(model.FilePath);
            byte[] buffer;
            using (var stream = file.OpenRead())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    buffer = memoryStream.ToArray();
                }
            }
            string data =
                $"token={apiKey.access_token}&id_token={apiKey.id_token}&username={_username}&password={_password}&loaiHoSo={model.LoaiHoSo}&maTinh={model.MaTinh}&maCSKCB={model.MaCsKcb}";
            var result = client.Post<GoiHoSoGiamDinhResultModel, object>(targetUrl + data, headers, buffer);
            return result;
        }
    }
}