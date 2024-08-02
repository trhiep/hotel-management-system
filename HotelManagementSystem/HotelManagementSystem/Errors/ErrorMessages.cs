namespace HotelManagementSystem.Errors
{
    public static class ErrorMessages
    {
        private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>
        {
            { ErrorCodes.NotFound, "Resource not found." },
            { ErrorCodes.InvalidInput, "Input data is invalid." },
            { ErrorCodes.Unauthorized, "You do not have permission to perform this action." },
            { ErrorCodes.ServerError, "An unexpected error occurred. Please try again later." },
            { ErrorCodes.Timeout, "Session timeout!. Please try again later." },
            { ErrorCodes.WrongAccountUsername, "Username does not exists." },
            { ErrorCodes.DisabledAccount, "This account has been disabled" },
            { ErrorCodes.WrongPassword, "Incorrect password" },
            { ErrorCodes.WrongAccountEmail, "This email does not belong to any account." },
            { ErrorCodes.WrongOTP, "Wrong OTP!" },
            { ErrorCodes.InvalidPasswordFormat, "Password must have at leat 8 characters in length and 1 uppercase character, 1 lowercase character, 1 number, 1 special character!" },
            { ErrorCodes.ConfirmPasswordDoesNotMatches, "Confirm password does not matches"},
        };

        public static string GetMessage(string errorCode)
        {
            return Messages.TryGetValue(errorCode, out var message) ? message : "Unknown error.";
        }
    }

}
