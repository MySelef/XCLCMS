using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.Article
{
    /// <summary>
    /// 保存文章附件关系信息
    /// </summary>
    public class ObjectAttachment: BaseStrategy
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ObjectAttachment()
        {
            this.Name = "保存文章附件关系信息";
        }

        /// <summary>
        /// 执行策略
        /// </summary>
        public override void DoWork<T>(T context)
        {
            var articleContext = context as XCLCMS.Data.BLL.Strategy.Article.ArticleContext;

            if (null == articleContext.Article)
            {
                return;
            }

            bool flag = false;
            XCLCMS.Data.BLL.Attachment bll = new BLL.Attachment();

            try
            {
                //删除附件关系


                //添加附件关系

            }
            catch (Exception ex)
            {
                flag = false;
                this.ResultMessage += string.Format("异常信息：{0}", ex.Message);
            }

            if (flag)
            {
                this.Result = StrategyLib.ResultEnum.SUCCESS;
            }
            else
            {
                this.Result = StrategyLib.ResultEnum.FAIL;
                this.ResultMessage = string.Format("保存文章附件关系信息失败！{0}", this.ResultMessage);
            }
        }
    }
}
