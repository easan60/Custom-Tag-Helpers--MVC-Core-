using CustomTagHelpers.Controllers.Entites;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTagHelpers.TagHelpers
{
    [HtmlTargetElement("product-list")]
    public class ProductListTagHelper:TagHelper
    {
        private List<Product> _products;
        public ProductListTagHelper()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,ProductName="Computer",UnitPrice=4000},
                new Product{ProductId=2,ProductName="Mouse",UnitPrice=100},
                new Product{ProductId=3,ProductName="Keyboard",UnitPrice=300},
                new Product{ProductId=4,ProductName="TV",UnitPrice=7000},
                new Product{ProductId=5,ProductName="Telephone",UnitPrice=1000},
                new Product{ProductId=6,ProductName="Book",UnitPrice=10}
            };
        }

        [HtmlAttributeName("count")]
        public int ListCount { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder = new StringBuilder();
            output.TagName = "div";
            var query = _products.Take(ListCount);
            stringBuilder.AppendFormat("<table class='table table-bordered mt-5'>" +
                    "<thead><tr><th> ProductId </th><th> ProductName </th><th> UnitPrice </th></tr></thead>" +
                    "<tbody>");
            foreach (var product in query)
            {
                stringBuilder.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", product.ProductId, product.ProductName, product.UnitPrice);
            }
            stringBuilder.AppendFormat("</tbody></table>");
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }

    }
}
