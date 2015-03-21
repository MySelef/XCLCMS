define(["Lib/XCLCMS","Lib/Common"], function (app,common) {
    /**
     * Easyui相关
     */
    app.EasyUI = {
        /**
         * 绑定数据时，将枚举转为描述信息
         */
        EnumToDescription: function (value, row, index) {
            return common.EnumConvert(this.field, value);
        }
    };
});