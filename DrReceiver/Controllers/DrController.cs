using Microsoft.AspNetCore.Mvc;
using DrReceiver.Services;
using DrReceiver.Models;

namespace DrReceiver.Controllers;

[Route("api/dr")]
[ApiController]
public class DrController(Logger logger) : ControllerBase
{
    [HttpGet("httpget-header")]
    public async Task<ActionResult<PostResponse>> HttpGetHeader(
        [FromHeader(Name ="gw-from")] string gwFrom,
        [FromHeader(Name = "gw-to")] string gwTo,
        [FromHeader(Name = "gw-dlr-status")] string gwDlrStatus,
        [FromHeader(Name = "gw-error-code")] string gwErrorCode,
        [FromHeader(Name = "gw-msgid")] string gwMsgId)
    {
        return await Task.FromResult(LogDr("httpget-header", gwFrom, gwTo, gwDlrStatus, gwErrorCode, gwMsgId));
    }

    [HttpGet("httpget-qs")]
    public async Task<ActionResult<PostResponse>> HttpGetQs(
        [FromQuery(Name = "gw-from")] string gwFrom,
        [FromQuery(Name = "gw-to")] string gwTo,
        [FromQuery(Name = "gw-dlr-status")] string gwDlrStatus,
        [FromQuery(Name = "gw-error-code")] string gwErrorCode,
        [FromQuery(Name = "gw-msgid")] string gwMsgId)
    {
       return await Task.FromResult(LogDr("httpget-qs", gwFrom, gwTo, gwDlrStatus, gwErrorCode, gwMsgId));
    }

    [HttpPost("httppost-json")]
    public async Task<ActionResult<PostResponse>> HttpPostJson([FromBody] DrData data)
    {
        return await Task.FromResult(LogDr("httppost-json", data.GwFrom, data.GwTo, data.GwDlrStatus, data.GwErrorCode, data.GwMsgId));
    }

    private PostResponse LogDr(
        string method,
        string gwFrom,
        string gwTo,
        string gwDlrStatus,
        string gwErrorCode,
        string gwMsgId)
    {
        logger.Dr($"IN DLR SUCC ({method}) >>> MsgId: {gwMsgId}, From: {gwFrom}, To: {gwTo}, DlrStatus: {gwDlrStatus}, ErrorCode: {gwErrorCode}");
        return new PostResponse { IsSuccess = true, Message = "DR IN logged to text" };
    }
}
