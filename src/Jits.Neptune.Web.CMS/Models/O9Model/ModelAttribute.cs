using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;


/// <summary>
/// 
/// </summary>
public class ModelAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ModelAttribute(string name)
    {
        this.name = name;
    }

}

