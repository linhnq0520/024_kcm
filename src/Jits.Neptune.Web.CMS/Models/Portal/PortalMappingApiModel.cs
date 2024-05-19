using System;
using Jits.Neptune.Web.Framework.Models;
/// <summary>
/// 
/// </summary>
public partial class RevertTransactionModel : BaseNeptuneModel
{
    /// <summary>
    /// TransactionId
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// TransDate
    /// </summary>
    public DateTime TransactionDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Token { get; set; }

}

/// <summary>
/// 
/// </summary>
public partial class RevertTransactionResponseModel : BaseNeptuneModel
{
    /// <summary>
    /// TransactionId
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// TransactionStatus
    /// </summary>
    public string TransactionStatus { get; set; }

    /// <summary>
    /// TransDate
    /// </summary>
    public DateTime TransactionDate { get; set; }
}


/// <summary>
/// 
/// </summary>
public partial class ReverseByReferenceIdModel
{
    /// <summary>
    /// TransactionId
    /// </summary>
    public string token { get; set; }

    /// <summary>
    /// TransDate
    /// </summary>
    public string reference_id { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class GetStaticTokenModel
{
    /// <summary>
    /// TransactionId
    /// </summary>
    public string user_code { get; set; }

    /// <summary>
    /// TransDate
    /// </summary>
    public long expiration_in_minutes { get; set; }
}