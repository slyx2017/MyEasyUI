using System;
namespace Model
{
    /// <summary>
    /// Sys_PowerLevel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_PowerLevel
    {
        public Sys_PowerLevel()
        { }
        #region Model
        private int _powerLevelid;
        private string _powername;
        private DateTime? _addtime;
        private string _adduser;
        private int? _powerstate = 1;
        private string _levelname;
        /// <summary>
        /// 
        /// </summary>
        public int PowerLevelID
        {
            set { _powerLevelid = value; }
            get { return _powerLevelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PowerName
        {
            set { _powername = value; }
            get { return _powername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PowerState
        {
            set { _powerstate = value; }
            get { return _powerstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LevelName
        {
            set { _levelname = value; }
            get { return _levelname; }
        }
        #endregion Model

    }
}

