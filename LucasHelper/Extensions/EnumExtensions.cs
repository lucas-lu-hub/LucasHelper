using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeySer.Fuji.Core.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举值上的Description特性的说明
        /// </summary>
        /// <returns>特性的说明</returns>
        public static string GetDescription(this Enum en)
        {
            var type = en.GetType();
            var field = type.GetField(Enum.GetName(type, en));
            if (!(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute descAttr))
            {
                return string.Empty;
            }
            return descAttr.Description;
        }

    }
}
