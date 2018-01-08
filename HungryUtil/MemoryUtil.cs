using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HungryUtil
{
    public class MemoryUtil
    {
        public static string GetMemoryAddressForRefType(object o) // 获取引用类型的内存地址方法    
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.WeakTrackResurrection);
            var addr = GCHandle.ToIntPtr(h);

            return "0x" + addr.ToString("X");
        }

        public static string GetMemoryAddressForPrimaryType(object o) // 获取引用类型的内存地址方法    
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.Pinned);
            var addr = h.AddrOfPinnedObject();

            return "0x" + addr.ToString("X");
        }
    }
}
