using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.CommonHelper.Model
{
    /// <summary>
    /// 将枚举生成option时的选项
    /// </summary>
    public class SetOption
    {
        private bool _isNeedPleaseSelect = true;
        /// <summary>
        /// 是否需要生成"请选择"的option
        /// </summary>
        public bool IsNeedPleaseSelect
        {
            get
            {
                return this._isNeedPleaseSelect;
            }
            set 
            {
                this._isNeedPleaseSelect = value;
            }
        }

        /// <summary>
        /// 默认选中的项
        /// </summary>
        public string DefaultValue { get; set; }
    }
}
