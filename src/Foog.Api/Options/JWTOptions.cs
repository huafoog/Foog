using System.ComponentModel.DataAnnotations;

namespace Foog.Api.Options
{
    [Display(Name = "JWT")]
    public class JWTOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public bool ValidateIssuerSigningKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IssuerSigningKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ValidateIssuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ValidIssuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ValidateAudience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ValidAudience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ValidateLifetime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? ExpiredTime { get; set; }
        public long ClockSkew { get; set; }
    }
}
