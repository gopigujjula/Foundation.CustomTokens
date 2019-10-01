using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.ExpandInitialFieldValue;
using System;

namespace Foundation.CustomTokens.Tokens
{
    public class ServerDateToken : ExpandInitialFieldValueProcessor
    {
        private const string Token = "$serverdate";

        public override void Process(ExpandInitialFieldValueArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (args.Result != null && args.Result.ToLower().Trim().Equals(Token))
            {
                args.Result = string.Empty;

                var serverDate = DateUtil.ToServerTime(DateTime.UtcNow).Date;
                var utcDate = DateUtil.ToUniversalTime(serverDate);

                args.Result = DateUtil.ToIsoDate(utcDate);
            }
        }
    }
}
