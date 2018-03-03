using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using System.Threading.Tasks;

namespace WPFSerialAssistant
{
    public static class Utilities
    {

        /// <summary>
        /// 以带时间戳的字符发送接收信息
        /// </summary>
        public static string BytesToText(List<byte> bytesBuffer, ReceiveMode mode, Encoding encoding)
        {
            string result = "";
            string timeDateString = "";
            DateTime now = DateTime.Now;
            
                timeDateString = string.Format("[{0}:{1}:{2}]",
                now.Hour.ToString("00"),
                now.Minute.ToString("00"),
                now.Second.ToString("00"));
                result += encoding.GetString(bytesBuffer.ToArray<byte>());
                if (result[result.Length-1] == '\n')
                {
                    result= result.Substring(0, result.Length - 1);
                  
                }
            result = result.Replace("\n", "\n" + timeDateString);
            result = timeDateString+result + '\n';
                    

            return result;
        }
        /// <summary>
        /// 以配置模式显示接收数据
        /// </summary>
        public static string BytesToHex(List<byte> bytesBuffer, ReceiveMode mode, Encoding encoding)
        {
            string result = "";

            if (mode == ReceiveMode.Character)
            {
                return encoding.GetString(bytesBuffer.ToArray<byte>());
            }
            foreach (var item in bytesBuffer)
            {
                switch (mode)
                {
                    case ReceiveMode.Hex:
                        result += Convert.ToString(item, 16).ToUpper() + " ";
                        break;
                    case ReceiveMode.Decimal:
                        result += Convert.ToString(item, 10) + " ";
                        break;
                    case ReceiveMode.Octal:
                        result += Convert.ToString(item, 8) + " ";
                        break;
                    case ReceiveMode.Binary:
                        result += Convert.ToString(item, 2) + " ";
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
        /// <summary>
        /// 发送字符处理
        /// </summary>
        public static string ToSpecifiedText(string text, SendMode mode, Encoding encoding)
        {
            string result = "";
            switch (mode)
            {
                case SendMode.Character:
                    text = text.Trim();

                    // 转换成字节
                    List<byte> src = new List<byte>();

                    string[] grp = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in grp)
                    {
                        src.Add(Convert.ToByte(item, 16));
                    }

                    // 转换成字符串
                    result = encoding.GetString(src.ToArray<byte>());
                    break;
                    
                case SendMode.Hex:
                    
                    byte[] byteStr = encoding.GetBytes(text.ToCharArray());

                    foreach (var item in byteStr)
                    {
                        result += Convert.ToString(item, 16).ToUpper() + " ";
                    }
                    break;
                default:
                    break;
            }

            return result.Trim();
        }

    }
}
