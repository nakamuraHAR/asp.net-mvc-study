using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PCInfoEditor.Models
{
    /// <summary>
    /// 使用区分（サーバ/個人/共有）
    /// </summary>
    public enum UseSegment
    {
        /// <summary>
        /// サーバ
        /// </summary>
        Server = 0,

        /// <summary>
        /// 個人
        /// </summary>
        Personal,

        /// <summary>
        /// 共有
        /// </summary>
        Share
    }

    /// <summary>
    /// PC管理情報
    /// </summary>
    public class PCInfo
    {
        public int ID { get; set; }

        /// <summary>
        /// PC管理番号
        /// </summary>
        [Display(Name="PC管理番号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// IPアドレス
        /// </summary>
        [Display(Name = "IPアドレス")]
        public string IPAddress { get; set; }

        /// <summary>
        /// 使用区分（サーバ/個人/共有）
        /// </summary>
        [Display(Name = "使用区分")]
        public UseSegment UseSegment { get; set; }

        /// <summary>
        /// 機種
        /// </summary>
        [Display(Name = "機種")]
        public string MachineType { get; set; }

        /// <summary>
        /// 型番
        /// </summary>
        [Display(Name = "型番")]
        public string ModelNumber { get; set; }

        /// <summary>
        /// 使用者名
        /// </summary>
        [Display(Name = "使用者名")]
        public string UserName { get; set; }

        /// <summary>
        /// PC名
        /// </summary>
        [Display(Name = "PC名")]
        public string PCName { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        [Display(Name = "備考")]
        public string Remark { get; set; }
    }

    public class PCInfoDBContext : DbContext
    {
        public DbSet<PCInfo> PCInfos { get; set; }
    }
}