using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Model.Doctor24x7
{
    public enum Doctor24x7ErrorCode
    {
        FAILURE_EXCEPTION = -1,
        FAILURE_UNKNOWN = -2,
        FAILURE_DISABLE_USER = -3,
        FAILURE_INVALID_PARAMS = 1,
        FAILURE_SESSION_INVALID = 2,
        FAILURE_LOGIN_FAIL = 3,
        FAILURE_OBJECT_NOT_FOUND = 4,
        FAILURE_PERMISSION_DENY = 5,
        FAILURE_INVALID_PHONE = 7,
        FAILURE_INVALID_EMAIL = 8,
        FAILURE_USER_NOT_FOUND = 9,
        FAILURE_PHONE_EXISTED = 11,
        FAILURE_EMAIL_EXISTED = 12,
        FAILURE_USER_EXISTED = 13,
        FAILURE_FB_ACCESS_TOKEN_INVALID = 14,
        FAILURE_INVALID_LOCATION = 15,
        FAILURE_HOSPITAL_NOT_FOUND = 16,
        FAILURE_USERNAME_EXISTED = 17,
        FAILURE_IDNO_EXISTED = 18,
        FAILURE_FACEBOOK_ID_EXISTED = 19,
        FAILURE_NAME_EMPTY = 20,
        FAILURE_CITY_EMPTY = 21,
        FAILURE_ADDRESS_EMPTY = 22,
        FAILURE_PHOTO_EMPTY = 23,
        FAILURE_FIRSTNAME_EMPTY = 24,
        FAILURE_LASTNAME_EMPTY = 25,
        FAILURE_GENDER_EMPTY = 26,
        FAILURE_BIRTHDAY_EMPTY = 27,
        FAILURE_USERNAME_EMPTY = 28,
        FAILURE_PASSWORD_EMPTY = 29,
        FAILURE_HOSPITAL_ID_EMPTY = 30,
        FAILURE_IDNO_EMPTY = 31,
        FAILURE_CONTENT_EMPTY = 32,
        FAILURE_INVALID_STARTDATE = 33,
        FAILURE_INVALID_ENDDATE = 34,
        FAILURE_INVALID_USERNAME = 35,
        FAILURE_INVALID_USER_TYPE = 36,
        FAILURE_INVALID_ROLES = 37,
        FAILURE_PROMOTION_NOT_FOUND = 38,
        FAILURE_CHECKUP_TYPE_NOT_FOUND = 39,
        FAILURE_SYMPTOM_EMPTY = 40,
        FAILURE_CHECKUP_TYPE_EMPTY = 41,
        FAILURE_PATIENT_TYPE_EMPTY = 42,
        FAILURE_INVALID_PATIENT_TYPE = 43,
        FAILURE_DOCTOR_NOT_FOUND = 44,
        FAILURE_SERVICE_TYPE_EMPTY = 45,
        FAILURE_INVALID_SERVICE_TYPE = 46,
        FAILURE_INVALID_CHECKUP_TYPE = 47,
        FAILURE_HOSPITAL_REGISTERED = 48,
        FAILURE_DOCTOR_ID_EMPTY = 49,
        FAILURE_INVALID_APPOINTMENT_DATE = 50,
        FAILURE_INVALID_GENDER = 51,
        FAILURE_ID_EMPTY = 52,
        FAILURE_CHECKUP_NOT_FOUND = 53,
        FAILURE_INVALID_DOCTOR = 54,
        FAILURE_CARD_ID_EMPTY = 55,
        FAILURE_PATIENT_ID_EMPTY = 56,
        FAILURE_FIRST_NAME_EMPTY = 57,
        FAILURE_LAST_NAME_EMPTY = 58,
        FAILURE_EMAIL_EMPTY = 59,
        FAILURE_PHONE_EMPTY = 60,
        FAILURE_INVALID_IDNO = 61,
        FAILURE_CARD_EXISTED = 62,
        FAILURE_CARD_ENTER_PIN = 63,
        FAILURE_CARD_ENTER_OTP = 64,
        FAILURE_CARD_NOT_FOUND = 65,
        FAILURE_PIN_OR_OTP_EMPTY = 66,
        FAILURE_CARD_INCORRECT_PIN = 67,
        FAILURE_INVALID_START_MORNING_HOUR = 68,
        FAILURE_INVALID_START_MORNING_MINUTE = 69,
        FAILURE_INVALID_END_MORNING_HOUR = 70,
        FAILURE_INVALID_END_MORNING_MINUTE = 71,
        FAILURE_INVALID_START_AFTERNOON_HOUR = 72,
        FAILURE_INVALID_START_AFTERNOON_MINUTE = 73,
        FAILURE_INVALID_END_AFTERNOON_HOUR = 74,
        FAILURE_INVALID_END_AFTERNOON_MINUTE = 75,
        FAILURE_INVALID_CHECKUP_INTERVAL = 76,
        FAILURE_INVALID_REGULAR_PATIENT_THRESHOLD = 77,
        FAILURE_NO_DOCTOR_FOR_CHECKUP_TYPE = 78,
        FAILURE_INVALID_PRICE = 79,
        FAILURE_INVALID_HOSPITAL = 80,
        FAILURE_BUSY_DOCTOR = 81,
        FAILURE_INVALID_PASSWORD_LENGTH = 82,
        FAILURE_INVALID_OLD_PASSWORD = 83,
        FAILURE_CHECKUP_ID_EMPTY = 84,
        FAILURE_INVALID_PAYMENT_PASSWORD = 85,
        FAILURE_PAYMENT_PASSWORD_NOT_SET = 86,
        FAILURE_HOSPITAL_NOT_REGISTERED_PAYMENT = 87,
        FAILURE_CHECKUP_PAID = 88,
        FAILURE_INVALID_CARD = 89,
        FAILURE_NOT_ENOUGH_MONEY_FOR_PAYMENT = 90,
        FAILURE_INVALID_ZERO_MONEY = 91,
        FAILURE_INVALID_PATIENT = 92,
        FAILURE_CHECKUP_FINISHED = 93,
        FAILURE_SCB_MID_EMPTY = 94,
        FAILURE_SCB_TID_EMPTY = 95,
        FAILURE_STORE_MID_NOT_FOUND = 96,
        FAILURE_STORE_REGISTERED = 97,
        FAILURE_FACEBOOK_ID_EMPTY = 98,
        FAILURE_TYPE_EMPTY = 99,
        FAILURE_DEACTIVE_REFERENCE = 100,
        FAILURE_HASH_EMPTY = 101,
        FAILURE_HASH_EXPIRED = 102,
        FAILURE_CITY_ID_EMPTY = 103,
        FAILURE_DISTRICT_ID_EMPTY = 104,
        FAILURE_INVALID_CITY = 105,
        FAILURE_INVALID_DISTRICT = 106,
        FAILURE_INVALID_CHECKUP_FEE = 107,
        FAILURE_INVALID_SCHEDULING_FEE = 108,
        FAILURE_NAME_EXISTED = 109,
        FAILURE_SEARCHED_FOR_DOCTORS_EMPTY = 110,
        FAILURE_CITY_NOT_FOUND = 111,
        FAILURE_INVALID_DATE = 112,
        FAILURE_INVALID_QUALITY = 113,
        FAILURE_OVERLAP_TIME = 114,
        FAILURE_SCHEDULE_EMPTY = 115,
        FAILURE_PARENT_ID_EMPTY = 116,
        FAILURE_KEYWORD_ID_EMPTY = 117,
        FAILURE_CHANNEL_EMPTY = 118,
        FAILURE_PLATFORM_EMPTY = 119,
        FAILURE_INVALID_SCHEDULING = 120,
        FAILURE_INVALID_STATUS = 121,
        FAILURE_KEYWORD_EMPTY = 122,
        FAILURE_DOCTOR_NAME_EMPTY = 123,
        FAILURE_HOSPITAL_NAME_EMPTY = 124,
        FAILURE_INVALID_AGE = 125,
        FAILURE_CHECKUP_TYPE_REFERRED = 126,
        FAILURE_INVALID_FEE = 127,
        FAILURE_USER_ID_EMPTY = 128,
        FAILURE_HOSPITAL_REFERRED = 129,
        FAILURE_TITLE_EMPTY = 130,
        FAILURE_IS_ONLINE_EMPTY = 131,
        FAILURE_URL_EMPTY = 132,
        FAILURE_HASH_USED = 133,
        FAILURE_RESULT_EMPTY = 134,
        FAILURE_INVALID_KEYWORD = 135,
        FAILURE_OBJECT_REFERRED = 136,
        FAILURE_INVALID_MAX_REGISTRATION_PER_DEVICE = 137,
        FAILURE_INVALID_MAX_CHECKUP_PER_DATE = 138,
        FAILURE_TIME_SPAN_EMPTY = 139,
        FAILURE_INVALID_TIME_SPAN = 140,
        FAILURE_NOTIFICATION_TIME_ID_EMPTY = 141,
        FAILURE_YEAR_EMPTY = 142,
        FAILURE_MONTH_EMPTY = 143,
        FAILURE_INVALID_YEAR = 144,
        FAILURE_INVALID_MONTH = 145,
        FAILURE_SMALL_MONEY = 146,
        FAILURE_SMALL_INTERVAL = 147,
        FAILURE_INVALID_TIMEZONE = 148,
        FAILURE_INVALID_EXCLUDED_DATE = 149,
        FAILURE_INVALID_DOCTOR_CHECKUP_TYPE = 150,
        FAILURE_INVALID_SUPPORT_REQUEST_REPLIED = 151,
        FAILURE_INVALID_AMOUNT = 152,
        FAILURE_CARD_TOKEN_EMPTY = 153,
        FAILURE_INVALID_POINT = 154,
        FAILURE_INVALID_CHECKUP_RATED = 155,
        FAILURE_INVALID_CHECKUP_STATUS_RATED = 156,
        FAILURE_USER_ACTIVED = 157,
        FAILURE_INVALID_OTP = 158,
        FAILURE_FAIL_IN_SEND_OTP = 159,
        FAILURE_PIN_TRIES_EXCEEDED = 160,
        FAILURE_INVALID_PATIENT_APP_TABS = 161,
        FAILURE_ROOM_NOT_FOUND = 162,
        FAILURE_INVALID_ROOM = 163,
        FAILURE_INVALID_REFUNDED = 164,
        FAILURE_REFUND_PERSON_EMPTY = 165,
        FAILURE_CHECKUP_UNPAID = 166,
        FAILURE_FILE_EMPTY = 167,
        FAILURE_INVALID_FILE_EXTENSION = 168,
        FAILURE_EMAIL_OR_PHONE_EXISTED = 169,
        FAILURE_DESCRIPTION_EMPTY = 170,
        FAILURE_INVALID_FILE = 171,
        FAILURE_INVALID_META_DATA_FILE = 172,
        FAILURE_QUESTION_NOT_FOUND = 173,
        FAILURE_ANSWER_NOT_FOUND = 174,
        FAILURE_SUBJECT_EMPTY = 175,
        FAILURE_USER_LINKED = 176,
        FAILURE_INVALID_USER_PERMISSION = 177,
        FAILURE_BODY_EMPTY = 178,
        FAILURE_INVALID_EMAIL_GROUP = 179,
        FAILURE_PARTICIPANTNAME_EMPTY = 181,
        FAILURE_MAILTO_EMPTY = 182,
        FAILURE_REGISTEREDDATE_EMPTY = 183,
        FAILURE_SECURITYQUESTION_EMPTY = 184,
        FAILURE_IDENTITYCODE_EMPTY = 185,
        FAILURE_EMAIL_NOT_EXISTED = 186,
        FAILURE_USER_NOT_ACTIVED = 187,
        FAILURE_PHONE_NOT_EXISTED = 188,
        FAILURE_USERNAME_NOT_EXISTED = 189,
        FAILURE_PHONE_EXISTED_AND_NOT_ACTIVE = 190,
        FAILURE_PHONE_EXISTED_AND_ACTIVED = 191,
        FAILURE_EMAIL_EXISTED_AND_NOT_ACTIVE = 192,
        FAILURE_EMAIL_EXISTED_AND_ACTIVED = 193,
        FAILURE_EMAIL_AND_PHONE_EXISTED_AND_NOT_ACTIVE = 194,
        FAILURE_NO_RECIPIENTS = 180
    }

    public static class ErrorCodeExtensions
    {
        public static string GetMessage(this Doctor24x7ErrorCode errorCode)
        {
            string message = "Có lỗi phát sinh: " + errorCode.ToString() + " (" + errorCode + ")";
            switch (errorCode)
            {
                case Doctor24x7ErrorCode.FAILURE_EXCEPTION:
                    break;
                case Doctor24x7ErrorCode.FAILURE_UNKNOWN:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DISABLE_USER:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PARAMS:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SESSION_INVALID:
                    break;
                case Doctor24x7ErrorCode.FAILURE_LOGIN_FAIL:
                    break;
                case Doctor24x7ErrorCode.FAILURE_OBJECT_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PERMISSION_DENY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PHONE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_EMAIL:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USER_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PHONE_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USER_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FB_ACCESS_TOKEN_INVALID:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_LOCATION:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HOSPITAL_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USERNAME_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_IDNO_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FACEBOOK_ID_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_NAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CITY_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_ADDRESS_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PHOTO_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FIRSTNAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_LASTNAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_GENDER_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_BIRTHDAY_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USERNAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PASSWORD_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HOSPITAL_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_IDNO_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CONTENT_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_STARTDATE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_ENDDATE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_USERNAME:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_USER_TYPE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_ROLES:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PROMOTION_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_TYPE_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SYMPTOM_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_TYPE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PATIENT_TYPE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PATIENT_TYPE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DOCTOR_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SERVICE_TYPE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_SERVICE_TYPE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CHECKUP_TYPE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HOSPITAL_REGISTERED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DOCTOR_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_APPOINTMENT_DATE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_GENDER:
                    break;
                case Doctor24x7ErrorCode.FAILURE_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_DOCTOR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PATIENT_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FIRST_NAME_EMPTY:
                    message = "Thông tin Họ tên đang bị trống";
                    break;
                case Doctor24x7ErrorCode.FAILURE_LAST_NAME_EMPTY:
                    message = "Thông tin Họ tên đang bị trống";
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_EMPTY:
                    message = "Thông tin Email đang bị trống";
                    break;
                case Doctor24x7ErrorCode.FAILURE_PHONE_EMPTY:
                    message = "Thông tin điện thoại đang bị trống";
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_IDNO:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_ENTER_PIN:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_ENTER_OTP:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PIN_OR_OTP_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_INCORRECT_PIN:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_START_MORNING_HOUR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_START_MORNING_MINUTE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_END_MORNING_HOUR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_END_MORNING_MINUTE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_START_AFTERNOON_HOUR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_START_AFTERNOON_MINUTE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_END_AFTERNOON_HOUR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_END_AFTERNOON_MINUTE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CHECKUP_INTERVAL:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_REGULAR_PATIENT_THRESHOLD:
                    break;
                case Doctor24x7ErrorCode.FAILURE_NO_DOCTOR_FOR_CHECKUP_TYPE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PRICE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_HOSPITAL:
                    break;
                case Doctor24x7ErrorCode.FAILURE_BUSY_DOCTOR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PASSWORD_LENGTH:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_OLD_PASSWORD:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PAYMENT_PASSWORD:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PAYMENT_PASSWORD_NOT_SET:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HOSPITAL_NOT_REGISTERED_PAYMENT:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_PAID:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CARD:
                    break;
                case Doctor24x7ErrorCode.FAILURE_NOT_ENOUGH_MONEY_FOR_PAYMENT:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_ZERO_MONEY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PATIENT:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_FINISHED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SCB_MID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SCB_TID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_STORE_MID_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_STORE_REGISTERED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FACEBOOK_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_TYPE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DEACTIVE_REFERENCE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HASH_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HASH_EXPIRED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CITY_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DISTRICT_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CITY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_DISTRICT:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CHECKUP_FEE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_SCHEDULING_FEE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_NAME_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SEARCHED_FOR_DOCTORS_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CITY_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_DATE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_QUALITY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_OVERLAP_TIME:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SCHEDULE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PARENT_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_KEYWORD_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHANNEL_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PLATFORM_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_SCHEDULING:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_STATUS:
                    break;
                case Doctor24x7ErrorCode.FAILURE_KEYWORD_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DOCTOR_NAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HOSPITAL_NAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_AGE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_TYPE_REFERRED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_FEE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USER_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HOSPITAL_REFERRED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_TITLE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_IS_ONLINE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_URL_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_HASH_USED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_RESULT_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_KEYWORD:
                    break;
                case Doctor24x7ErrorCode.FAILURE_OBJECT_REFERRED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_MAX_REGISTRATION_PER_DEVICE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_MAX_CHECKUP_PER_DATE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_TIME_SPAN_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_TIME_SPAN:
                    break;
                case Doctor24x7ErrorCode.FAILURE_NOTIFICATION_TIME_ID_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_YEAR_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_MONTH_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_YEAR:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_MONTH:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SMALL_MONEY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SMALL_INTERVAL:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_TIMEZONE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_EXCLUDED_DATE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_DOCTOR_CHECKUP_TYPE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_SUPPORT_REQUEST_REPLIED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_AMOUNT:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CARD_TOKEN_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_POINT:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CHECKUP_RATED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_CHECKUP_STATUS_RATED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USER_ACTIVED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_OTP:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FAIL_IN_SEND_OTP:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PIN_TRIES_EXCEEDED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_PATIENT_APP_TABS:
                    break;
                case Doctor24x7ErrorCode.FAILURE_ROOM_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_ROOM:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_REFUNDED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_REFUND_PERSON_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_CHECKUP_UNPAID:
                    break;
                case Doctor24x7ErrorCode.FAILURE_FILE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_FILE_EXTENSION:
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_OR_PHONE_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_DESCRIPTION_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_FILE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_META_DATA_FILE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_QUESTION_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_ANSWER_NOT_FOUND:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SUBJECT_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USER_LINKED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_USER_PERMISSION:
                    break;
                case Doctor24x7ErrorCode.FAILURE_BODY_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_INVALID_EMAIL_GROUP:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PARTICIPANTNAME_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_MAILTO_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_REGISTEREDDATE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_SECURITYQUESTION_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_IDENTITYCODE_EMPTY:
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_NOT_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USER_NOT_ACTIVED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PHONE_NOT_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_USERNAME_NOT_EXISTED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PHONE_EXISTED_AND_NOT_ACTIVE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_PHONE_EXISTED_AND_ACTIVED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_EXISTED_AND_NOT_ACTIVE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_EXISTED_AND_ACTIVED:
                    break;
                case Doctor24x7ErrorCode.FAILURE_EMAIL_AND_PHONE_EXISTED_AND_NOT_ACTIVE:
                    break;
                case Doctor24x7ErrorCode.FAILURE_NO_RECIPIENTS:
                    break;
                default:
                    break;
            }
            return message;
        }
    }
}
