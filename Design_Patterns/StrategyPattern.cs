using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    // The purpose of the strategy design pattern is to be able to select design pattern in runtime.
    public class StrategyPattern
    {
        private readonly ResponseProcessor _responseProcessor;
        public StrategyPattern(ResponseProcessor responseProcessor)
        {
            _responseProcessor = responseProcessor;
        }

        public string GetFormattedReponse()
        {
            return _responseProcessor.Process();
        }
    }

    public interface IReponseFormatStragy
    {
        string Parse();
    }

    public class XMLResponseStrategy : IReponseFormatStragy
    {
        public string Parse()
        {
            return "XML String returned";
        }
    }

    public class JSONResponseStrategy : IReponseFormatStragy
    {
        public string Parse()
        {
            return "Json String returned";
        }
    }

    public class ResponseProcessor
    {
        private readonly IReponseFormatStragy _reponseFormatStragy;

        public ResponseProcessor(IReponseFormatStragy reponseFormatStragy)
        {
            _reponseFormatStragy = reponseFormatStragy;
        }
        public string Process()
        {
            return _reponseFormatStragy.Parse();
        }
    }

}
