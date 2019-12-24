using System.Net;
using Newtonsoft.Json;
using ReactApi.Enums;

namespace ReactApi.Helpers
{
    /// <summary>
    /// IResult data return type
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// operation type property
        /// </summary>
        Operation Operation { get; set; }

        /// <summary>
        /// operation status
        /// </summary>
        Status Status { get; set; }

        /// <summary>
        /// Oparation message if any
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// operation body
        /// </summary>
        dynamic Body { get; set; }

        /// <summary>
        /// Http status code
        /// </summary>
        HttpStatusCode StatusCode { get; set; }
    }

    /// <summary>
    /// Result 
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// operation type property
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// operation status
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Oparation message if any
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// operation body
        /// </summary>
        public dynamic Body { get; set; }

        /// <summary>
        /// Http status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// return string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
