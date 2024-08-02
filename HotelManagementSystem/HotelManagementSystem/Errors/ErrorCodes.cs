namespace HotelManagementSystem.Errors
{
    public static class ErrorCodes
    {
        public const string NotFound = "ERR001";
        public const string InvalidInput = "ERR002";
        public const string Unauthorized = "ERR003";
        public const string ServerError = "ERR004";
        public const string Timeout = "ERR005";


        public const string WrongAccountUsername = "ACC001";
        public const string DisabledAccount = "ACC002";
        public const string WrongPassword = "ACC003";
        public const string WrongAccountEmail = "ACC004";

        public const string WrongOTP = "OTP001";

        public const string InvalidPasswordFormat = "PWD001";
        public const string ConfirmPasswordDoesNotMatches = "PWD002";
    }

}
