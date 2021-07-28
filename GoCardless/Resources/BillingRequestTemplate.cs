using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using GoCardless.Internals;

namespace GoCardless.Resources
{

    /// <summary>
    /// Represents a billing request template resource.
    ///
    /// Billing Request Templates
    /// </summary>
    public class BillingRequestTemplate
    {
        /// <summary>
        /// Permanent URL that customers can visit to allow them to complete a
        /// flow based on this template, before being returned to the
        /// `redirect_uri`.
        /// </summary>
        [JsonProperty("authorisation_url")]
        public string AuthorisationUrl { get; set; }

        /// <summary>
        /// Fixed [timestamp](#api-usage-time-zones--dates), recording when this
        /// resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier, beginning with "BRT".
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// [ISO 4217](http://en.wikipedia.org/wiki/ISO_4217#Active_codes)
        /// currency code. Currently only "GBP" is supported as we only have one
        /// scheme that is per_payment_authorised.
        /// </summary>
        [JsonProperty("mandate_request_currency")]
        public string MandateRequestCurrency { get; set; }

        /// <summary>
        /// Key-value store of custom data that will be applied to the mandate
        /// created when this request is fulfilled. Up to 3 keys are permitted,
        /// with key names up to 50 characters and values up to 500 characters.
        /// </summary>
        [JsonProperty("mandate_request_metadata")]
        public IDictionary<string, string> MandateRequestMetadata { get; set; }

        /// <summary>
        /// A Direct Debit scheme. Currently "ach", "autogiro", "bacs", "becs",
        /// "becs_nz", "betalingsservice", "pad" and "sepa_core" are supported.
        /// </summary>
        [JsonProperty("mandate_request_scheme")]
        public string MandateRequestScheme { get; set; }

        /// <summary>
        /// Verification preference for the mandate. One of:
        /// <ul>
        ///   <li>`minimum`: only verify if absolutely required, such as when
        /// part of scheme rules</li>
        ///   <li>`recommended`: in addition to minimum, use the GoCardless risk
        /// engine to decide an appropriate level of verification</li>
        ///   <li>`when_available`: if verification mechanisms are available,
        /// use them</li>
        ///   <li>`always`: as `when_available`, but fail to create the Billing
        /// Request if a mechanism isn't available</li>
        /// </ul>
        /// 
        /// If not provided, the `recommended` level is chosen.
        /// </summary>
        [JsonProperty("mandate_request_verify")]
        public BillingRequestTemplateMandateRequestVerify? MandateRequestVerify { get; set; }

        /// <summary>
        /// Key-value store of custom data. Up to 3 keys are permitted, with key
        /// names up to 50 characters and values up to 500 characters.
        /// </summary>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Name for the template. Provides a friendly human name for the
        /// template, as it is shown in the dashboard. Must not exceed 255
        /// characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Amount in minor unit (e.g. pence in GBP, cents in EUR).
        /// </summary>
        [JsonProperty("payment_request_amount")]
        public int? PaymentRequestAmount { get; set; }

        /// <summary>
        /// [ISO 4217](http://en.wikipedia.org/wiki/ISO_4217#Active_codes)
        /// currency code. Currently only "GBP" is supported as we only have one
        /// scheme that is per_payment_authorised.
        /// </summary>
        [JsonProperty("payment_request_currency")]
        public string PaymentRequestCurrency { get; set; }

        /// <summary>
        /// A human-readable description of the payment. This will be displayed
        /// to the payer when authorising the billing request.
        /// 
        /// </summary>
        [JsonProperty("payment_request_description")]
        public string PaymentRequestDescription { get; set; }

        /// <summary>
        /// Key-value store of custom data that will be applied to the payment
        /// created when this request is fulfilled. Up to 3 keys are permitted,
        /// with key names up to 50 characters and values up to 500 characters.
        /// </summary>
        [JsonProperty("payment_request_metadata")]
        public IDictionary<string, string> PaymentRequestMetadata { get; set; }

        /// <summary>
        /// A Direct Debit scheme. Currently "ach", "autogiro", "bacs", "becs",
        /// "becs_nz", "betalingsservice", "pad" and "sepa_core" are supported.
        /// </summary>
        [JsonProperty("payment_request_scheme")]
        public string PaymentRequestScheme { get; set; }

        /// <summary>
        /// URL that the payer can be redirected to after completing the request
        /// flow.
        /// </summary>
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        /// <summary>
        /// Dynamic [timestamp](#api-usage-time-zones--dates) recording when
        /// this resource was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
    
    /// <summary>
    /// Verification preference for the mandate. One of:
    /// <ul>
    ///   <li>`minimum`: only verify if absolutely required, such as when part of scheme rules</li>
    ///   <li>`recommended`: in addition to minimum, use the GoCardless risk engine to decide an
    /// appropriate level of verification</li>
    ///   <li>`when_available`: if verification mechanisms are available, use them</li>
    ///   <li>`always`: as `when_available`, but fail to create the Billing Request if a mechanism
    /// isn't available</li>
    /// </ul>
    /// 
    /// If not provided, the `recommended` level is chosen.
    /// </summary>
    [JsonConverter(typeof(GcStringEnumConverter), (int)Unknown)]
    public enum BillingRequestTemplateMandateRequestVerify {
        /// <summary>Unknown status</summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0,

        /// <summary>`mandate_request_verify` with a value of "minimum"</summary>
        [EnumMember(Value = "minimum")]
        Minimum,
        /// <summary>`mandate_request_verify` with a value of "recommended"</summary>
        [EnumMember(Value = "recommended")]
        Recommended,
        /// <summary>`mandate_request_verify` with a value of "when_available"</summary>
        [EnumMember(Value = "when_available")]
        WhenAvailable,
        /// <summary>`mandate_request_verify` with a value of "always"</summary>
        [EnumMember(Value = "always")]
        Always,
    }

}
