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
    public class NetCommandDecoder : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (input.ReadableBytes < 4)
                return;

            input.MarkReaderIndex();
            int dataLength = input.ReadInt();
            if (input.ReadableBytes < dataLength)
            {
                input.ResetReaderIndex();
                return;
            }

            byte[] data = new byte[dataLength];
            input.ReadBytes(data);
            NetCommand command = NetCommand.Deserialize(data);
            output.Add(command);
        }

    }
}
