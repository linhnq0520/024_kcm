using System.ComponentModel.DataAnnotations;

/// <summary>
/// 
/// </summary>
public class CoreRequiredAttribute : RequiredAttribute
{
    /// <summary>
    /// 
    /// </summary>
    public override string FormatErrorMessage(string name)
    {
        return string.Format("Field [{0}] is required", name);
    }
}


/// <summary>
/// 
/// </summary>
public class CoreMaxLengthAttribute : MaxLengthAttribute
{
    /// <summary>
    /// 
    /// </summary>
    public CoreMaxLengthAttribute(int length) : base(length)
    {
        base.ErrorMessageResourceName = "MaximumLength";
    }

    /// <summary>
    /// 
    /// </summary>
    public override string FormatErrorMessage(string name)
    {
        return string.Format("Maximum length of field [{0}] is {1}", name , Length);
    }
}

/// <summary>
/// 
/// </summary>
public class CoreMinLengthAttribute : MinLengthAttribute
{
    /// <summary>
    /// 
    /// </summary>
    public CoreMinLengthAttribute(int length) : base(length)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public override string FormatErrorMessage(string name)
    {
        return string.Format("Minimum length of field [{0}] is {1}", name, Length);
    }
}
