using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace HRMedicalRecordsSystem.Responses
{
    /// <summary>
    /// A generic response class that represents the structure of a response returned by the API.
    /// </summary>
    /// <typeparam name="T">The type of data the response will contain.</typeparam>
    public class BaseResponse<T>
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public int? Code { get; set; }
        public int? TotalRows { get; set; }
        public string? Exception { get; set; }


        // Private constructor that initializes the response from a builder.
        private BaseResponse(BaseResponseBuilder builder)
        {
            Success = builder.Success;
            Message = builder.Message;
            Data = builder.Data;
            Code = builder.Code;
            TotalRows = builder.TotalRows;
            Exception = builder.Exception;
        }




        /// <summary>
        /// A builder class used to construct an instance of the <see cref="BaseResponse{T}"/>.
        /// </summary>
        public class BaseResponseBuilder
        {
            public bool? Success { get; private set; }
            public string? Message { get; private set; }
            public T? Data { get; private set; }
            public int? Code { get; private set; }
            public int? TotalRows { get; private set; }
            public string? Exception { get; private set; }


            /// <summary>
            /// Sets the success flag of the response.
            /// </summary>
            /// <param name="success">Indicates whether the request was successful.</param>
            /// <returns>The builder instance.</returns>
            public BaseResponseBuilder SetSuccess(bool? success)
            {
                Success = success;
                return this;
            }
            /// <summary>
            /// Sets the message of the response.
            /// </summary>
            /// <param name="message">A message explaining the result of the request.</param>
            /// <returns>The builder instance.</returns>
            public BaseResponseBuilder SetMessage(string? message)
            {
                Message = message;
                return this;
            }
            /// <summary>
            /// Sets the data to be returned in the response.
            /// </summary>
            /// <param name="data">The data returned by the request.</param>
            /// <returns>The builder instance.</returns>
            public BaseResponseBuilder SetData(T? data)
            {
                Data = data;
                return this;
            }
            /// <summary>
            /// Sets the HTTP status code for the response.
            /// </summary>
            /// <param name="code">The HTTP status code.</param>
            /// <returns>The builder instance.</returns>
            public BaseResponseBuilder SetCode(int? code)
            {
                Code = code;
                return this;
            }
            /// <summary>
            /// Sets the total number of rows available in the response (useful for paginated results).
            /// </summary>
            /// <param name="totalRows">The total number of rows.</param>
            /// <returns>The builder instance.</returns>
            public BaseResponseBuilder SetTotalRows(int? totalRows)
            {
                TotalRows = totalRows;
                return this;
            }
            /// <summary>
            /// Sets an exception message if the request failed.
            /// </summary>
            /// <param name="exception">The exception message.</param>
            /// <returns>The builder instance.</returns>
            public BaseResponseBuilder SetException(string? exception)
            {
                Exception = exception;
                return this;
            }
            /// <summary>
            /// Builds and returns an instance of <see cref="BaseResponse{T}"/>.
            /// </summary>
            /// <returns>The constructed response.</returns>
            public BaseResponse<T> Build() => new BaseResponse<T>(this);
        }

        /// <summary>
        /// Creates and returns a new builder for constructing a response.
        /// </summary>
        /// <returns>A new builder instance.</returns>
        public static BaseResponseBuilder CreateBuilder() => new BaseResponseBuilder();


        /// <summary>
        /// Creates a successful response with data and a status code of 200.
        /// </summary>
        /// <param name="data">The data to return in the response.</param>
        /// <param name="totalRows">The total number of rows (optional, defaults to 0).</param>
        /// <returns>A successful response with the provided data.</returns>
        public static BaseResponse<T> SuccessResponse(T data, int totalRows = 0) => CreateBuilder()
            .SetSuccess(true)
            .SetMessage("Successful request")
            .SetData(data)
            .SetCode(200)
            .SetTotalRows(totalRows)
            .Build();

        /// <summary>
        /// Creates an error response with an exception message and a status code of 500.
        /// </summary>
        /// <param name="exception">The exception message to include in the response.</param>
        /// <returns>An error response with the exception message.</returns>
        public static BaseResponse<T> ErrorResponse(string exception) => CreateBuilder()
            .SetSuccess(false)
            .SetMessage("Internal Server Error: Unhandled errors")
            .SetCode(500)
            .SetException(exception)
            .Build();

        /// <summary>
        /// Creates a "not found" response with a status code of 404.
        /// </summary>
        /// <returns>A "not found" response.</returns>
        public static BaseResponse<T> NotFoundResponse() => CreateBuilder()
            .SetSuccess(false)
            .SetMessage("Not Found: Resource not found")
            .SetCode(404)
            .Build();

        /// <summary>
        /// Creates a "bad request" response with an exception message and a status code of 400.
        /// </summary>
        /// <param name="exception">The exception message to include in the response.</param>
        /// <returns>A "bad request" response with the exception message.</returns>

        public static BaseResponse<T> BadRequestResponse(string exception) => CreateBuilder()
            .SetSuccess(false)
            .SetMessage("Bad Request: Invalid request")
            .SetCode(400)
            .SetException(exception)
            .Build();




    }




}

