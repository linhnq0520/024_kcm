using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentMigrator;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Domain.Neptune;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2020/01/01 17:32:13:0000000", "AdminUserSetting-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class CMSAdminUserSettingMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="configuration"></param>
        public CMSAdminUserSettingMigration(INeptuneDataProvider dataProvider, IConfiguration configuration)
        {
            _dataProvider = dataProvider;
            _configuration = configuration;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            var settings = new List<Setting> {
                    new Setting { Name = "CMSSetting.AdminStaticToken", Value = "N/A" },
                    new Setting { Name = "CMSSetting.PortalToken", Value = "N/A" },
                    new Setting { Name = "CMSSetting.BackupDirectory", Value = "/var/opt/mssql/backupdata/" },
                    new Setting { Name = "CMSSetting.License", Value = "VnDobNPNyfuYvhZwYU5rTctWZK7iaMOXQwfp5Ic+N27pfTokbHMrwlZSxIA95QM3qpXO2BOH8DKldgRVtn0eCelQ7ZGod2J61geTbZqgJuh+LjA23fpB2G1HMTGaHcYWC2LlCUuh1KoI4zsB+DqcznHeDY/woZM/95YM60SF2WzKyjKN3Id5Ys5gdvOFqiJWntI/zK1tIYa6dFCpu+zZqLOf8smf1EBR9P4/rILRKWWfZpUOfjwbeCvf49TIh1x5rO2mWj9Y/w1x+r3XySU282GEl+4qkV7bgM4ttxNCCySFnP59YhMqpeLvGpbGrN2ofQk4C8g+fepUumoEXiGLd0QdwOd9VDeZD+YJD8ffNxUL+R0QN67HvHRsqtNvZh99ECrrogwS2lY/rVL3SPBq0Sj56sNwQVx7/T/gR8A92xZ4mtVWHGfecIvCYsy8rIHk4B8AFFyIFuQPcVQqqwX2LMFxAriMzefwaOQRQWjHc/rWHoJqcZLG8rrys/0jycrsv6P83Cfy2lqHGYeE5+tTVAPs270fVfIC1AMa9yEfubq4b7dITffGz3Wk2TJhhpKp+0SlTF9nNCctNIa65ePQqFVx4mNI9zv1gP6Q68ELdS38/gm47wZFVSUF4Hxk1JlMS4nCr+a+ViXuh2vRarVbDIt6kxIvxwCmZAW/nvN5FN4=", },
                    new Setting { Name = "CMSSetting.Geo", Value = "true" },
                    new Setting { Name = "CMSSetting.Isdev", Value = "true" },
                    new Setting { Name = "CMSSetting.Isprod", Value = "true" },
                    new Setting { Name = "CMSSetting.Slowspeednetwork", Value = "1" },
                    new Setting { Name = "CMSSetting.Hostport", Value = ":8066" },
                    new Setting { Name = "CMSSetting.TemplateHostDev", Value = "http://jwebui.com:8066/fwcss" },
                    new Setting { Name = "CMSSetting.SeverRsaPrivateKey", Value = "KqmQTLK35R4lzfES8IukPmcNxk9vfM1SAgiPOhP9qU6Q3CvDB52uVsGHqn3bpWJy4nlhb5i8FEBUczJwNyQ7zNzYAmAoE1G99LTq1mqn4X7Gm8xcecLAQhty83q/B5pxEBxnurjG4Xv240scoXnLpvuSCQrNgHYfnJud0l/RDtk=QSGVBY3A/CcTfeLHZeM5TU41ojKPPM+74f2nMDHFbZLbUzvc+zlikB0TK91AtzXE/A4fpC540DOBsa+2G4h9fRbH95VjlDakKKgpd3snyDx+XH4E/fm9jMEFU6aqIzja8AT132JMBjRzLvsUn725m6xp57cBWCIhmwBSD8Si5MM=G4A6Deol3128g4bcETfRGhpHnuYuI2Drb/QJJqcVC7eCOb8MyiB7lgM+OlBOAVXXMhz6dZwCO6zym/UbYct71NoGJVk3wGJJc767wbi4XpxSBcaxCKquLAF1oUFpUIf7bRn9P6Yz4ID3tRi4AvXATgGWr0+bGfsohkfCNTLnfIA=MEsb43uAY2zJHVmh+vQbsWtNhJ9Cssgs4X4aVzv9KcEEmB01MdI9iChLsfvDGp7K82QaUqKSAzT0Ehs6LUFC/QH4j7T41IE87gVeyiZRpheL+68A0+Jv7nZHbnWM8yWKzm9Yt/NKk4phs7tQorAM+lJzMAqS/LBI9n3H71Su4BU=CoDaDPLrv4IVms7tBZB8mbXcCd/9SJ+Y3lVJX2lDBXQnP0RKWBxkefFAnafcxQk91DfblQVM5jLs75Iqx5NZnR92H5lCnSekVI2RGHcaDt9+jhBO1E5mIOm7TweGZMJDnaHK3j4UiDkiw/fdrq1/YeL3+T5hRSemSVnXwOkmJAk=RGC3yZMrFZg3v8abPTZ4//J2TIM3L+0Xuh7Pd0jNFuT/4v5PImTSbtfpPhFRvNor62iMgfsfZTo13Ka3QegOST+O+8kE+Scirw9972+y7UlLLXyrGh71D/b8ZHwz3TkRGEV1vzYZtZGx0lp7X4tlcn75NhkM4QmYjaJuMsZf2Ns=QNcTdF09Hy7Cl5YdccpcuTZHsknzIqRmfyafRKEMMWg1lvZPfZ/0aVjWx5KUT03PaB/nyxLJxTJK1vt5Rru8abVIMLUV4Xmm69r4eThcfWtU+tcyZgc8NYITsrNplrRp9ywjUoc6XVVaIsBrfV7hff802QnW7PNV+EZ2L3jK0k0=ATZcKMSglTTQGY31lGjG3XH6wleUm25h7D3IZwgQMIBg2lDDVoCTodtq3PhPNFUtcIeP6mCAFKT8hVcDl/h4NAww/4Ycrh21uJOQcLeIEVSJhaTrJwa9Zg9Xf5yGvzXmUCoqzPv7TF+lGTT+Dp19QKNSB1js70VTgt0kW+PMvJg=WAFCpyEYBNE6G5ApMPUgtbBuZ/U9BxxObsQaD15zJAisyCj955xc2Wl6tbxyO8wZmRv27GihOQIyVKwhUpsac7IDTzHXVwIM3hVEotQNmkHd7DzcZgn1FQ1kwChQG6b+MSZF8/+Hwt6NndmtDFlz83akRrvAOrjMKdHjbACcfI0=PZE4ozQTuNh4NOaIWHd9uh6aLUcwrHix2aT3ux1x9bvsGo5/MxJZxosmqv4MmKuINHt21e93lbU64cndOuI1dRw3pWenBfqNgq5Lx24xeX8vubCtM2W/NDAT2/hh5qPGyVfBq6tctzrmngLpv+VhEcLMJ5U1kQ/8Lh5baQx5A60=CLvWcmhJSvmcATUWHW3VzLgWPqb8Hf2Ck3g8J2kKJDIWkg6BMhPGfopgK5vR5k205wt6kjzrIbGnY1vwibRxquodCkTne6HvqauNt6XKJXXGwo4kJ6h68G3KK1AHm4/UeeVLFwkAT4eurcuFYgnYco9CT0dxSgREujayFqqS0Co=XQuzEZVEBFrHsx4EbmhfOaIa8YcPShntu2cYHnPz5934qJfv8EJ+VGmFzkFIEiO9xsFPnLMI97lX3pcP7ev+V9vWwq9t3vvu7OOqKz5pX1YxFY5wfzi1dBBHlBuahA4fR+TtTJKqzp2prjzXB6T3WPm77FUQrggQcgustcjcwt8=DVikjaWt+5z7EsHnfh158ZMSa1xRkZcDAM7ekiaaC7zoa9khQoLjjPFRY90oTT2ubCJMen45G8eg6ODEfzEe0aTeVI7ikd5AeBjsAMZ1bF4MWWyBFvo/JKHDefAcriRDpTBuLChJReFvRRCFDX8Z7bN7nD4s7jLlMZMT/Vm0S8c=B0NO6+I6cMaHBdPljUxRzGq/RUtZjLEzWs9z+Kk7aC/fPycocBX4ETbQMg4wiM/evrnZgC5eMRzqsdVW7PwYVcQbh8u4VGhxVLxZtCK0GpipQ3ZBynm24V4eJO3uNQgNdAJ2odT17ep3Dz3pag1WqCh/yVTjVpGXy6qSJblmdk0=" },
                    new Setting { Name = "CMSSetting.ClientRsaPublicKey", Value = "BCNnSUwfJO85aZ/JiNquA08BnAMMwR6e3TdgVeE75ccwBYjg3oAQtOm/bS0KAm6uROkzkmveF23pulSPZrDDeOwnJyX2BPznufOSZVVvqJMhZyBEHUuK+V2FG/Iyv0cWI9OmSqojuCW6XYnzZoit1XtoaCC2m8D00gNJbklh9lY=NP6YSBOZV6a7fWwR7zFVhao9xMxgIpz0fa1T2H90Xwrig6giT5Z/w6njLI7IKKtAWM3Abyz55tsaiC28h9G8fdfTschRTK4Nu3vPWbsx7ETfkLLn1dz9AF8m+4JA8p2h9u5fCkRbJaXth4ee+CeBAPXs3C7qY+Oc8dMbO5K+cHI=RMWA6XpqHE4x0R0hBR39SbA2oClsAqdk6vaHv7bMmLp4tHatbQ2OGeF+sznjNjG5jAzWffYdLJ5B9mqeYK83U5ZVeK25tGIJB0d2ejX8zJbZt4zxKQrTufJoS51fVhr6pAEKoi+eouMpXwlnsuFdRxg5TBuH1I490tek4SrzsqE=FmSpElbCfz9GsGIYReMEjmB0JyY9pOQcSdB8YL8SlRMRGkvlRSr1wBTVCmmJuAuOXaN68PfiLl+qxpcL1a0ZmLNIV0pngYI7qOB8O41gqfmkTb/2/1zNDayOsTKZT8stzqLRYSEaes2voDFycNzp3J6rjrjvDHx74eYVhczboh0=" },
                    new Setting { Name = "CMSSetting.DataRsaPrivateKey", Value = "N4ZAY1HwdJjt9QL/vyijhplFsQt06hgnPLyl7APlh+1SU210hr+LxBJxY/UbD5fJtmezr7NKeZnuaX4UOaRn/17uwlKNngSdqSohdkBOAwA8oPzl/oTQVuGwzjqgQnj7HjK8F40KL2KH3Zg+EtkP+8vVBAzB+VKpY5msVlof7Gc=NY0TDDCmoWZN1SGwQDzv19jw6Scg/FH5idAis2MJuO1E9RVMvQ6ccxMJ7b0ptekJbowmK/AK0gg+z3eLKjYNGGhkUUJ5iosNIMn02gqhJjmRxaHvlZU8H59Z2mBU7/SRC0be889eXDsMXhBORkptKHRg0A+PNOX6QSdq3vb3aB8=CZ+IB1OKpcqYSV2HGc+2QFRqahT7/ZmnsGWs7HO49DBGrGWwigQ+4khqlfCEERtzazLqdq6EcMSFxgqG76jBb4dbLbrb3ipWShCQaDLRbYsgpgd3kgICiXLw5pFpcaeDgJwxQJyk6mvL/n1u7b0DTk0FEujMfMbEoxQhI985EJM=XXDMaHVLZptz6VHzMKBA8oc1oR52IzAyqkxrmaQ3UfdVX5FAw/mjaJGifEULVZtL0TIruyHXAnkwqV9DMZbpbzUrskLn4lAdbzk0LOUWkob8OGBVlH5BR4YmtQLSUiW8XSyW1JFl9KT3gzdKQ8TNE/XmOdxxx4r1C+2Wx+lohq4=FfjFRmcdhbmUQygwuZhip8CHKOr1gW7gMPXDcdsp35zQ5HZGNJZ8vGm8wrtLlWGd9WT6XI4Rk/3KDMbooQVmkRF6I4wBErpuO62sHX8Xzf58BX6rMgY2+LuGbUI07YyDWW/1Ts/5LzABHAFmRPoEXiiU+ZYDPRM+m1yw7NYFPos=CgEgXX5lx9Mms2Ch/1QojssTYqazLz21hTglOuvs+HVeP0KsriQyTkViReQ/E1ORhCMs+I74QhEyZYxJT7mBGsU8R2sUZoIXy/1kKPacpvy84j0vvGER8lgFKtEa9b78RMOz/CjMefkEgMYTupuAaTy4Pi//5TPQqXEq5E+eTag=JoKEOZgIGK1bFVl0YnIz+bKE/FrK9qyyATJBZtonrDgXOPExFM2KNWJyh0X1AmsfjOs4+U8k3zfn1D5+TBGERjKtz4A8WkyQzTNeLl9QHWmG9wTTOXOgPns7kwm6xrTmw44MNNgcXrJbZhxU/q84e3vvn/Z8EUWLHuTMTqZcLls=" },
                    new Setting { Name = "CMSSetting.DataRsaPublicKey", Value = "HmBhuhT5tvCGONK8BL6nruUZpfY9uMFMe7YJo/BAM4hRurB/tFcrS8GVuphIuQV8jd6wcjW1T4iAj5TuPRLNDY3GtUG386/124/ua6psQc+Qk97Z02LhfMXRO3z25gnG8akQ1sBw6DSiD+Zb/ymfX+T0hkx31zwTUSHlFRC2+0Y=Rh0BooIV6ZFM6y/MC18PnhkJGyaDOCo0tdmlScT6k9ks537zkaUyFS7q/XWuKrXeGsFgIdD9ZXoWPyOLluR7uULxTdlRbQsxAu4YXfBpVXLUx4inRJRBYRYMI2DPX5TLq9QuVxsWLkeI9DEnjFobdB8PmsdHPUkhm3n8/8huSrs=" },
                    new Setting { Name = "CMSSetting.ResponseEncryption", Value = "bitw" },
                    new Setting { Name = "CMSSetting.PasswordEncryption", Value = "uOmGXtXNkLHf9Q6ftmkFxaPPE5mBuAooP34HqWlXLY4=" },
                    new Setting { Name = "CMSSetting.PostRsaType", Value = "2048" },
                    new Setting { Name = "CMSSetting.App", Value = "{\"ncbs\":{\"IP\":\"https://localhost\",\"PortLogin\":\"105\",\"PortData\":\"105\"},\"ncbsCbs\":{\"IP\":\"https://localhost\",\"PortLogin\":\"105\",\"PortData\":\"105\"},\"ncbsReport\":{\"IP\":\"https://neptuneserver\",\"PortLogin\":\"105\",\"PortData\":\"105\"},\"ncbsLicense\":{\"IP\":\"https://192.168.1.173\",\"PortLogin\":\"6005\",\"PortData\":\"6005\"},\"ncbsAdmin\":{\"IP\":\"https://neptuneserver\",\"PortLogin\":\"105\",\"PortData\":\"105\"},\"shwebank\":{\"IP\":\"https://neptuneserver\",\"PortLogin\":\"105\",\"PortData\":\"105\"},\"ncbsEvent\":{\"IP\":\"https://neptuneserver\",\"PortLogin\":\"105\",\"PortData\":\"105\"}}" },
                    new Setting { Name = "CMSSetting.PasswordEncryptonType", Value = "MD5" },
                    new Setting { Name = "CMSSetting.UserPortal", Value = "neptune" },
                    new Setting { Name = "CMSSetting.PasswordPoral", Value = "HwfKP+W3ra0mxTKkzOxC4Q==" },
                    

                     //security 
                    new Setting { Name = "CMSSetting.EncryptionKey", Value = "273ece6f97dd844d" },
                    new Setting { Name = "CMSSetting.DeveloperMode", Value = "true" },
                    new Setting { Name = "CMSSetting.TokenLifetimeDays", Value = "7" },
                    new Setting { Name = "CMSSetting.SecretKey", Value = "igTLDRYrrjV88ZAXvF+nSw" },
                    new Setting { Name = "CMSSetting.TimeoutApi", Value = "60000" },
                    new Setting { Name = "CMSSetting.ListLangConfig", Value = "[{\"key\":\"vi\",\"view\":\"VietNam\",\"img\":\"../rs/global/img/vietnam.png\"},{\"key\":\"en\",\"view\":\"English\",\"img\":\"../rs/global/img/uk.png\",\"selected\":true},{\"key\":\"la\",\"view\":\"Lao\",\"img\":\"../rs/global/img/la.png\"}]" },
                    new Setting { Name = "CMSSetting.AUTO_EXTEND_SESSION", Value = "Yes" },
                    new Setting { Name = "CMSSetting.AUTO_EXTEND_SESSION_SECOND_INTERVAL", Value = "1800000" },
                    new Setting { Name = "CMSSetting.ImportApiUrl", Value = "http://192.168.1.171:8069/" },
                    new Setting { Name = "jits.neptune.web.cms.stable", Value = "1.0.1" },
                    new Setting { Name = "jits.neptune.web.cms.login", Value = "1.0.1" },
                    new Setting { Name = "jits.neptune.web.cms.template", Value = "1.0.1" },
                    new Setting { Name = "CMSSetting.ReportApiUrl", Value = "https://localhost:5053/" }
            };
            await _dataProvider.BulkInsertEntities(settings.ToArray());
        }

        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down()
        {

        }

    }
}