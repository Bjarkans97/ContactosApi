namespace ContactosApi.BusinessLogic.Common
{
    public record Result<T>(T? Value, string? Error, bool Success)
    {
        public static Result<T> Ok(T value) => new(value, null, true);
        public static Result<T> Fail(string error) => new(default, error, false);
    }
}