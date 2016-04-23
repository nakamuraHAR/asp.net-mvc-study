using System.Data.Entity;

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
        public string SerialNumber { get; set; }

        /// <summary>
        /// IPアドレス
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 使用区分（サーバ/個人/共有）
        /// </summary>
        public UseSegment UseSegment { get; set; }

        /// <summary>
        /// 機種
        /// </summary>
        public string MachineType { get; set; }

        /// <summary>
        /// 型番
        /// </summary>
        public string ModelNumber { get; set; }

        /// <summary>
        /// 使用者名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// PC名
        /// </summary>
        public string PCName { get; set; }

        /// <summary>
        /// 備考１
        /// </summary>
        public string Remark1 { get; set; }

        /// <summary>
        /// 備考２
        /// </summary>
        public string Remark2 { get; set; }
    }

    public class PCInfoDBContext : DbContext
    {
        public DbSet<PCInfo> PCInfos { get; set; }
    }
}