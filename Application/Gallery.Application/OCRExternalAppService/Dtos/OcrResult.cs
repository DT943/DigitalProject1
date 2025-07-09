using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gallery.Application.OCRExternalAppService.Dtos
{
    public class OcrResult
    {
        [JsonProperty("ParsedResults")]
        public List<ParsedResult> ParsedResults { get; set; }

        [JsonProperty("OCRExitCode")]
        public int OCRExitCode { get; set; }

        [JsonProperty("IsErroredOnProcessing")]
        public bool IsErroredOnProcessing { get; set; }

        [JsonProperty("ErrorMessage")]
        public List<string> ErrorMessage { get; set; }

        [JsonProperty("ErrorDetails")]
        public string ErrorDetails { get; set; }
    }

    public class ParsedResult
    {
        [JsonProperty("ParsedText")]
        public string ParsedText { get; set; }

        [JsonProperty("ErrorMessage")]
        public object ErrorMessage { get; set; }

        [JsonProperty("ErrorDetails")]
        public object ErrorDetails { get; set; }
    }

}



