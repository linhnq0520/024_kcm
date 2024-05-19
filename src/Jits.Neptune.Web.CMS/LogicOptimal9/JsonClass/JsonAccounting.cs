using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
/// <summary>
/// 
/// </summary>
public class JsonAccounting : BaseJsonGetData
{
    /// <summary>
    /// 
    /// </summary>
    public int BRANCHID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string CCRID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int CLRID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string CLRTYPE { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int GRPID { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ACGRPDEF { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string O9MODULE { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ACGRPNAME { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ACNAME { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ACCCR { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string CLRCCR { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Object I { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Object B { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Object P { get; set; }


    //public JsonAccounting(int branchid = 0, string ccrid = null, int clrid = 0, string clrtype = null, Boolean m = true) { 
    //    BRANCHID = branchid;
    //    CCRID = ccrid;
    //    CLRID = clrid;
    //    CLRTYPE = clrtype;
    //    M = m;
    //}
}