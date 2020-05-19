using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhosphorusBalanceCalculator.Model
{
    public class Result
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public int IsSucceeded { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }

    public class Result<T> : Result
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
}