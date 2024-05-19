﻿using BeIT.MemCached;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class O9MemCached
    {
        /// <summary>
        /// 
        /// </summary>
        public MemcachedClient MCached { get; }
        System.Text.UTF8Encoding m_Enc = new System.Text.UTF8Encoding();

        /// <summary>
        /// 
        /// </summary>
        public O9MemCached(string memUrl)
        {
            MemcachedClient.Setup("default", new string[] { memUrl });
            MCached = MemcachedClient.GetInstance("default");
            MCached.MinPoolSize = 5;
            MCached.MaxPoolSize = 20;
            MCached.SendReceiveTimeout = 50000;
            MCached.CompressionThreshold = 512;
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetValue(string key)
        {
            try
            {
                if (MCached != null)
                {   
                    object oReturn = MCached.Get(key);
                    if (oReturn != null && oReturn.GetType() == typeof(byte[]))
                    {
                        byte[] strReturn = (byte[])MCached.Get(key);
                        if (strReturn != null && strReturn.Length > 0)
                        {
                            return m_Enc.GetString(strReturn);
                        }
                        return string.Empty;
                    }
                    if (oReturn != null) return oReturn.ToString();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public object[] GetValues(string[] key)
        {
            try
            {
                ulong[] lunique = null;

                if (MCached != null)
                {
                    object[] oReturn = MCached.Gets(key, out lunique);
                    if (oReturn != null)
                    {
                        for (int i = 0; i < oReturn.Length; i++)
                        {
                            if (oReturn[i] != null && oReturn[i] is byte[])
                            {
                                oReturn[i] = m_Enc.GetString((byte[])oReturn[i]);
                            }
                        }
                    }
                    return oReturn;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}