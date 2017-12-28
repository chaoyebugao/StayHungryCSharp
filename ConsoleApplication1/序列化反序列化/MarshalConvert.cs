using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.序列化反序列化
{
    //此序列化使用Marshal进行，效率比Protobuf高但是只跟C#语言相关
    class MarshalConvert
    {
        public static byte[] Serialize(dynamic obj)
        {
            Type type = obj.GetType();
            var buffer = new byte[Marshal.SizeOf(type)];
            var gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var pBuffer = gch.AddrOfPinnedObject();
            Marshal.StructureToPtr(obj, pBuffer, false);
            gch.Free();
            return buffer;
        }

        public static T Deserialize<T>(byte[] data)
        {
            var gch = GCHandle.Alloc(data, GCHandleType.Pinned);
            var obj = Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(T));
            gch.Free();
            return (T)obj;
        }



        public static void Exec()
        {
            //报错
            //var a1 = new int[] { 4, 6 };
            //var a1Ser = MarshalConvert.Serialize(a1);
            //var arDeSer = MarshalConvert.Deserialize<int[]>(a1Ser);

            var a2 = new SerTest
            {
                A4 = new int[] { 4, 6 },
                I3 = 7,
                R1 = "xsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdgxsadfsfsdg",
            };
            var a2Ser = MarshalConvert.Serialize(a2);
            var a2DeSer = MarshalConvert.Deserialize<SerTest>(a2Ser);
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    class SerTest
    {
        public string R1 { get; set; }

        public int I3 { get; set; }

        public int[] A4 { get; set; }
    }
}
