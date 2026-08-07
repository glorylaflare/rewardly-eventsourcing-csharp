using System.Net;

namespace Rewardly.Api.Mapper;

public sealed record ExceptionMapping(HttpStatusCode StatusCode, string ErrorCode, string Message);
