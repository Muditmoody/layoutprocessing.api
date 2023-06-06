using Newtonsoft.Json;

namespace PWCLayoutProcessingWebApp.Models
{
    /// <summary>
    /// Result class model
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Ok
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class Ok<T> : Result
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Ok"/> class.
            /// </summary>
            /// <param name="data">The data.</param>
            public Ok(T data)
            {
                this.ResultData = data;
            }

            /// <summary>
            /// Gets the status code.
            /// </summary>
            public int StatusCode { get => 1; }

            /// <summary>
            /// Gets or sets the result data.
            /// </summary>
            public T ResultData { get; set; }
        }

        /// <summary>
        /// Error
        /// </summary>
        public sealed class Error : Result
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Error"/> class.
            /// </summary>
            /// <param name="error">The error.</param>
            /// <param name="statusCode">The status code.</param>
            public Error(string error, int statusCode = -1)
            {
                this.ErrorMessage = error;
                this.StatusCode = statusCode;
            }

            /// <summary>
            /// Gets or sets the status code.
            /// </summary>
            public int StatusCode { get; set; }

            /// <summary>
            /// Gets or sets the error message.
            /// </summary>
            public string ErrorMessage { get; set; }
        }

        /// <summary>
        /// Combines the result.
        /// </summary>
        /// <param name="result1">The result1.</param>
        /// <param name="result2">The result2.</param>
        /// <param name="SuccessCombiner">The success combiner.</param>
        /// <returns>A Result.</returns>
        public static Result CombineResult<T>(
            Result result1,
            Result result2,
            Func<Ok<T>, Ok<T>, Result> SuccessCombiner = null)
        {
            return (result1, result2) switch
            {
                (Ok<T> r1, Ok<T> r2) => SuccessCombiner is null ? r2 : SuccessCombiner(r1, r2),
                (Ok<T> _, Error e2) => e2,
                (Error e1, Ok<T> _) => e1,
                (Error e1, Error e2) => new Error(e1.ErrorMessage + Environment.NewLine + e2.ErrorMessage),
                _ => throw new NotImplementedException()
            };
        }

        [JsonIgnore]
        public readonly Func<Result.Ok<bool>, Result.Ok<bool>, Result> OkCombiner = (r1, r2) =>
                     new Result.Ok<bool>(r1.ResultData && r2.ResultData);
    }
}