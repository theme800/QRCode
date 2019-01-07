using System;
using SiteServer.Plugin;

namespace Theme800.RQCode
{
    public class Main : PluginBase
    {
        public const string PluginId = "Theme800.RQCode";
        public const string ElementName = "stl:qrcode";

        private const string AttributeUrl = "url";
        private const string AttributeSize = "size";

        public static string Parse(IParseContext context)
        {
            var url = string.Empty;
            var size = 0;

            foreach (var name in context.StlAttributes.AllKeys)
            {
                var value = context.StlAttributes[name];

                if (name.ToLower() == AttributeUrl)
                {
                    url = Context.ParseApi.ParseAttributeValue(value, context);
                }
                else if (name.ToLower() == AttributeSize)
                {
                    int.TryParse(value, out size);
                }
            }

            url = string.IsNullOrEmpty(url) ? "location.href" : $"'{url}'";

            var guid = Guid.NewGuid().ToString();
            var libUrl = Context.PluginApi.GetPluginUrl(PluginId, "qrcode.min.js");

            return size == 0
                ? $@"
<div class=""qrcode"" id=""{guid}""></div>
<script type=""text/javascript"" src=""{libUrl}""></script>
<script type=""text/javascript"">
new QRCode(document.getElementById('{guid}'), {url});
</script>
"
                : $@"
<div class=""qrcode"" id=""{guid}""></div>
<script type=""text/javascript"" src=""{libUrl}""></script>
<script type=""text/javascript"">
new QRCode(document.getElementById('{guid}'), {{
    text: {url},
	width: {size},
	height: {size}
}});
</script>
";
        }

        public override void Startup(IService service)
        {
            service.AddStlElementParser(ElementName, Parse);
        }
    }
}