using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShOrleans.IGrain
{
    public interface IPerson: IGrainWithIntegerKey
    {
        /// <summary>
        /// 买东西付款啦
        /// </summary>
        /// <returns></returns>
        Task<decimal> PaySthAsync();
    }
}
