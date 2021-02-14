using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

namespace JSON_CSHARP
{
    internal class settingData
    {
        public List<settingValue> ControlBrowser { get; set; }
        public List<settingValue> Engineering { get; set; }
    }
    internal class settingValue
    {
        public int index { get; set; }
        public int mode { get; set; }
        public int modeIndex { get; set; }
        public int outputMode { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true
            };
            string jsonPath = Path.GetDirectoryName(Directory.GetParent(Environment.CurrentDirectory).FullName) + "\\data\\setData.json";
            Console.WriteLine("=======================Deserialize Test=======================");
            Console.WriteLine(jsonPath);
            string jsonString = File.ReadAllText(jsonPath);
            Console.WriteLine(jsonString);
            settingData settingValue = JsonSerializer.Deserialize<settingData>(jsonString, options);
            Console.WriteLine("ControlBrowser");

            foreach (var item in settingValue.ControlBrowser)
            {
                Console.WriteLine($"index : {item.index} mode : {item.mode} modeIndex : {item.modeIndex} outputMode : {item.outputMode}");
            }
            Console.WriteLine("Engineering");
            foreach (var item in settingValue.Engineering)
            {
                Console.WriteLine($"index : {item.index} mode : {item.mode} modeIndex : {item.modeIndex} outputMode : {item.outputMode}");
            }

            Console.WriteLine("=======================Serialize Test=======================");
            settingValue.ControlBrowser[0].mode = 1;
            string jsonString2 = JsonSerializer.Serialize(settingValue, options);
            Console.WriteLine("json String ->");
            Console.WriteLine(jsonString2);
            File.WriteAllText("testData.json", jsonString2);
        }
    }
}
