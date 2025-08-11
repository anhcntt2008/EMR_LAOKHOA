using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Ca.eSign
{
    class ESignCloudConstant
    {
        public static int AUTHORISATION_METHOD_SMS = 1;
        public static int AUTHORISATION_METHOD_EMAIL = 2;
        public static int AUTHORISATION_METHOD_MOBILE = 3;
        public static int AUTHORISATION_METHOD_PASSCODE = 4;
        public static int AUTHORISATION_METHOD_UAF = 5;

        public static int ASYNCHRONOUS_CLIENTSERVER = 1;
        public static int ASYNCHRONOUS_SERVERSERVER = 2;
        public static int SYNCHRONOUS = 3;

        public static String MIMETYPE_PDF = "application/pdf";
        public static String MIMETYPE_XML = "application/xml";
        public static String MIMETYPE_XHTML_XML = "application/xhtml+xml";

        public static String MIMETYPE_BINARY_WORD = "application/msword";
        public static String MIMETYPE_OPENXML_WORD = "application/ vnd.openxmlformats-officedocument.wordprocessingml.document";
        public static String MIMETYPE_BINARY_POWERPOINT = "application/vnd.ms-powerpoint";
        public static String MIMETYPE_OPENXML_POWERPOINT = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        public static String MIMETYPE_BINARY_EXCEL = "application/vnd.ms-excel";
        public static String MIMETYPE_OPENXML_EXCEL = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public static String MIMETYPE_MSVISIO = "application/vnd.visio";

        public static String MIMETYPE_SHA1 = "application/sha1-binary";
        public static String MIMETYPE_SHA256 = "application/sha256-binary";
        public static String MIMETYPE_SHA384 = "application/sha384-binary";
        public static String MIMETYPE_SHA512 = "application/sha512-binary";

        public static Dictionary<int, string> ResponseMessages = new Dictionary<int, string>()
        {
                {0,"Thành công - SUCCESSFULLY"},
                {1000,"Địa chỉ IP không hợp lệ - INVALID IP ADDRESS"},
                {1001,"Chứng thư không hợp lệ - INVALID CREDENTIAL DATA"},
                {1002,"Tham số không hợp lệ - INVALID PARAMS"},
                {1003,"Lỗi không xác định - UNEXPECTED EXCEPTION"},
                {1004,"Mã xác thực không hợp lệ - INVALID AUTHORIZATION CODE"},
                {1005,"Tài khoản bị khóa - AUTHORIZATION BLOCKED"},
                {1006,"Quá trình xác thực quá lâu - AUTHORIZATION CODE TIMEOUT"},
                {1007,"Yêu cầu đã được chấp nhận - REQUEST ACCEPTED"},
                {1008,"Không tìm thấy người dùng - AGREEEMENT NOT FOUND"},
                {1009,"Chứng thư chưa được đăng ký - CERTIFICATE IS NOT ENROLLED"},
                {1010,"Tìm thấy người dùng - AGREEMENT EXISTED"},
                {1011,"Chức năng này không được hỗ trợ - UNSUPPORTED OPERATION"},
                {1012,"Truy cập bị từ chối - ACCESS DENIED"},
                {1013,"Người dùng không sẵn sàng - AGREEMENT NOT READY"},
                {1014,"Chứng thư đã hết hạn - CERTIFICATE IS EXPIRED"},
                {1015," - BILLCODE TIMEOUT DUE TO UNEXPECTED EXCEPTION WHILE SIGNING"},
                {1016,"Tập tin đang được xử lý - FILE IS BEING PROCESSED"},
                {1017,"Người dùng đã bị thu hồi - AGREEMENT REVOKED"},
                {1018,"Thành công. Mật khẩu cần được thay đổi. - SUCCESSFULLY. YOUR PASSCODE NEED TO BE CHANGED"},
                {1019,"Chức năng này không được phép truy cập - FUNCTION ACCESS DENIED"},
                {1020," - FAILED TO CHECK REVOCATION"},
                {1021,"Chứng thư đã bị thu hồi - CERTIFICATE REVOKED"},
                {1022,"Chứng thư không xác định - CERTIFICATE UNKNOWN"},
                {1023," - SHARED AGREEMENT NOT FOUND"},
                {1024," - SHARED AGREEMENT INVALID SHARED MODE"},
                {1025,"Không tìm thấy tập tin - FILE NOT FOUND"},

        };
    }
}
