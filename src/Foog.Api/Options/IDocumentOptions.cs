using System.ComponentModel.DataAnnotations;

namespace Foog.Api.Options
{
    [Display(Name = "Document")]
    public class DocumentOptions
    {
        public string RoutePrefix { get; set; }
        public string Title { get; set; }
        public DocumentInfo[] Info { get; set; }

        public class DocumentInfo
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string TermsUrl { get; set; }
            public string ContactName { get; set; }
            public string ContactUrl { get; set; }
            public string LicenseName { get; set; }
            public string LicenseUrl { get; set; }
        }
    }


}
