using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.UserControl
{
    public class XCLPagerVM
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public int RecordCount { get; set; }

        public int PageSize
        {
            get;
            set;
        }

        private int _pageIndex = 1;
        public int PageIndex
        {
            get
            {
                if (this._pageIndex <= 0)
                {
                    return 1;
                }
                else if (this._pageIndex >= this.PageCount)
                {
                    return this.PageCount;
                }
                else
                {
                    return this._pageIndex;
                }
            }
            set
            {
                this._pageIndex = value;
            }
        }

        public int PageCount
        {
            get
            {
                int result = 1;
                if (this.RecordCount > 0)
                {
                    result = (int)Math.Ceiling((1.0*this.RecordCount) / this.PageSize);
                }
                return result;
            }
        }
    }
}
