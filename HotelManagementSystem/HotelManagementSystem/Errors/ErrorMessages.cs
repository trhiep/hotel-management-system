namespace HotelManagementSystem.Errors
{
    public static class ErrorMessages
    {
        private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>
        {
            { ErrorCodes.NotFound, "Resource not found." },
            { ErrorCodes.InvalidInput, "Input data is invalid." },
            { ErrorCodes.Unauthorized, "You do not have permission to perform this action." },
            { ErrorCodes.ServerError, "An unexpected error occurred. Please try again later." }
        };

        public static string GetMessage(string errorCode)
        {
            return Messages.TryGetValue(errorCode, out var message) ? message : "Unknown error.";
        }
    }

}
