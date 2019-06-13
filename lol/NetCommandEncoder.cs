using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using lolgame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    public class NetCommandEncoder : MessageToMessageEncoder<NetCommand>
    {
        protected override void Encode(IChannelHandlerContext context, NetCommand message, List<object> output)
        {
            IByteBuffer buffer = context.Allocator.Buffer();

            byte[] data = message.Serialize();
            buffer.WriteInt(data.Length);
            buffer.WriteBytes(data);
            output.Add(buffer);
        }
    }
}
