using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("table")]
    public class TableTagHelper : TagHelper
    {
        //Bu method ile Html etiketleri manipule edilebilmektedir.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Sayfa içerisinde tanımlanan tablelarda otomatik olarak bootstrapın table özelliğinin eklenmesi sağlanmaktadır.
            output.Attributes.SetAttribute("class", "table table-hover");
        }
    }
}
