using System;
using SiteServer.Plugin;

namespace Theme800.QRCode
{
    public class Main : PluginBase
    {
        public override void Startup(IService service)
        {
            service.AddStlElementParser("stl:qrcode", Parse);
        }

        private string Parse(IParseContext context)
        {
            var url = string.Empty;
            var size = 0;

            foreach (var name in context.StlAttributes.AllKeys)
            {
                var value = context.StlAttributes[name];

                if (name.ToLower() == "url")
                {
                    url = Context.ParseApi.ParseAttributeValue(value, context);
                }
                else if (name.ToLower() == "size")
                {
                    int.TryParse(value, out size);
                }
            }

            url = string.IsNullOrEmpty(url) ? "location.href" : $"'{url}'";

            var guid = Guid.NewGuid().ToString();
            var libUrl = Context.PluginApi.GetPluginUrl(Id, "qrcode.min.js");

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
    }
}