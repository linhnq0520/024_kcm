using System.Collections.Generic;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// Constants value
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 
        /// </summary>
        public const string PackageDefault = "jwebui.logic.";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerName = "CMS";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerVersion = "1.0";
        /// <summary>
        /// 
        /// </summary>
        public const string SystemApp = "/apps/";
        /// <summary>
        /// 
        /// </summary>
        public const string NameSpaceDefault = "Jits.Neptune.Web.CMS.";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerTemplate = "./j-webui-template";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerCore = "./cms_data/j-webui-core";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerLogin = "./cms_data/j-webui-login";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerApp = "./cms_data/j-webui-stable/";
        /// <summary>
        /// 
        /// </summary>
        public const string ServerResource = "./cms_data/wiz_rs";
        /// <summary>
        /// 
        /// </summary>
        public const string SystemRsaPrivateKey = "MIICWgIBAAKBgGUN9WQfWHcTasrBcC2wYbRvEaB9jiw+FLB12ZXaPvrkEcbxRH/pX2wBtuGF6M1DSQwm278X3tctpmH0X0+9mClPPV593ktvEMFneKSNQWPbSIRmiW7zUvD/UO7PkYU9T1znplj+dIMPiBcZrhOq03xPsOyZDZjRk2TVTxF09xNjAgMBAAECgYBfxGa1x+7yifg+xislYW52rHur+NDvpLW+tTDLDtV4twMR4jvkbKn9lXJXL6x8OjPTzE+cPWb1zVFMq2ZYD3lPGGU/8+BXbRtQRHg9SiwAeCWSJs9Df3Al5ab97IZEmW+7F87NcQR4MxXNtUDXZ7IrwXmPX1J7PPD1fOpceDv+YQJBALs0RSQcEyxTHwnAlnGLlsddCmSdujFkPPn9yeP2zqnsK3B0rFZVqeuewQOtd/U17/7tsrBio1tJQ3fJeAk/J00CQQCKMO5hOevV6Z3yx5AAql1K5Z004KIufKu4X9ddlL13++n2LBi3R/JAn9DOPRkLZJYcRxsCAFYpwRO0varSHq1vAj9MyCOTq/AxPeZ9GYCbEaXGH2Mj4Y18tKBN6MnltlUNXNB0T2ZgAsKu4W5JE90ftf+5j8S6k7pstp/1gay6Hi0CQCuAF6n3Z6ugrJ2+ADCVcGShPwlkJOlpSUzyroLAzZu1awKZAva+6R06saoaRYX2leI05+WLYZQnOSLOCbW2/nUCQQCsTMNN2Ouz25ffXIC/X52kwgv5W2W8T/46XpFdwiLO1+8lMlXmGcLL6nLQ3C+KPzCuT/QV4Gx7b+9Cec3PSIgk";
        /// <summary>
        /// 
        /// </summary>
        public const string SystemRsaPublicKey = "MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGUN9WQfWHcTasrBcC2wYbRvEaB9jiw+FLB12ZXaPvrkEcbxRH/pX2wBtuGF6M1DSQwm278X3tctpmH0X0+9mClPPV593ktvEMFneKSNQWPbSIRmiW7zUvD/UO7PkYU9T1znplj+dIMPiBcZrhOq03xPsOyZDZjRk2TVTxF09xNjAgMBAAE=";

        /// <summary>
        /// 
        /// </summary>
        public const string CMSInstanceIDString = "CMS_InstanceId_";

        /// <summary>
        /// 
        /// </summary>
        public const string CMSSSIDString = "CMS_SSID_";
        /// <summary>
        /// 
        /// </summary>
        public const string CMSContextUserString = "CMS_CONTEXT_USER_";


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Cdlist> cdlists = new List<Cdlist>(){

                // JWEBUI
                
                new Cdlist {Cdgrp="JWEBUI",Cdname="1",Cdid="13",Caption="1",Cdval="",Cdidx=1,Ftag="",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="GROUP_KEYBOARD",Cdid="MY_KEYBOARD",Caption="Group of keyboards",Cdval="",Cdidx=1,Ftag="",Visible=1,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="GROUP_KEYBOARD",Cdid="SUPPORT",Caption="Support keyboard group",Cdval="",Cdidx=2,Ftag="",Visible=1,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="đây là code name",Cdid="kienvt",Caption="cập nhật caption nè",Cdval="123",Cdidx=1,Ftag="link nè",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="SYSTEM_KEYBOARD",Cdid="MY_KEYBOARD",Caption="My keyboards",Cdval="",Cdidx=1,Ftag="",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="SYSTEM_KEYBOARD",Cdid="FORMAT",Caption="Format keyboard",Cdval="",Cdidx=2,Ftag="",Visible=1,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="SYSTEM_KEYBOARD",Cdid="SUPPORT",Caption="Support keyboards",Cdval="",Cdidx=3,Ftag="",Visible=1,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="c",Cdid="z",Caption="ưqeq",Cdval="",Cdidx=123,Ftag="",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="ccc",Cdid="bbb",Caption="aaa",Cdval="",Cdidx=12,Ftag="",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="STS",Cdid="I",Caption="Inactive",Cdval="",Cdidx=1,Ftag="",Visible=1,Mcaption="{}",App="ncbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="STS",Cdid="A",Caption="Active",Cdval="",Cdidx=2,Ftag="",Visible=1,Mcaption="{}",App="ncbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="VISIBLE",Cdid="T",Caption="On Menu",Cdval="",Cdidx=1,Ftag="0",Visible=1,Mcaption="{}",App="ncbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="VISIBLE",Cdid="F",Caption="Only search",Cdval="",Cdidx=2,Ftag="0",Visible=1,Mcaption="{}",App="ncbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="VISIBLE",Cdid="C",Caption="Form Child",Cdval="",Cdidx=3,Ftag="0",Visible=1,Mcaption="{}",App="ncbs"},
                new Cdlist {Cdgrp="JWEBUI",Cdname="www",Cdid="qqq",Caption="eee",Cdval="",Cdidx=1,Ftag="",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App=""},
                new Cdlist {Cdgrp="JWEBUI",Cdname="TEST001",Cdid="AUTO",Caption="TEST AUTO ADD SYS 2021",Cdval="",Cdidx=1,Ftag="",Visible=0,Mcaption="{\"English\":\"\",\"Vietnamese\":\"\",\"Laothian\":\"\",\"Khmer\":\"\",\"Myanmar\":\"\"}",App="ncbsCbs"},

                // ADM - COUNTRY

                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MV",Caption="Maldives",Cdval="",Cdidx=141,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AL",Caption="Albania",Cdval="",Cdidx=6,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BE",Caption="Belgium",Cdval="",Cdidx=20,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IQ",Caption="Iraq",Cdval="",Cdidx=99,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GB",Caption="United Kingdom",Cdval="",Cdidx=72,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KR",Caption="South Korea",Cdval="",Cdidx=112,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CV",Caption="Cape Verde",Cdval="",Cdidx=49,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MD",Caption="Moldova",Cdval="",Cdidx=129,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BD",Caption="Bangladesh",Cdval="",Cdidx=19,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GN",Caption="Guinea",Cdval="",Cdidx=79,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LC",Caption="Saint Lucia",Cdval="",Cdidx=118,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BV",Caption="Bouvet Island",Cdval="",Cdidx=32,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PN",Caption="Pitcairn",Cdval="",Cdidx=162,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GP",Caption="Guadeloupe",Cdval="",Cdidx=80,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SB",Caption="Solomon Islands",Cdval="",Cdidx=174,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PY",Caption="Paraguay",Cdval="",Cdidx=166,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GD",Caption="Grenada",Cdval="",Cdidx=73,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AT",Caption="Austria",Cdval="",Cdidx=13,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TM",Caption="Turkmenistan",Cdval="",Cdidx=197,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PW",Caption="Palau",Cdval="",Cdidx=165,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BI",Caption="Burundi",Cdval="",Cdidx=24,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ML",Caption="Mali",Cdval="",Cdidx=133,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GR",Caption="Greece",Cdval="",Cdidx=82,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TD",Caption="Chad",Cdval="",Cdidx=191,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BT",Caption="Bhutan",Cdval="",Cdidx=31,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="UG",Caption="Uganda",Cdval="",Cdidx=205,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="JM",Caption="Jamaica",Cdval="",Cdidx=103,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LK",Caption="Sri Lanka",Cdval="",Cdidx=120,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="",Caption="-",Cdval="",Cdidx=0,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="UA",Caption="Ukraine",Cdval="",Cdidx=204,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="VU",Caption="Vanuatu",Cdval="",Cdidx=213,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MS",Caption="Montserrat",Cdval="",Cdidx=138,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BW",Caption="Botswana",Cdval="",Cdidx=33,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MR",Caption="Mauritania",Cdval="",Cdidx=137,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SV",Caption="El Salvador",Cdval="",Cdidx=188,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SC",Caption="Seychelles",Cdval="",Cdidx=175,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MY",Caption="Malaysia",Cdval="",Cdidx=144,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IR",Caption="Iran, Islamic Republic of",Cdval="",Cdidx=100,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ER",Caption="Eritrea",Cdval="",Cdidx=62,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PM",Caption="Saint Pierre and Miquelon ",Cdval="",Cdidx=161,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="EG",Caption="Egypt",Cdval="",Cdidx=60,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LY",Caption="Libyan Arab Jamahiriya",Cdval="",Cdidx=126,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="DJ",Caption="Djibouti",Cdval="",Cdidx=54,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NG",Caption="Nigeria",Cdval="",Cdidx=147,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TK",Caption="Tokelau ",Cdval="",Cdidx=195,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="OM",Caption="Oman",Cdval="",Cdidx=154,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="VE",Caption="Venezuela (Bolivarian Republic of)",Cdval="",Cdidx=210,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="QA",Caption="Qatar",Cdval="",Cdidx=167,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ST",Caption="Sao Tome and Principe",Cdval="",Cdidx=187,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GQ",Caption="Equatorial Guinea",Cdval="",Cdidx=81,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PA",Caption="Panama",Cdval="",Cdidx=155,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TG",Caption="Togo",Cdval="",Cdidx=192,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TV",Caption="Tuvalu",Cdval="",Cdidx=202,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AI",Caption="Anguilla",Cdval="",Cdidx=5,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NP",Caption="Nepal",Cdval="",Cdidx=151,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BY",Caption="Belarus",Cdval="",Cdidx=34,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="HR",Caption="Croatia",Cdval="",Cdidx=91,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GL",Caption="Greenland",Cdval="",Cdidx=77,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MK",Caption="Macedonia, Republic of",Cdval="",Cdidx=132,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="HT",Caption="Haiti",Cdval="",Cdidx=92,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="DZ",Caption="Algeria",Cdval="",Cdidx=57,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="RW",Caption="Rwanda",Cdval="",Cdidx=172,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AQ",Caption="Antarctica",Cdval="",Cdidx=10,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KI",Caption="Kiribati",Cdval="",Cdidx=109,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NA",Caption="Namibia",Cdval="",Cdidx=146,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IO",Caption="British Indian Ocean Territory",Cdval="",Cdidx=98,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KG",Caption="Kyrgyzstan",Cdval="",Cdidx=107,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AG",Caption="Antigua and Barbuda",Cdval="",Cdidx=4,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="EH",Caption="Western Sahara",Cdval="",Cdidx=61,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IN",Caption="India",Cdval="",Cdidx=97,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="DK",Caption="Denmark",Cdval="",Cdidx=55,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CG",Caption="Congo (DRC)",Cdval="",Cdidx=39,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KP",Caption="North Korea",Cdval="",Cdidx=111,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="HK",Caption="Hong Kong Special Administrative Region of China",Cdval="",Cdidx=88,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PG",Caption="Papua New Guinea",Cdval="",Cdidx=157,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NO",Caption="Norway",Cdval="",Cdidx=150,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GA",Caption="Gabon",Cdval="",Cdidx=71,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AS",Caption="American Samoa",Cdval="",Cdidx=12,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CW",Caption="Curacao",Cdval="",Cdidx=50,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BF",Caption="Burkina Faso",Cdval="",Cdidx=21,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TT",Caption="Trinidad and Tobago",Cdval="",Cdidx=201,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MQ",Caption="Martinique",Cdval="",Cdidx=136,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="RO",Caption="Romania",Cdval="",Cdidx=169,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="YT",Caption="Mayotte",Cdval="",Cdidx=216,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CZ",Caption="Czech Republic",Cdval="",Cdidx=52,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AE",Caption="United Arab Emirates",Cdval="",Cdidx=2,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AO",Caption="Angola",Cdval="",Cdidx=9,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SO",Caption="Somalia",Cdval="",Cdidx=185,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SE",Caption="Sweden",Cdval="",Cdidx=177,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="YU",Caption="Yugoslavia",Cdval="",Cdidx=217,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="WS",Caption="Samoa",Cdval="",Cdidx=214,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="YE",Caption="Yemen",Cdval="",Cdidx=215,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KW",Caption="Kuwait",Cdval="",Cdidx=113,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NI",Caption="Nicaragua",Cdval="",Cdidx=148,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BN",Caption="Brunei Darussalam",Cdval="",Cdidx=27,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NL",Caption="Netherlands",Cdval="",Cdidx=149,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AM",Caption="Armenia",Cdval="",Cdidx=7,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CO",Caption="Colombia",Cdval="",Cdidx=46,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KM",Caption="Comoros",Cdval="",Cdidx=110,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GT",Caption="Guatemala",Cdval="",Cdidx=84,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ET",Caption="Ethiopia",Cdval="",Cdidx=64,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="US",Caption="United States of America",Cdval="",Cdidx=206,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IE",Caption="Ireland",Cdval="",Cdidx=95,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NZ",Caption="New Zealand",Cdval="",Cdidx=153,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BG",Caption="Bulgaria",Cdval="",Cdidx=22,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SL",Caption="Sierra Leone",Cdval="",Cdidx=182,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PT",Caption="Portugal",Cdval="",Cdidx=164,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SI",Caption="Slovenia",Cdval="",Cdidx=180,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CU",Caption="Cuba",Cdval="",Cdidx=48,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LS",Caption="Lesotho",Cdval="",Cdidx=122,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ZM",Caption="Zambia",Cdval="",Cdidx=219,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GS",Caption="South Georgia and the South Sandwich Islands",Cdval="",Cdidx=83,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TW",Caption="Taiwan, Republic of China",Cdval="",Cdidx=203,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="FR",Caption="France",Cdval="",Cdidx=70,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AN",Caption="Netherlands Antilles",Cdval="",Cdidx=8,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PH",Caption="Philippines",Cdval="",Cdidx=158,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ZW",Caption="Zimbabwe",Cdval="",Cdidx=220,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="FK",Caption="Falkland Islands (Malvinas) ",Cdval="",Cdidx=67,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="FO",Caption="Faroe Islands",Cdval="",Cdidx=69,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CN",Caption="China",Cdval="",Cdidx=45,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TO",Caption="Tonga",Cdval="",Cdidx=199,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MC",Caption="Monaco",Cdval="",Cdidx=128,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CM",Caption="Cameroon",Cdval="",Cdidx=44,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AR",Caption="Argentina",Cdval="",Cdidx=11,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="JO",Caption="Jordan",Cdval="",Cdidx=104,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CH",Caption="Switzerland",Cdval="",Cdidx=40,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SA",Caption="Saudi Arabia",Cdval="",Cdidx=173,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="DO",Caption="Dominican Republic",Cdval="",Cdidx=56,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ZA",Caption="South Africa",Cdval="",Cdidx=218,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="VN",Caption="Viet Nam",Cdval="",Cdidx=212,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SH",Caption="Saint Helena",Cdval="",Cdidx=179,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IL",Caption="Israel",Cdval="",Cdidx=96,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="VC",Caption="Saint Vincent and Grenadines",Cdval="",Cdidx=209,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SK",Caption="Slovakia",Cdval="",Cdidx=181,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CD",Caption="Congo, Democratic Republic of the",Cdval="",Cdidx=37,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MN",Caption="Mongolia",Cdval="",Cdidx=135,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BR",Caption="Brazil",Cdval="",Cdidx=29,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BS",Caption="Bahamas",Cdval="",Cdidx=30,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BB",Caption="Barbados",Cdval="",Cdidx=18,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AZ",Caption="Azerbaijan",Cdval="",Cdidx=16,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ES",Caption="Spain",Cdval="",Cdidx=63,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="RE",Caption="Reunion",Cdval="",Cdidx=168,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CK",Caption="Cook Islands ",Cdval="",Cdidx=42,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SR",Caption="Suriname",Cdval="",Cdidx=186,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PK",Caption="Pakistan",Cdval="",Cdidx=159,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LV",Caption="Latvia",Cdval="",Cdidx=125,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AD",Caption="Andorra",Cdval="",Cdidx=131,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MU",Caption="Mauritius",Cdval="",Cdidx=140,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="FJ",Caption="Fiji",Cdval="",Cdidx=66,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="RU",Caption="Russian Federation",Cdval="",Cdidx=171,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BJ",Caption="Benin.",Cdval="",Cdidx=25,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AF",Caption="Afghanistan",Cdval="",Cdidx=3,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GW",Caption="Guinea-Bissau",Cdval="",Cdidx=86,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MH",Caption="Marshall Islands",Cdval="",Cdidx=131,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IT",Caption="Italy",Cdval="",Cdidx=102,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KY",Caption="Cayman Islands ",Cdval="",Cdidx=114,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BM",Caption="Bermuda",Cdval="",Cdidx=26,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MG",Caption="Madagascar",Cdval="",Cdidx=130,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="JP",Caption="Japan",Cdval="",Cdidx=105,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="HN",Caption="Honduras",Cdval="",Cdidx=90,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GM",Caption="Gambia",Cdval="",Cdidx=78,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="UY",Caption="Uruguay",Cdval="",Cdidx=207,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GU",Caption="Guam",Cdval="",Cdidx=85,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BZ",Caption="Belize",Cdval="",Cdidx=35,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GH",Caption="Ghana",Cdval="",Cdidx=75,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="UZ",Caption="Uzbekistan",Cdval="",Cdidx=208,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SG",Caption="Singapore",Cdval="",Cdidx=178,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BA",Caption="Bosnia and Herzegovina",Cdval="",Cdidx=17,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="IS",Caption="Iceland",Cdval="",Cdidx=101,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GE",Caption="Georgia",Cdval="",Cdidx=74,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CA",Caption="Canada",Cdval="",Cdidx=36,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="VG",Caption="British Virgin Islands",Cdval="",Cdidx=211,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="EE",Caption="Estonia",Cdval="",Cdidx=59,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PE",Caption="Peru",Cdval="",Cdidx=156,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BO",Caption="Bolivia",Cdval="",Cdidx=28,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TH",Caption="Thailand",Cdval="",Cdidx=193,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="ID",Caption="Indonesia",Cdval="",Cdidx=94,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="HU",Caption="Hungary",Cdval="",Cdidx=93,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MM",Caption="Myanmar",Cdval="",Cdidx=1,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SD",Caption="Sudan",Cdval="",Cdidx=176,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LA",Caption="Lao PDR",Cdval="",Cdidx=116,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SN",Caption="Senegal",Cdval="",Cdidx=184,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="HM",Caption="Heard Island and Mcdonald Islands",Cdval="",Cdidx=89,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TN",Caption="Tunisia",Cdval="",Cdidx=198,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="FM",Caption="Micronesia, Federated States of",Cdval="",Cdidx=68,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MW",Caption="Malawi",Cdval="",Cdidx=142,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="RS",Caption="Serbia",Cdval="",Cdidx=170,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MX",Caption="Mexico",Cdval="",Cdidx=143,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CR",Caption="Costa Rica",Cdval="",Cdidx=47,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GI",Caption="Gibraltar ",Cdval="",Cdidx=76,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CY",Caption="Cyprus",Cdval="",Cdidx=51,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AW",Caption="Aruba",Cdval="",Cdidx=15,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TR",Caption="Turkey",Cdval="",Cdidx=200,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SZ",Caption="Swaziland",Cdval="",Cdidx=190,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MT",Caption="Malta",Cdval="",Cdidx=139,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LI",Caption="Liechtenstein",Cdval="",Cdidx=119,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="FI",Caption="Finland",Cdval="",Cdidx=65,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MZ",Caption="Mozambique",Cdval="",Cdidx=145,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CI",Caption="COTE DIVOIRE",Cdval="",Cdidx=41,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="EC",Caption="Ecuador",Cdval="",Cdidx=58,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SM",Caption="San Marino",Cdval="",Cdidx=183,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="MA",Caption="Morocco",Cdval="",Cdidx=127,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LB",Caption="Lebanon",Cdval="",Cdidx=117,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TL",Caption="Timor-Leste",Cdval="",Cdidx=196,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KH",Caption="Cambodia",Cdval="",Cdidx=108,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KZ",Caption="Kazakhstan",Cdval="",Cdidx=115,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LT",Caption="Lithuania",Cdval="",Cdidx=123,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LR",Caption="Liberia",Cdval="",Cdidx=121,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="BH",Caption="Bahrain",Cdval="",Cdidx=23,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="LU",Caption="Luxembourg",Cdval="",Cdidx=124,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="NR",Caption="Nauru",Cdval="",Cdidx=152,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CF",Caption="Central African Republic",Cdval="",Cdidx=38,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PL",Caption="Poland",Cdval="",Cdidx=160,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="CL",Caption="Chile",Cdval="",Cdidx=43,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="KE",Caption="Kenya",Cdval="",Cdidx=106,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="AU",Caption="Australia",Cdval="",Cdidx=14,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="TJ",Caption="Tajikistan",Cdval="",Cdidx=194,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="PR",Caption="Puerto Rico",Cdval="",Cdidx=163,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="DE",Caption="Germany",Cdval="",Cdidx=53,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="GY",Caption="Guyana",Cdval="",Cdidx=87,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="COUNTRY",Cdid="SY",Caption="Syrian Arab Republic",Cdval="",Cdidx=189,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},

                // ADM - CURRENCY

                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="EUR",Caption="EUR",Cdval="",Cdidx=3,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AED",Caption="AED",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CLF",Caption="CLF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="DZD",Caption="DZD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BWP",Caption="BWP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ANG",Caption="ANG",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MYR",Caption="MYR",Cdval="",Cdidx=9,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MVR",Caption="MVR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="HUF",Caption="HUF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GNF",Caption="GNF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NGN",Caption="NGN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XDR",Caption="XDR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BOB",Caption="BOB",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SCR",Caption="SCR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MKD",Caption="MKD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XAU",Caption="XAU",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SAR",Caption="SAR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AUD",Caption="AUD",Cdval="",Cdidx=11,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GTQ",Caption="GTQ",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="EEK",Caption="EEK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CLP",Caption="CLP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LRD",Caption="LRD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MOP",Caption="MOP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CUC",Caption="CUC",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ARS",Caption="ARS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MMK",Caption="MMK",Cdval="",Cdidx=1,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="WST",Caption="WST",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NAD",Caption="NAD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TOP",Caption="TOP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="HNL",Caption="HNL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XPT",Caption="XPT",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="COP",Caption="COP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="UGX",Caption="UGX",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AAA",Caption="AAA",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CAD",Caption="CAD",Cdval="",Cdidx=25,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AOA",Caption="AOA",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MAD",Caption="MAD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LBP",Caption="LBP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="IQD",Caption="IQD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XAG",Caption="XAG",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ETB",Caption="ETB",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SGD",Caption="SGD",Cdval="",Cdidx=4,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="RRR",Caption="RRR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KZT",Caption="KZT",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="INR",Caption="INR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MWK",Caption="MWK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="DJF",Caption="DJF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="JMD",Caption="JMD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CDF",Caption="CDF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="QAR",Caption="QAR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="UYI",Caption="UYI",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MXN",Caption="MXN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="FEC",Caption="FEC",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="USS",Caption="USS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="HRK",Caption="HRK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="RUB",Caption="RUB",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CHE",Caption="CHE",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="UYU",Caption="UYU",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TJS",Caption="TJS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GYD",Caption="GYD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SYP",Caption="SYP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="VNA",Caption="VNA",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KRW",Caption="KRW",Cdval="",Cdidx=22,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BZD",Caption="BZD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="VND",Caption="VND",Cdval="",Cdidx=14,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NPR",Caption="NPR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="FJD",Caption="FJD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BGN",Caption="BGN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GBP",Caption="GBP",Cdval="",Cdidx=17,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LTL",Caption="LTL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MUR",Caption="MUR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PYG",Caption="PYG",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LVL",Caption="LVL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="STD",Caption="STD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KMF",Caption="KMF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PTM",Caption="PTM",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ERN",Caption="ERN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="DOP",Caption="DOP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GMD",Caption="GMD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SBD",Caption="SBD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GHS",Caption="GHS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CUP",Caption="CUP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="RWF",Caption="RWF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TTD",Caption="TTD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XXX",Caption="XXX",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AMD",Caption="AMD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TND",Caption="TND",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TES",Caption="TES",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="HKD",Caption="HKD",Cdval="",Cdidx=19,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BRL",Caption="BRL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="VUV",Caption="VUV",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XBD",Caption="XBD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XBB",Caption="XBB",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="IRR",Caption="IRR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ISK",Caption="ISK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CHW",Caption="CHW",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ZWL",Caption="ZWL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NOK",Caption="NOK",Cdval="",Cdidx=15,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KPW",Caption="KPW",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PGK",Caption="PGK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="USN",Caption="USN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TMT",Caption="TMT",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SVC",Caption="SVC",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="YER",Caption="YER",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BIF",Caption="BIF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CZK",Caption="CZK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="RSD",Caption="RSD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XPF",Caption="XPF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KGS",Caption="KGS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MRO",Caption="MRO",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TRY",Caption="TRY",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="JPY",Caption="JPY",Cdval="",Cdidx=5,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AZN",Caption="AZN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ZMK",Caption="ZMK",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LYD",Caption="LYD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SOS",Caption="SOS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BTN",Caption="BTN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MGA",Caption="MGA",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="FKP",Caption="FKP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PKR",Caption="PKR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="VEF",Caption="VEF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="THB",Caption="THB",Cdval="",Cdidx=6,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MNT",Caption="MNT",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LSL",Caption="LSL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KES",Caption="KES",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XPD",Caption="XPD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="UZS",Caption="UZS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SLL",Caption="SLL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PHP",Caption="PHP",Cdval="",Cdidx=24,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XAF",Caption="XAF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ALL",Caption="ALL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TZS",Caption="TZS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PLN",Caption="PLN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BOV",Caption="BOV",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BOT",Caption="BOT",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="USD",Caption="USD",Cdval="",Cdidx=2,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CNY",Caption="CNY",Cdval="",Cdidx=10,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NBU",Caption="NBU",Cdval="",Cdidx=98,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="EGP",Caption="EGP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LAK",Caption="LAK",Cdval="",Cdidx=8,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MDL",Caption="MDL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SEK",Caption="SEK",Cdval="",Cdidx=13,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CVE",Caption="CVE",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BDT",Caption="BDT",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XOF",Caption="XOF",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MXV",Caption="MXV",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BAM",Caption="BAM",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SDG",Caption="SDG",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ILS",Caption="ILS",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AFN",Caption="AFN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PAB",Caption="PAB",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="ZAR",Caption="ZAR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="CHF",Caption="CHF",Cdval="",Cdidx=16,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BSD",Caption="BSD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="DKK",Caption="DKK",Cdval="",Cdidx=23,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SHP",Caption="SHP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BHD",Caption="BHD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BYR",Caption="BYR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="AWG",Caption="AWG",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XBC",Caption="XBC",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NIO",Caption="NIO",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GEL",Caption="GEL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="RON",Caption="RON",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KYD",Caption="KYD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BBD",Caption="BBD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XBA",Caption="XBA",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BMD",Caption="BMD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="OMR",Caption="OMR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="UAH",Caption="UAH",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="IDR",Caption="IDR",Cdval="",Cdidx=21,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="HTG",Caption="HTG",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="PEN",Caption="PEN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="BND",Caption="BND",Cdval="",Cdidx=18,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="TWD",Caption="TWD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="MZN",Caption="MZN",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="LKR",Caption="LKR",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NBT",Caption="NBT",Cdval="",Cdidx=97,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SRD",Caption="SRD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="JOD",Caption="JOD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="NZD",Caption="NZD",Cdval="",Cdidx=12,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KWD",Caption="KWD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="XCD",Caption="XCD",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="COU",Caption="COU",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="GIP",Caption="GIP",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="KHR",Caption="KHR",Cdval="",Cdidx=7,Ftag="",Visible=1,Mcaption="{}",App="ncbsCbs"},
                new Cdlist {Cdgrp="ADM",Cdname="CURRENCY",Cdid="SZL",Caption="SZL",Cdval="",Cdidx=99,Ftag="",Visible=0,Mcaption="{}",App="ncbsCbs"},
           };

        /// <summary>
        /// 
        /// </summary>
        public static class WorkflowStatus
        {
            /// <summary>
            /// 
            /// </summary>
            public const int Active = 1;
            /// <summary>
            /// 
            /// </summary>
            public const int Inactive = 0;
        }
    }
}
