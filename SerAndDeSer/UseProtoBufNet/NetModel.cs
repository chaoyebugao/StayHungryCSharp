using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerAndDeSer.UseProtoBufNet
{
    //添加特性，表示可以被ProtoBuf工具序列化，需安装protobuf-net包
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Request")]
    public class NetModel
    {
        [ProtoBuf.ProtoMember(1)]
        public int RR { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public DateTime D1 { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string Desc { get; set; }
    }
}
